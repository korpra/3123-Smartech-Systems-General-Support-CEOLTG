Option Strict Off
Option Explicit On
Friend Class clsData_LTG_Readings
	
	'***************************************************************
	'
	'Class:    clsData_LTG_Readings
	'
	'Description:   This class is used for storing the Laser Thickness Gauge readings.
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
    '01/09/06   fjm         Created
    '2010-11-30 dld         Added Intensity2 Reading
    '2012-01-13 rkp         Modified class for SOLTG
    '2016-10-06 fjm         Modified for CEOLTG
    '***************************************************************
	
	'************************** Constants **************************
	
	'************************** Publics *****************************
    Public Thickness As Double() = {}
    Public Distance As Double() = {}
    Public Intensity As Double() = {}
    Public PointCnt As Short = 0
    Public Position As Double() = {}

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub AddPoint(ByVal dblThickness As Double,
                        ByVal dblDistance As Double,
                        ByVal dblIntensity As Double,
                        ByVal dblPosition As Double)

        Try
            'Increment Point Count
            Me.PointCnt = Me.PointCnt + 1

            'Redimension Arrays
            ReDim Preserve Thickness(Me.PointCnt - 1)
            ReDim Preserve Distance(Me.PointCnt - 1)
            ReDim Preserve Intensity(Me.PointCnt - 1)
            ReDim Preserve Position(Me.PointCnt - 1)

            'Save Values
            Thickness(Me.PointCnt - 1) = dblThickness
            Distance(Me.PointCnt - 1) = dblDistance
            Intensity(Me.PointCnt - 1) = dblIntensity
            Position(Me.PointCnt - 1) = dblPosition

        Catch ex As Exception
            'gLog.LogErr(Me.GetType.Name, "AddPoint", ex)
        End Try
    End Sub

    ReadOnly Property StartPointX As Double
        Get
            Dim dReturn As Double = 0

            If Me.Position.Count > 0 Then
                dReturn = Me.Position(0)
            End If

            Return dReturn
        End Get
    End Property

    ReadOnly Property EndPointX As Double
        Get
            Dim dReturn As Double = 0

            If Me.Position.Count > 0 Then
                dReturn = Me.Position(Me.Position.GetUpperBound(0))
            End If

            Return dReturn
        End Get
    End Property

End Class