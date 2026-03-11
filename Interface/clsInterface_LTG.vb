Option Strict Off
Option Explicit On
Imports System.IO
Imports System.IO.Pipes
Imports System.Text
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports NationalInstruments.Restricted

Friend MustInherit Class clsInterface_LTG
    '***************************************************************
    '
    'Class:    clsInterface_LTG
    '
    'Description:   This class is part of the Interfacing.  It interfaces
    '               with the Laser Thickness Gauge (LTG).
    '
    'Created by:    Smartech Systems, Inc.
    '               500 East Brighton Ave
    '               Syracuse, NY 13210
    '               www.smartechsys.com
    '               Phone:  315-701-2316
    '               Fax:    315-701-2317
    '
    '
    '
    'Modifications:
    'Date       Initials    Description
    '08/24/05   fjm         Created
    '2010-11-30 dld         Changed code to communicate to Keyence SI-F80 sensor
    '2016-10-03 fjm         Change thickness sensor to CHRocodile - Precitec
    '***************************************************************

#Region "Constants"
    Const cMinBufferSize As Integer = 1000
#End Region

#Region "Publics"
    Public EncoderResolution As Double = 1

    Public LastThickness As Double = 0
    Public LastDistance As Double = 0
    Public LastDistance2 As Double = 0
    Public LastIntensity As Double = 0
    Public LastPosition As Double = 0
    Public LastSensorIdxRef As Double = 0
    Public SensorStatus As String = ""

    Public MinThickness As Double = 0.1
    Public MinIntensity As Double = 0.1
    Public MinDistance As Double = 0.1
    Public MaxDistance As Double = 4
    Public SheetStartMinConsectiveCount As Integer = 5
    Public SheetEndMinConsectiveCount As Integer = 5

#End Region

#Region "Locals"
    Protected _LaserMode As enumLaserMode = enumLaserMode.lsrNone

    Private _Thickness As New List(Of Double)
    Private _Distance As New List(Of Double)
    Private _Distance2 As New List(Of Double)
    Private _Intensity As New List(Of Double)
    Private _Position As New List(Of Double)

    Private _SheetDetected As Boolean = False
    Private _EndOfSheetDetected As Boolean = False
    Private _PostSheetClear As Boolean = False


    Private _dtTime As DateTime = DateTime.MinValue




#End Region

#Region "Contructor/Destructors"
    Public Sub New()
        MyBase.New()
        Try
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        On Error Resume Next
        Me.SetMode(enumLaserMode.lsrNone)
        Me.Disconnect()

        MyBase.Finalize()
    End Sub
#End Region

#Region "Connect/Disconnect"
    Public MustOverride Sub Connect()
    Public MustOverride Sub Disconnect()
    Public MustOverride Function GoodPoint(dblThickness As Double, dblDistance1 As Double, dblDistance2 As Double, dblIntensity As Double) As Boolean
#End Region

#Region "Data Collection State"
    Public Overridable Sub SetMode(ByRef laserMode As enumLaserMode)
        Try
            'Initialize Variables 

            'First check to see if Laser is already running for selected mode
            If Me._LaserMode <> laserMode Then
                'Save Mode
                Me._LaserMode = laserMode
            End If
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Me.SensorStatus = ex.Message
        End Try
    End Sub
#End Region

#Region "Communications Processing"

    Private _ConsectiveCount As Integer = 0

    Protected Sub AddPoint(ByVal dblThickness As Double,
                         ByVal dblDistance As Double,
                         ByVal dblIntensity As Double,
                         ByVal dblPosition As Double,
                         Optional ByVal dblDistance2 As Double = Double.NaN)
        Try

            'Save Last Values
            Me.LastThickness = dblThickness
            Me.LastDistance = dblDistance
            Me.LastDistance2 = dblDistance2
            Me.LastIntensity = dblIntensity
            Me.LastPosition = dblPosition

            'Add Readings to List
            Me._Thickness.Add(dblThickness)
            Me._Distance.Add(dblDistance)
            Me._Distance2.Add(dblDistance2)
            Me._Intensity.Add(dblIntensity)
            Me._Position.Add(dblPosition)

            'Check current substate
            Select Case gSubState
                Case enumSubState.ssWaitForSheet
                    'Check for Glass Present
                    If GoodPoint(dblThickness, dblDistance, dblDistance2, dblIntensity) Then
                        _ConsectiveCount += 1
                        If _ConsectiveCount >= Me.SheetStartMinConsectiveCount Then
                            Me._LaserMode = enumLaserMode.lsrCollectData
                            Me._SheetDetected = True
                            _ConsectiveCount = 0
                        End If
                    Else
                        _ConsectiveCount = 0
                    End If
                Case enumSubState.ssCollectingData
                    'Check for Glass Not Present
                    If Not (GoodPoint(dblThickness, dblDistance, dblDistance2, dblIntensity)) Then
                        _ConsectiveCount += 1
                        If _ConsectiveCount >= Me.SheetEndMinConsectiveCount Then
                            Me._EndOfSheetDetected = True
                        End If
                    Else
                        _ConsectiveCount = 0
                    End If

                Case enumSubState.ssPostSheetClear
                    'Check for Glass Not Present
                    If Not (GoodPoint(dblThickness, dblDistance, dblDistance2, dblIntensity)) Then
                        _ConsectiveCount += 1
                        If _ConsectiveCount >= Me.SheetEndMinConsectiveCount Then
                            Me._PostSheetClear = True
                        End If
                    Else
                        _ConsectiveCount = 0
                        Me._PostSheetClear = False
                    End If


                Case Else
                    _ConsectiveCount = 0
                    Me._PostSheetClear = False
            End Select

            'Based on mode determine if need to remove un-needed points
            If Me._LaserMode <> enumLaserMode.lsrCollectData Then
                While Me._Thickness.Count > clsInterface_LTG.cMinBufferSize
                    Me._Thickness.RemoveAt(0)
                    Me._Distance.RemoveAt(0)
                    Me._Distance2.RemoveAt(0)
                    Me._Intensity.RemoveAt(0)
                    Me._Position.RemoveAt(0)
                End While
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
    End Sub


#End Region

#Region "Other Functions"
    Public Sub GetSheetData(ByRef oRaw As clsData_LTG_Readings)
        Try
            'Get Copy of Data
            With oRaw
                'Save Data
                .Distance = Me._Distance.ToArray
                .Distance2 = Me._Distance2.ToArray
                .Intensity = Me._Intensity.ToArray
                .Thickness = Me._Thickness.ToArray
                .Position = Me._Position.ToArray
                .PointCnt = Me._Thickness.Count
                .SensorIdxRef = Me.LastSensorIdxRef
            End With

            'Reset lists
            Me._Distance.Clear()
            Me._Distance2.Clear()
            Me._Intensity.Clear()
            Me._Thickness.Clear()
            Me._Position.Clear()

            'Reset Sheet Detected
            Me._SheetDetected = False
            Me._EndOfSheetDetected = False
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
    End Sub
#End Region

#Region "Properties"
    ReadOnly Property SheetDetected As Boolean
        Get
            Return Me._SheetDetected
        End Get
    End Property

    ReadOnly Property EndOfSheetDetected As Boolean
        Get
            Return Me._EndOfSheetDetected
        End Get
    End Property

    ReadOnly Property PostSheetClear As Boolean
        Get
            Return Me._PostSheetClear
        End Get
    End Property
#End Region
End Class