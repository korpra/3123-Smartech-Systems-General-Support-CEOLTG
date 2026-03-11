Option Strict Off
Option Explicit On
Friend Class clsData_Info
    '***************************************************************
    '
    'Class:    clsData_Info
    '
    'Description:   This class is used for storing the information about
    '               the Gauge, Glass, and test data.
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
    '2009-04-27 fjm         Added SizeWidth_Product to maintain Width from ProductFile
    '2009-08-10 fjm         Changed ProductGroup from String to clsFile_ProductGroup
    '2012-01-13 rkp         Added parameters for SOLTG
    '2012-04-24 rkp         Added Last Measurement Time in Sheet Info section
    '
    '***************************************************************
#Region "Constants"
    Public Const cReasonNone As Integer = 0
    Public Const cReasonReject As Integer = 16
#End Region

#Region "Publics"
    Public Oper As String = "Gauge"
    Public GaugeID As String = "Smart"
    Public MeasureDT As Date = New Date(0)
    Public ProductCode As String = ""
    Public GlassCode As String = ""

    'NOTE: No longer needed...leoc
    'Public GlassRefIdx As Double = 1.0

    'Public SizeWidth As Double = 100
    'Public SizeWidth_Measured As Double = 100
    'Public LeftEdge As Double = 0
    'Public RightEdge As Double = 100
    Public Thickness As Double = 1
    Public RunNotes As String = "None"
    Public RunningMode As String

    Public TankID As String = ""
    Public RunStartTime As Date = New Date(0)
    Public DPStartTime As Date = New Date(0)
    Public GaugeEndTime As Date = New Date(0)
    Public DPEndTime As Date = New Date(0)

    Public BornDT As Date = New Date(0)
    Public FormingDT As Date = New Date(0)
    Public UID As Integer = 0
    Public Reason As Integer = cReasonNone
    Public ReasonString As String = ""
    Public Results As String = ""
    Public Alarm As Double = 0
    Public Purpose As String = ""
    Public GlassType As String = ""
    Public QASheetWidth As Double = 0

    Public TrimCompression As Double = 25
    Public TrimInlet As Double = 0
    Public CompressionBeadWidth As Double = 0
    Public MESFile As String = ""
    Public ProductWidth As Double = 0
    Public ProductHeight As Double = 0
    Public DataFile As String = ""
    Public VBSOffset As Double = 0
    Public QAStart As Double = 0
    Public QAEnd As Double = 0

    'Public CarrierNum As Integer = 0, use UID from PLC instead
    Public StatusWord1 As Integer = 0
    Public StatusWord2 As Integer = 0
#End Region



    '***************************************************************
    'This function defines the file name for saving the data in the proper format.
    'Note: This function does not return the extension since it is used for different
    '       types of data. Raw, MES, Calibration, Verification
    'Format: <GaugeID>_<Purpose>_<TankID>_<FormingDate>_<MeasurementDate>
    Public Function FileName() As String
        Dim strFile As String

        'Define Filename
        strFile = Me.GaugeID.Trim
        strFile = strFile & "_" & Left(Me.Purpose, 1)
        strFile = strFile & "_" & Me.TankID.Trim
        strFile = strFile & "_" & Me.FormingDT.ToString("yyyy-MM-dd-HH-mm-ss")

        'Return File Name
        FileName = strFile
    End Function

    ReadOnly Property ProductCode_Number As String
        Get
            Try
                Return Me.ProductCode.Substring(Me.ProductCode.LastIndexOf("_") + 1)
            Catch ex As Exception
                Return Me.ProductCode
            End Try
        End Get
    End Property

End Class