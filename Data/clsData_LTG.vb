Option Strict Off
Option Explicit On

Imports System.Collections.Generic

Friend Class clsData_LTG

    '***************************************************************
    '
    'Class:    clsData_LTG
    '
    'Description:   This class is used for storing the Laser Thickness Gauge data.
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
    '01/02/06   fjm         Created
    '03/15/07   fjm         IT needs output data to start at or before the VBSOffset for Beaded Glass
    '2010-11-11 fjm         Changed thickness file output
    '2010-11-16 fjm         Added VBSOffset and FullSheetWidth to file output
    '2010-11-30 dld         Added Intensity2 to Engineering Output File
    '2010-12-22 fjm         Added MES Test flags
    '2012-01-13 rkp         Modified for SOLTG
    '2016-10-06 fjm         Modified for CEOLTG
    '***************************************************************

#Region "Publics"
    Public Raw As New clsData_LTG_Readings
    Public Sheet As New clsData_LTG_Readings

    Public Info As clsData_Info
    Public MESFile As String = ""

    Public LeftEdge As Double = -999
    Public RightEdge As Double = -999
    Public SizeWidth_Measured As Double = 0

    Public Passed As Boolean = False
    Public GoodPointsLocated As Boolean = False
    Public BadPointPositions As Single() = {}
    Public BadOverallCnt As Short = 0
    Public BadConsecutiveCnt As Short = 0
    Public SensorIdxRef As Double = 0

    Public TankDirectory As String

    Public CycleTime As Double = 0

    ''' <summary>
    ''' Quality Area Thickness Maximum
    ''' </summary>
    Public QAThicknessMax As Double = 0

    ''' <summary>
    ''' Quality Area Thickness Minimum
    ''' </summary>
    Public QAThicknessMin As Double = 0

    ''' <summary>
    ''' Quality Area Thickness Average
    ''' </summary>
    Public QAThicknessAvg As Double = 0

    ''' <summary>
    ''' Quality Area Thickness Range
    ''' </summary>
    Public QAThicknessRng As Double = 0

    Public QAMWR As New List(Of clsSpec_MWR)
#End Region

    Public Sub New(ByVal objInfo As clsData_Info)
        MyBase.New()

        Me.Info = objInfo
    End Sub

    Public Sub Init()
        Try
            Me.Raw = New clsData_LTG_Readings
            Me.Sheet = New clsData_LTG_Readings
            ReDim Me.BadPointPositions(0)
            Me.BadOverallCnt = 0
            Me.BadConsecutiveCnt = 0
            Me.Passed = False

            Me.QAThicknessMax = 0
            Me.QAThicknessMin = 0
            Me.QAThicknessAvg = 0
            Me.QAThicknessRng = 0
            Me.QAMWR = New List(Of clsSpec_MWR)
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    '*************************************************************
    Public Sub AddBadPoint(ByRef sngLocation As Single)
        On Error GoTo ErrorHandler

        'Increment Count
        BadOverallCnt = BadOverallCnt + 1

        'Redimension Array and save value
        ReDim Preserve BadPointPositions(Me.BadOverallCnt - 1)
        BadPointPositions(BadOverallCnt - 1) = sngLocation

        Exit Sub
ErrorHandler:
        gLog.LogErr(("clsData_LTG.AddBadPoint(" & sngLocation.ToString() & ") , Error: " & Err.Description))
    End Sub


    Public Function SaveSheetData() As enumError
        Dim errReturn As enumError = enumError.errNone
        Dim strFile As String
        Dim intIndex As Integer
        Dim strLine As String

        Try
            If Me.Sheet.Thickness.Length > 0 Then

                'LTG uses FormingDT in filename
                strFile = Me.Info.GaugeID.Trim
                strFile = strFile & "_" & Left(Me.Info.Purpose, 1)
                strFile = strFile & "_" & Me.Info.TankID.Trim
                strFile = strFile & "_" & (Me.Info.MeasureDT.ToString("yyyy-MM-dd_HH-mm-ss")).Replace(" ", "") & ".csv"
                gLog.LogMsg(strFile)

                'Add Path
                strFile = gConfig.DataPath & strFile

                'Save Filename and Path 
                Me.MESFile = strFile

                Using sw As New System.IO.StreamWriter(strFile)
                    'Write File Header
                    Me.WriteHeader(sw, OutputFileType.MES)

                    'Save Thickness readings
                    sw.WriteLine("Position,Thickness,Displacement")
                    For intIndex = 0 To UBound(Me.Sheet.Thickness)
                        strLine = Me.Sheet.Position(intIndex).ToString("0.000") _
                                & "," & Me.Sheet.Thickness(intIndex).ToString("0." & StrDup(gConfig.DecimalPlaces, "0"c)) _
                                & "," & Me.Sheet.Distance(intIndex).ToString("0.000")
                        sw.WriteLine(strLine)
                    Next intIndex
                    sw.Close()
                End Using

                'Log Message
                gLog.LogMsg(strFile & ", File Saved!")
            End If


        Catch ex As Exception
            gLog.LogErr("clsData_LTG.SaveSheetData(), " & ex.Message)

        End Try

        'If no error then Success
        If errReturn <> enumError.errFailure Then
            errReturn = enumError.errSuccess
        End If

        'Return Status
        Return errReturn

    End Function

    Public Function SaveLastMeasurement() As enumError
        Dim errReturn As enumError = enumError.errNone
        Dim strFile As String
        Dim intIndex As Integer
        Dim strLine As String

        Try
            If Me.Sheet.Thickness.Length > 0 Then
                strFile = gConfig.LastMeasurementPath & "LastMeasurement.csv"

                Using sw As New System.IO.StreamWriter(strFile)
                    'Write File Header
                    Me.WriteHeader(sw, OutputFileType.LastMeasurement)

                    'Removed, fjm, 2017-10-09
                    'sw.WriteLine("Trim Inlet (mm)," & gDP.LTGTrim.ToString)
                    'sw.WriteLine("Trim Compression (mm)," & gDP.LTGTrim.ToString)

                    'Save Thickness readings
                    sw.WriteLine("Position,Thickness")
                    For intIndex = 0 To UBound(Me.Sheet.Thickness)
                        strLine = Me.Sheet.Position(intIndex).ToString("0.000") _
                                & "," & Me.Sheet.Thickness(intIndex).ToString("0." & StrDup(gConfig.DecimalPlaces, "0"c))
                        sw.WriteLine(strLine)
                    Next intIndex
                    sw.Close()
                End Using

                'Log Message
                gLog.LogMsg(strFile & ", File Saved!")
            End If
        Catch ex As Exception
            gLog.LogErr("clsData_LTG.SaveLastMeasurement(), " & ex.Message)

        End Try

        'If no error then Success
        If errReturn <> enumError.errFailure Then
            errReturn = enumError.errSuccess
        End If

        'Return Status
        Return errReturn

    End Function
    Public Enum OutputFileType
        MES = 1
        Engineering = 2
        LastMeasurement = 3
    End Enum

    Private Sub WriteHeader(sw As System.IO.StreamWriter, fileType As OutputFileType)
        Try
            'Save Header, fjm, 2010-01-05
            With Me.Info
                'sw.WriteLine("Gauge," & .GaugeID)
                'sw.WriteLine("S/W Version,v" & My.Application.Info.Version.Major.ToString() _
                '                                & "." & My.Application.Info.Version.Minor.ToString() _
                '                                & "." & My.Application.Info.Version.Build.ToString())
                sw.WriteLine("Tank," & .TankID.ToString)
                sw.WriteLine("BOD ID," & gConfig.BODID.ToString)
                sw.WriteLine("Measurement Date," & .MeasureDT.ToString("MM/dd/yyyy"))
                sw.WriteLine("Measurement Time," & .MeasureDT.ToString("HH:mm:ss"))
                sw.WriteLine("Born-Date," & .BornDT.ToString("MM/dd/yyyy"))
                sw.WriteLine("Born-Time," & .BornDT.ToString("HH:mm:ss"))
                sw.WriteLine("UID,0")    '("UID," & .UID.ToString)
                sw.WriteLine("Drop-If-Reject," & IIf(gConfig.DropIfReject, "T", "F"))
                sw.WriteLine("Carrier-Nbr," & .UID.ToString)
                sw.WriteLine("Status-Word-1," & .StatusWord1.ToString)
                sw.WriteLine("Status-Word-2," & .StatusWord2.ToString)
                sw.WriteLine("Alarm," & .Alarm.ToString)
                sw.WriteLine("Purpose," & .Purpose)
                sw.WriteLine("Product Code," & .ProductCode_Number)
                sw.WriteLine("Glass Code," & .GlassCode)
                sw.WriteLine("Glass Type," & .GlassType)

                'NOTE: Not using glassrefidx anymore...leoc
                'sw.WriteLine("Glass RefIdx," & .GlassRefIdx.ToString("0.0000"))

                sw.WriteLine("Product Width (mm)," & .ProductWidth.ToString("0"))
                sw.WriteLine("Product Height (mm)," & .ProductHeight.ToString("0"))
                sw.WriteLine("Product Thickness (mm)," & .Thickness.ToString("0.000"))  'v1.1.14
                'sw.WriteLine("Trim Inlet (mm)," & .TrimInlet.ToString("0"))
                sw.WriteLine("Trim Compression (mm)," & .TrimCompression.ToString("0"))
                sw.WriteLine("VBS Offset (mm)," & IIf(.VBSOffset >= 0, .VBSOffset.ToString("0"), "0"))
                sw.WriteLine("Full Sheet Width (mm)," & Me.SizeWidth_Measured.ToString("0"))
                sw.WriteLine("QA Sheet Width (mm)," & .QASheetWidth.ToString("0"))
                If fileType = OutputFileType.MES And gConfig.OutputQAStartEndToMES Then
                    'output the QA start and end
                    sw.WriteLine("QA Start (mm)," & .QAStart.ToString("0"))
                    sw.WriteLine("QA End (mm)," & .QAEnd.ToString("0"))
                End If
                'CPM does not want QA Range, they don't use MWR so if list is empty, do not write to file, v1.1.15
                If QAMWR.Count > 0 Then
                    sw.WriteLine("QA Range (microns)," & (QAThicknessRng * 1000).ToString("0"))
                    For Each oMWR As clsSpec_MWR In QAMWR
                        sw.WriteLine("MWR " + oMWR.WindowSize.ToString("0") + " mm (microns)," & (oMWR.CalcMWR * 1000).ToString("0"))
                    Next
                End If
                sw.WriteLine("Leading Edge," & IIf(gConfig.InletLeadingEdge, "Compression", "Inlet"))
                sw.WriteLine("Calibration Standard," & gDP.CalibrationStandard)
                sw.WriteLine("Calibration Glass Code," & gDP.CalibrationGlassCode)
                sw.WriteLine("Calibration Glass Type," & gDP.CalibrationGlassType)
                sw.WriteLine("Calibration Glass RefIdx," & gDP.CalibrationGlassRefIdx)
                sw.WriteLine("Defect Results," & .Reason)
                sw.WriteLine("Encoder Count," & (Me.SizeWidth_Measured / gLTG.EncoderResolution).ToString("0"))
                sw.WriteLine("Encoder mm per Count," & gLTG.EncoderResolution.ToString("0.00000"))
                sw.WriteLine("Cycle Time," & Me.CycleTime.ToString("0"))
                sw.WriteLine("Number of Bad Points," & Me.BadOverallCnt.ToString("0"))
                sw.WriteLine("Number of Reported Points," & Me.Sheet.Thickness.Count.ToString("0"))
            End With
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    '*************************************************************
    Public Function SaveEngineerData() As enumError
        Dim errReturn As enumError
        Dim strFile As String
        Dim strLine As String

        Try
            'Initialize Variables
            errReturn = enumError.errNone

            'Create Directory if doesn't exist
            CreateDirectory(gConfig.LTGEngineerOutputPath)

            'LTG uses FormingDT in filename
            strFile = "Eng_" & Me.Info.GaugeID.Trim
            strFile = strFile & "_" & Me.Info.TankID.Trim
            strFile = strFile & "_" & (Me.Info.MeasureDT.ToString("yyyy-MM-dd_HH-mm-ss")).Replace(" ", "") & ".csv"

            'Add Path
            strFile = gConfig.LTGEngineerOutputPath & strFile

            Using sw As New System.IO.StreamWriter(strFile)
                'Write File Header
                Me.WriteHeader(sw, OutputFileType.Engineering)


                'Save Thickness readings
                'Changed Distance and Intensity format from "0" to "0.000", v1.1.16
                If Me.Raw.HasDistance2Values Then
                    sw.WriteLine("Position,Thickness,Distance,Distance2,Intensity")
                    For i As Integer = 0 To UBound(Me.Raw.Thickness)
                        strLine = Me.Raw.Position(i).ToString("0.000") _
                               & "," & Me.Raw.Thickness(i).ToString("0.000000") _
                               & "," & Me.Raw.Distance(i).ToString("0.000") _
                               & "," & Me.Raw.Distance2(i).ToString("0.000") _
                               & "," & Me.Raw.Intensity(i).ToString("0.000")
                        sw.WriteLine(strLine)
                    Next i
                Else
                    sw.WriteLine("Position,Thickness,Distance,Intensity")
                    For i As Integer = 0 To UBound(Me.Raw.Thickness)
                        strLine = Me.Raw.Position(i).ToString("0.000") _
                               & "," & Me.Raw.Thickness(i).ToString("0.000000") _
                               & "," & Me.Raw.Distance(i).ToString("0.000") _
                               & "," & Me.Raw.Intensity(i).ToString("0.000")
                        sw.WriteLine(strLine)
                    Next i
                End If


                sw.Close()
                'Log Message
                gLog.LogMsg(strFile & ", File Saved!")
            End Using

        Catch ex As Exception
            gLog.LogErr("clsData_LTG.SaveEngineerData(" & "), " & ex.Message)
            errReturn = enumError.errFailure
        End Try

        'If no error then Success
        If errReturn <> enumError.errFailure Then
            errReturn = enumError.errSuccess
        End If

        'Return Status
        Return errReturn

    End Function
End Class