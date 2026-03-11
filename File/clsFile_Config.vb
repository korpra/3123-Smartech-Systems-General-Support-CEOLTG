Option Strict Off
Option Explicit On
Imports System.IO


''' <summary>
'''Description:   This class is the main file class for storing the configuration
'''               Information.
'''
'''Created by:    Smartech Systems, Inc.
'''               500 East Brighton Ave
'''               Syracuse, NY 13210
'''               www.smartechsys.com
'''               Phone:  315-701-2316
'''               Fax:    315-701-2317
'''
'''
'''
'''Modifications:
'''Date         Initials    Description
'''2008-09-01   fjm         Converted to VB.Net 2008
''' </summary>
Friend Class clsFile_Config



#Region "Public Members"
    Public GaugeID As String = ""
    Public GaugeName As String = ""
    Public TankID As String = ""
    Public BODID As String = ""
    Public AdminPW As String = ""
    Public Dll As String = cFileDll
    Public LastPassword As String = ""
    Public MESBatchFile As String = ""

    Public LastProductFile As String = ""
    Public LastPurpose As String = ""

    'NOTE: Not using LastGlassRefIdx anymore...leoc
    'Public LastGlassRefIdx As Double = 1.0

    Public DataPath As String = "c:\CEOLTG\Data\"
    Public DataFileSavePeriod As Integer = 1
    Public DataFileSaveUIDSynch As Boolean = False
    Public SpecFilesPath As String = "c:\CEOLTG\SpecFiles\"
    Public SpecFilenameFormat As String = "FullSheet*.xml"

    Public ThicknessGraphMax As Single = 1.0
    Public ThicknessGraphMin As Single = 0.5
    Public DistanceGraphMax As Single = 10.0
    Public DistanceGraphMin As Single = 0.0
    Public DistanceGraphInverted As Boolean = False
    Public DistanceGraphLinearFitEnable As Boolean = True
    Public LTGEngineerOutput As Boolean = False
    Public LTGEngineerOutputPath As String = "c:\CEOLTG\Eng\"
    Public LastMeasurement As Boolean = True
    Public LastMeasurementPath As String = "c:\CEOLTG\Log\"

    Public LTGSpecBinningEnable As Boolean = False
    Public LTGSpecBinningDistance As Double = 5.0#

    Public DropIfReject As Boolean = False
    'Public VBSOffset As Double = 0
    'Public LeadingEdgeCompression As Boolean = False
    Public PostSheetClearTime As Single = 0.2

    Public InletLeadingEdge As Boolean = False

    Public FilterMedianWindowEnable As Boolean = False
    Public FilterMedianWindowWindowSize As Double = 10

    Public SGFilterEnabled As Boolean = False
    Public SGWindowSize As Integer = 9

    Public MeasurementTimeout As Double = 3.0
    Public AppDispAndJudgeEnable As Boolean = True

    Public WidthRejectVisible As Boolean = False
    Public WidthRejectEnable As Boolean = False
    Public WidthRejectMin As Double = 5
    Public WidthRejectMax As Double = 5
    Public IdxRefLookupIntervalSecs As Integer = 0
    Public OutputQAStartEndToMES As Boolean
    Public CalculatedQATrimEnabled As Boolean ' Calculated QA Trim to round QA area to a whole number

    Public DecimalPlaces As Integer = 4
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    'Public Function ReadConfig() As enumError      Modifed this to have an optional re-read
    Public Function ReadConfig(Optional ByVal optReRead As Boolean = False) As enumError
        Dim errReturn As enumError = enumError.errNone
        Dim hndFile As Short = 0
        Dim strFile As String = ""
        Dim strLine As String = ""

        Try
            Dim udtSetting As typSetting

            'Load Dll
            Me.GetDll()

            'Define Filename
            Dim sAppName As String = My.Application.Info.AssemblyName
            hndFile = FreeFile()
            strFile = FormatPath(gstrCurDir & cPathConfig) & sAppName & cFileExtConfig

            'Create file if it does not exist
            If Not File.Exists(strFile) Then
                Me.SaveConfig()
            End If

            'Open file
            FileOpen(hndFile, strFile, OpenMode.Input)

            'Step through file
            While Not EOF(hndFile)
                'Read Line and Trim Spaces
                strLine = LineInput(hndFile)
                strLine = Trim(strLine)

                'Make sure this isn't a comment line
                If Left(strLine, 1) <> ";" And strLine <> "" Then
                    'Get Setting
                    udtSetting = GetSetting(strLine)

                    'Check Name
                    'The first part in order of the config file
                    'The remaining are in alphabetical order
                    Select Case udtSetting.Name.ToUpper
                        Case ""
                        Case "GaugeName".ToUpper : Me.GaugeName = udtSetting.Value
                        Case "GaugeID".ToUpper : Me.GaugeID = udtSetting.Value
                        Case "TankID".ToUpper : Me.TankID = udtSetting.Value
                        Case "BOD_ID".ToUpper : Me.BODID = udtSetting.Value
                        Case "DebugLevel".ToUpper : gLog.DebugLevel = Val(udtSetting.Value)
                        Case "LogDuration".ToUpper : gLog.LogDuration = CInt(udtSetting.Value)
                        Case "adminpw".ToUpper : Me.AdminPW = udtSetting.Value
                        Case "DecimalPlaces".ToUpper : Me.DecimalPlaces = CInt(udtSetting.Value)
                        Case "DataPath".ToUpper : gConfig.DataPath = udtSetting.Value
                        Case "DataFileSavePeriod".ToUpper : gConfig.DataFileSavePeriod = Val(udtSetting.Value)
                        Case "DataFileSaveUIDSynch".ToUpper : gConfig.DataFileSaveUIDSynch = CBool(udtSetting.Value)
                        Case "SpecFilesPath".ToUpper : gConfig.SpecFilesPath = udtSetting.Value
                        Case "SpecFilenameFormat".ToUpper : gConfig.SpecFilenameFormat = udtSetting.Value
                        Case "MESBatchFile".ToUpper : Me.MESBatchFile = udtSetting.Value
                        Case "OutputQAStartEndToMES".ToUpper : Me.OutputQAStartEndToMES = CBool(udtSetting.Value)
                        Case "DropIfReject".ToUpper : Me.DropIfReject = CBool(udtSetting.Value)
                        Case "PostSheetClearTime".ToUpper : Me.PostSheetClearTime = Val(udtSetting.Value) 'fjm, 2016-12-13
                        Case "MeasurementTimeout".ToUpper : Me.MeasurementTimeout = Val(udtSetting.Value)

                        Case "LastProductFile".ToUpper : Me.LastProductFile = udtSetting.Value
                        Case "LastPurpose".ToUpper : Me.LastPurpose = udtSetting.Value

                            'NOTE: Not using LastGlassRefIdx anymore...leoc
                            'Case "LastGlassRefIdx".ToUpper : Me.LastGlassRefIdx = Val(udtSetting.Value)

                        Case "LtgSensor".ToUpper

                            ' LTG sensor does not get re-read/initialized when in re-read mode...leoc
                            If optReRead = False Then
                                gLtgSensor = [Enum].Parse(GetType(enumLtgController), udtSetting.Value)
                                gLog.LogMsg(String.Format("Ltg Sensor={0}", gLtgSensor))
                                CreateLTG() ' create LTG sensor
                            Else
                                gLog.LogMsg("Not reading LtgSensor value from config file because re-read mode")
                            End If

                        Case "GlassEncoderResolution".ToUpper : If Not gLTG Is Nothing Then gLTG.EncoderResolution = CDbl(udtSetting.Value)
                        Case "InletLeadingEdge".ToUpper : Me.InletLeadingEdge = CBool(udtSetting.Value)

                        Case "IPAddress".ToUpper : clsInterface_LTG_KeyenceCL3000.IpAddress = udtSetting.Value
                        Case "IPPort".ToUpper : clsInterface_LTG_KeyenceCL3000.IpPort = udtSetting.Value

                        Case "PipeName".ToUpper : clsInterface_LTG_Precitec.PipeName = udtSetting.Value
                        Case "MinThickness".ToUpper : gLTG.MinThickness = Val(udtSetting.Value)
                        Case "MinIntensity".ToUpper : gLTG.MinIntensity = Val(udtSetting.Value)
                        Case "MinDistance".ToUpper : gLTG.MinDistance = Val(udtSetting.Value)
                        Case "MaxDistance".ToUpper : gLTG.MaxDistance = Val(udtSetting.Value)

                        Case "SheetStartMinConsectiveCount".ToUpper : gLTG.SheetStartMinConsectiveCount = Val(udtSetting.Value)
                        Case "SheetEndMinConsectiveCount".ToUpper : gLTG.SheetEndMinConsectiveCount = Val(udtSetting.Value)

                        Case "LTGTrim".ToUpper : gDP.LTGTrim = Val(udtSetting.Value)
                        Case "CalculatedQATrimEnabled".ToUpper : gConfig.CalculatedQATrimEnabled = CBool(udtSetting.Value)
                        Case "BadPointPercentDev".ToUpper : gDP.BadPointPercentDev = CDbl(udtSetting.Value)
                        Case "LTGEngineerOutput".ToUpper : Me.LTGEngineerOutput = CBool(udtSetting.Value)
                        Case "LTGEngineerOutputPath".ToUpper : Me.LTGEngineerOutputPath = FormatPath(udtSetting.Value)
                        Case "LastMeasurement".ToUpper : Me.LastMeasurement = CBool(udtSetting.Value)
                        Case "LastMeasurementPath".ToUpper : Me.LastMeasurementPath = FormatPath(udtSetting.Value)
                        Case "LTGMaxBadConsecutiveCnt".ToUpper : gDP.MaxBadConsecutiveCnt = CShort(udtSetting.Value)
                        Case "LTGMaxBadOverallCnt".ToUpper : gDP.MaxBadOverallCnt = CShort(udtSetting.Value)
                        Case "LTGReadDistance".ToUpper : gDP.ReadDistance = Val(udtSetting.Value)
                        Case "ThicknessGraphMax".ToUpper : Me.ThicknessGraphMax = Val(udtSetting.Value)
                        Case "ThicknessGraphMin".ToUpper : Me.ThicknessGraphMin = Val(udtSetting.Value)
                        Case "DistanceGraphMax".ToUpper : Me.DistanceGraphMax = Val(udtSetting.Value)
                        Case "DistanceGraphMin".ToUpper : Me.DistanceGraphMin = Val(udtSetting.Value)
                        Case "DistanceGraphInverted".ToUpper : Me.DistanceGraphInverted = CBool(udtSetting.Value)
                        Case "DistanceGraphLinearFitEnable".ToUpper : Me.DistanceGraphLinearFitEnable = CBool(udtSetting.Value)
                        Case "LTGSpecBinningEnable".ToUpper : Me.LTGSpecBinningEnable = CBool(udtSetting.Value)   '2017-02-28, fjm
                        Case "LTGSpecBinningDistance".ToUpper : Me.LTGSpecBinningDistance = Val(udtSetting.Value) '2017-02-28, fjm

                        Case "WidthRejectVisible".ToUpper : Me.WidthRejectVisible = CBool(udtSetting.Value)   'v1.1.18
                        Case "WidthRejectEnable".ToUpper : Me.WidthRejectEnable = CBool(udtSetting.Value)   'v1.1.18
                        Case "WidthRejectMin".ToUpper : Me.WidthRejectMin = Val(udtSetting.Value) 'v1.1.18
                        Case "WidthRejectMax".ToUpper : Me.WidthRejectMax = Val(udtSetting.Value) 'v1.1.18
                        Case "AppDispAndJudgeEnable".ToUpper : Me.AppDispAndJudgeEnable = CBool(udtSetting.Value)
                        Case "CalibrationStandard".ToUpper : gDP.CalibrationStandard = udtSetting.Value
                        Case "CalibrationGlassCode".ToUpper : gDP.CalibrationGlassCode = udtSetting.Value
                        Case "CalibrationGlassType".ToUpper : gDP.CalibrationGlassType = udtSetting.Value
                        Case "CalibrationGlassRefIdx".ToUpper : gDP.CalibrationGlassRefIdx = Val(udtSetting.Value)
                        Case "IdxRefLookupIntervalSecs".ToUpper : Me.IdxRefLookupIntervalSecs = CInt(udtSetting.Value)
#Region "Filtering"
                        Case "FilterMedianWindowEnable".ToUpper : Me.FilterMedianWindowEnable = CBool(udtSetting.Value)
                        Case "FilterMedianWindowWindowSize".ToUpper : Me.FilterMedianWindowWindowSize = Val(udtSetting.Value)

#End Region

#Region "Savitzky Golay filter"
                        'Savitzky Golay filterenabled
                        Case "LTGSavitzkyGolayFilterEnabled".ToUpper : Me.SGFilterEnabled = CBool(udtSetting.Value)
                        'filterWindowSize
                        Case "LTGSavitzkyGolayWindowSize".ToUpper : Me.SGWindowSize = Val(udtSetting.Value)
#End Region



#Region "OPC Interface"
                        Case "OPCServerName".ToUpper : gOPC.OPCServerName = udtSetting.Value
                        Case "OPCPollTime".ToUpper : gOPC.OPCPollTime = udtSetting.Value
                        Case "OPCItem_ToGauge_BornDateYear".ToUpper : gOPC.OPCItem_ToGauge_BornDateYear = udtSetting.Value
                        Case "OPCItem_ToGauge_BornDateMonth".ToUpper : gOPC.OPCItem_ToGauge_BornDateMonth = udtSetting.Value
                        Case "OPCItem_ToGauge_BornDateDay".ToUpper : gOPC.OPCItem_ToGauge_BornDateDay = udtSetting.Value
                        Case "OPCItem_ToGauge_BornTimeHour".ToUpper : gOPC.OPCItem_ToGauge_BornTimeHour = udtSetting.Value
                        Case "OPCItem_ToGauge_BornTimeMinute".ToUpper : gOPC.OPCItem_ToGauge_BornTimeMinute = udtSetting.Value
                        Case "OPCItem_ToGauge_BornTimeSecond".ToUpper : gOPC.OPCItem_ToGauge_BornTimeSecond = udtSetting.Value
                        Case "OPCItem_ToGauge_UID".ToUpper : gOPC.OPCItem_ToGauge_UID = udtSetting.Value
                        Case "OPCItem_FromGauge_UID".ToUpper : gOPC.OPCItem_FromGauge_UID = udtSetting.Value
                        Case "OPCItem_FromGauge_DataReceived".ToUpper : gOPC.OPCItem_FromGauge_DataReceived = udtSetting.Value
                        Case "OPCItem_FromGauge_Defects1".ToUpper : gOPC.OPCItem_FromGauge_Defects1 = udtSetting.Value
                        Case "OPCItem_FromGauge_InspectionValid".ToUpper : gOPC.OPCItem_FromGauge_InspectionValid = udtSetting.Value
                        Case "OPCItem_FromGauge_SensorIdxRef".ToUpper : gOPC.OPCItem_FromGauge_SensorIdxRef = udtSetting.Value
                        Case "OPCItem_FromGauge_MeasuredWidth".ToUpper : gOPC.OPCItem_FromGauge_MeasuredWidth = udtSetting.Value
                        Case "OPCItem_WriteHeartbeat".ToUpper : gOPC.OPCItem_WriteHeartbeat = udtSetting.Value
                        Case "WriteHeartbeatPeriod".ToUpper : gOPC.WriteHeartbeatPeriod = Val(udtSetting.Value)



                        Case "OPCItem_FromGauge_Max".ToUpper : gOPC.OPCItem_FromGauge_Max = udtSetting.Value
                        Case "OPCItem_FromGauge_Min".ToUpper : gOPC.OPCItem_FromGauge_Min = udtSetting.Value
                        Case "OPCItem_FromGauge_Average".ToUpper : gOPC.OPCItem_FromGauge_Average = udtSetting.Value
                        Case "OPCItem_FromGauge_75mmMWR".ToUpper : gOPC.OPCItem_FromGauge_75mmMWR = udtSetting.Value
                        Case "PostMeasurementOPCActive".ToUpper : gOPC.PostMeasurementOPCActive = CBool(udtSetting.Value)



#End Region

#Region "Pi Interface"
                        Case "PiImportFileEnable".ToUpper : gPi.PiImportFileEnable = CBool(udtSetting.Value)
                        Case "PiImportFilePath".ToUpper : gPi.PiImportFilePath = FormatPath(udtSetting.Value)
                        Case "PiImportFilePeriod".ToUpper : gPi.PiImportFilePeriod = Val(udtSetting.Value)

                        Case Else
                            If udtSetting.Name.StartsWith("DisplacementPiTag".ToUpper) Then
                                'Get Position Value
                                Dim iPosition As Integer = Val(udtSetting.Name.Substring("DisplacementPiTag".Length))
                                gPi.DisplacementPiTag(iPosition) = udtSetting.Value
                            Else
                                gLog.LogErr(strFile & ", Unknown setting: " & strLine)
                            End If
#End Region

                    End Select
                End If


            End While

            'Close File
            FileClose(hndFile)

            'Log Message
            gLog.LogMsg("Read Configuration File: " & strFile)

            'If No Error then success
            If errReturn <> enumError.errFailure Then
                errReturn = enumError.errSuccess
            End If

        Catch ex As Exception
            errReturn = enumError.errFailure

            'Display and Log Error Message
            Dim strMsg As String = "Error Reading Configuration File: " & strFile & vbCr _
                & "Error: " & Err.Description _
                & IIf(strLine.Length > 0, vbCr & "Last Line: " & strLine, "")
            MsgBox(strMsg & vbCr & Err.Description, MsgBoxStyle.Critical, "Configuration File Error!")

            gLog.LogErr(strMsg)
        Finally
            'Close File
            FileClose(hndFile)
        End Try

        Return errReturn
    End Function



    Public Sub SaveConfig()
        Dim hndFile As Short
        Dim strFile As String = String.Empty

        Try
            'Open File
            Dim sAppName As String = My.Application.Info.AssemblyName
            hndFile = FreeFile()
            strFile = FormatPath(gstrCurDir & cPathConfig) & sAppName & cFileExtConfig
            FileOpen(hndFile, strFile, OpenMode.Output)

            'Write Data
            PrintLine(hndFile, ";***************** General *******************")
            PrintLine(hndFile, "GaugeName=" & Me.GaugeName)
            PrintLine(hndFile, "GaugeID=" & Me.GaugeID)
            PrintLine(hndFile, "TankID=" & Me.TankID)
            PrintLine(hndFile, "BOD_ID=" & Me.BODID)
            PrintLine(hndFile, "DebugLevel=" & gLog.DebugLevel)
            PrintLine(hndFile, "LogDuration=" & gLog.LogDuration)
            PrintLine(hndFile, "adminpw=" & Me.AdminPW)
            PrintLine(hndFile, "")
            PrintLine(hndFile, "DataPath=" & gConfig.DataPath)
            PrintLine(hndFile, "DataFileSavePeriod=" & gConfig.DataFileSavePeriod.ToString("0"))
            PrintLine(hndFile, "DataFileSaveUIDSynch=" & gConfig.DataFileSaveUIDSynch.ToString())
            PrintLine(hndFile, "SpecFilesPath=" & gConfig.SpecFilesPath)
            PrintLine(hndFile, "SpecFilenameFormat=" & gConfig.SpecFilenameFormat)
            PrintLine(hndFile, "MESBatchFile=" & Me.MESBatchFile)
            PrintLine(hndFile, "OutputQAStartEndToMES=" & Me.OutputQAStartEndToMES.ToString)
            PrintLine(hndFile, "DropIfReject=" & Me.DropIfReject.ToString)
            PrintLine(hndFile, "PostSheetClearTime=" & Me.PostSheetClearTime.ToString("0"))
            PrintLine(hndFile, "MeasurementTimeout=" & Me.MeasurementTimeout.ToString("0.0"))
            PrintLine(hndFile, "DecimalPlaces=" & Me.DecimalPlaces.ToString("0"))
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Last Product *************")
            PrintLine(hndFile, "LastProductFile=" & Me.LastProductFile)
            PrintLine(hndFile, "LastPurpose=" & Me.LastPurpose)

            'NOTE: Not using LastGalssRefIdx anymore...leoc
            'PrintLine(hndFile, "LastGlassRefIdx=" & Me.LastGlassRefIdx.ToString("0.00000"))

            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** LTG Sensor ***************")
            PrintLine(hndFile, "LTGSensor=" & gLtgSensor.ToString())
            PrintLine(hndFile, "PipeName=" & clsInterface_LTG_Precitec.PipeName)
            PrintLine(hndFile, "IPAddress=" & clsInterface_LTG_KeyenceCL3000.IpAddress)
            PrintLine(hndFile, "IPPort=" & clsInterface_LTG_KeyenceCL3000.IpPort)

            PrintLine(hndFile, "MinThickness=" & gLTG.MinThickness.ToString("0.0000"))
            PrintLine(hndFile, "MinIntensity=" & gLTG.MinIntensity.ToString("0.00"))
            PrintLine(hndFile, "MinDistance=" & gLTG.MinDistance.ToString("0.00"))
            PrintLine(hndFile, "MaxDistance=" & gLTG.MaxDistance.ToString("0.00"))

            PrintLine(hndFile, "SheetStartMinConsectiveCount=" & gLTG.SheetStartMinConsectiveCount.ToString("0"))
            PrintLine(hndFile, "SheetEndMinConsectiveCount=" & gLTG.SheetEndMinConsectiveCount.ToString("0"))
            PrintLine(hndFile, "IdxRefLookupIntervalSecs=" & Me.IdxRefLookupIntervalSecs.ToString("0"))

            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Encoder ******************")
            PrintLine(hndFile, "InletLeadingEdge=" & Me.InletLeadingEdge.ToString)
            PrintLine(hndFile, "GlassEncoderResolution=" & gLTG.EncoderResolution.ToString("0.000000"))
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** LTG Processing ***********")
            PrintLine(hndFile, "LTGTrim=" & gDP.LTGTrim.ToString("0.00"))
            PrintLine(hndFile, "CalculatedQATrimEnabled=" & gConfig.CalculatedQATrimEnabled.ToString)
            PrintLine(hndFile, "BadPointPercentDev=" & gDP.BadPointPercentDev.ToString("0.00"))
            PrintLine(hndFile, "LTGEngineerOutput=" & Me.LTGEngineerOutput.ToString)
            PrintLine(hndFile, "LTGEngineerOutputPath=" & Me.LTGEngineerOutputPath.ToString)
            PrintLine(hndFile, "LastMeasurement=" & Me.LastMeasurement.ToString)
            PrintLine(hndFile, "LastMeasurementPath=" & Me.LastMeasurementPath.ToString)
            PrintLine(hndFile, "LTGMaxBadConsecutiveCnt=" & gDP.MaxBadConsecutiveCnt.ToString)
            PrintLine(hndFile, "LTGMaxBadOverallCnt=" & gDP.MaxBadOverallCnt.ToString)
            PrintLine(hndFile, "LTGReadDistance=" & gDP.ReadDistance.ToString("0.000"))
            PrintLine(hndFile, "ThicknessGraphMax=" & Me.ThicknessGraphMax.ToString)
            PrintLine(hndFile, "ThicknessGraphMin=" & Me.ThicknessGraphMin.ToString)
            PrintLine(hndFile, "DistanceGraphMax=" & Me.DistanceGraphMax.ToString)
            PrintLine(hndFile, "DistanceGraphMin=" & Me.DistanceGraphMin.ToString)
            PrintLine(hndFile, "DistanceGraphInverted=" & Me.DistanceGraphInverted.ToString)
            PrintLine(hndFile, "DistanceGraphLinearFitEnable=" & Me.DistanceGraphLinearFitEnable.ToString)
            PrintLine(hndFile, "LTGSpecBinningEnable=" & Me.LTGSpecBinningEnable.ToString)                '2017-02-28, fjm
            PrintLine(hndFile, "LTGSpecBinningDistance=" & Me.LTGSpecBinningDistance.ToString("0.000"))   '2017-02-28, fjm
            PrintLine(hndFile, "AppDispAndJudgeEnable=" & Me.AppDispAndJudgeEnable.ToString)
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Width Reject **************")
            PrintLine(hndFile, "WidthRejectVisible=" & Me.WidthRejectVisible.ToString)
            PrintLine(hndFile, "WidthRejectEnable=" & Me.WidthRejectEnable.ToString)
            PrintLine(hndFile, "WidthRejectMin=" & Me.WidthRejectMin.ToString("0.000"))
            PrintLine(hndFile, "WidthRejectMax=" & Me.WidthRejectMax.ToString("0.000"))
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Calibration **************")
            PrintLine(hndFile, "CalibrationStandard=" & gDP.CalibrationStandard.ToString)
            PrintLine(hndFile, "CalibrationGlassCode=" & gDP.CalibrationGlassCode.ToString)
            PrintLine(hndFile, "CalibrationGlassType=" & gDP.CalibrationGlassType.ToString)
            PrintLine(hndFile, "CalibrationGlassRefIdx=" & gDP.CalibrationGlassRefIdx.ToString)
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Filtering **************")
            PrintLine(hndFile, "FilterMedianWindowEnable=" & Me.FilterMedianWindowEnable.ToString)
            PrintLine(hndFile, "FilterMedianWindowWindowSize=" & Me.FilterMedianWindowWindowSize.ToString("0"))
            PrintLine(hndFile, "")

            PrintLine(hndFile, ";********** Savitzky Golay Filter **********")
            'Savitzky Golay filter
            PrintLine(hndFile, "LTGSavitzkyGolayFilterEnabled=" & gConfig.SGFilterEnabled.ToString())
            'filterWindowSize
            PrintLine(hndFile, "LTGSavitzkyGolayWindowSize=" & gConfig.SGWindowSize.ToString())
            'Savitzky Golay filterenabled



            PrintLine(hndFile, "")

            PrintLine(hndFile, ";****************** PLC OPC Server ***********")
            PrintLine(hndFile, "OPCServerName=" & gOPC.OPCServerName)
            PrintLine(hndFile, "OPCPollTime=" & gOPC.OPCPollTime)
            PrintLine(hndFile, "OPCItem_ToGauge_BornDateYear=" & gOPC.OPCItem_ToGauge_BornDateYear)
            PrintLine(hndFile, "OPCItem_ToGauge_BornDateMonth=" & gOPC.OPCItem_ToGauge_BornDateMonth)
            PrintLine(hndFile, "OPCItem_ToGauge_BornDateDay=" & gOPC.OPCItem_ToGauge_BornDateDay)
            PrintLine(hndFile, "OPCItem_ToGauge_BornTimeHour=" & gOPC.OPCItem_ToGauge_BornTimeHour)
            PrintLine(hndFile, "OPCItem_ToGauge_BornTimeMinute=" & gOPC.OPCItem_ToGauge_BornTimeMinute)
            PrintLine(hndFile, "OPCItem_ToGauge_BornTimeSecond=" & gOPC.OPCItem_ToGauge_BornTimeSecond)
            PrintLine(hndFile, "OPCItem_ToGauge_UID=" & gOPC.OPCItem_ToGauge_UID)
            PrintLine(hndFile, "OPCItem_FromGauge_UID=" & gOPC.OPCItem_FromGauge_UID)
            PrintLine(hndFile, "OPCItem_FromGauge_DataReceived=" & gOPC.OPCItem_FromGauge_DataReceived)
            PrintLine(hndFile, "OPCItem_FromGauge_Defects1=" & gOPC.OPCItem_FromGauge_Defects1)
            PrintLine(hndFile, "OPCItem_FromGauge_InspectionValid=" & gOPC.OPCItem_FromGauge_InspectionValid)
            PrintLine(hndFile, "OPCItem_FromGauge_SensorIdxRef=" & gOPC.OPCItem_FromGauge_SensorIdxRef)
            PrintLine(hndFile, "OPCItem_FromGauge_MeasuredWidth=" & gOPC.OPCItem_FromGauge_MeasuredWidth)
            PrintLine(hndFile, "OPCItem_WriteHeartbeat=" & gOPC.OPCItem_WriteHeartbeat)
            PrintLine(hndFile, "WriteHeartbeatPeriod=" & gOPC.WriteHeartbeatPeriod.ToString("0"))



            PrintLine(hndFile, "OPCItem_FromGauge_Max=" & gOPC.OPCItem_FromGauge_Max)
            PrintLine(hndFile, "OPCItem_FromGauge_Min=" & gOPC.OPCItem_FromGauge_Min)
            PrintLine(hndFile, "OPCItem_FromGauge_Average=" & gOPC.OPCItem_FromGauge_Average)
            PrintLine(hndFile, "OPCItem_FromGauge_75mmMWR=" & gOPC.OPCItem_FromGauge_75mmMWR)
            PrintLine(hndFile, "PostMeasurementOPCActive=" & gOPC.PostMeasurementOPCActive.ToString)



            PrintLine(hndFile, ";*********************************************")
            PrintLine(hndFile, "")
            PrintLine(hndFile, ";****************** Pi Import File  ***********")
            PrintLine(hndFile, "PiImportFileEnable=" & gPi.PiImportFileEnable.ToString)
            PrintLine(hndFile, "PiImportFilePath=" & gPi.PiImportFilePath.ToString)
            PrintLine(hndFile, "PiImportFilePeriod=" & gPi.PiImportFilePeriod.ToString("0"))
            For i As Integer = 0 To clsInterface_Pi.cDisplacementPiTagUpperBound
                PrintLine(hndFile, String.Format("DisplacementPiTag{0}={1}", i, gPi.DisplacementPiTag(i)))
            Next
        Catch ex As Exception
            Dim strMsg As String

            'Display and Log Error Message
            strMsg = "Error Saving Configuration File: " & strFile
            MsgBox(strMsg & vbCr & ex.Message, MsgBoxStyle.Critical, "Configuration File Error!")

            gLog.LogErr(strMsg & ", Error: " & ex.Message)
        Finally
            'Close File
            FileClose(hndFile)
        End Try
    End Sub

    Public Sub GetDll()
        Dim strLine As String
        Dim hndFile As Short
        Dim strFile As String

        On Error GoTo ErrorHandler

        'Initialize Variables

        'Open File
        hndFile = FreeFile()
        strFile = gstrCurDir & Me.Dll
        FileOpen(hndFile, strFile, OpenMode.Input)

        'Read Line and Trim Spaces
        strLine = LineInput(hndFile)
        strLine = Trim(strLine)
        Me.Dll = strLine

        'Close File
        FileClose(hndFile)

        Exit Sub
ErrorHandler:
        'Close File
        FileClose(hndFile)
    End Sub

    '*************************************************************
    'Check Admin Password
    Public Function CheckAdminPW(ByRef strPassword As String) As Boolean
        Me.LastPassword = strPassword
        If ((strPassword = Me.AdminPW) Or (strPassword = Me.Dll)) Then
            CheckAdminPW = True
        Else
            MsgBox("Invalid Password!", MsgBoxStyle.Critical, "Password")
            CheckAdminPW = False
        End If
    End Function

    '*************************************************************
    'This function logs any change in data and returns the changed value
    Public Function CheckDataChange(ByRef strSetting As String, ByVal strValue As String, ByVal strParameter As String) As String
        Dim hndFile As Short
        Dim strFile As String

        'If value has changed...
        If strSetting <> strValue Then
            'Initialize Variables
            hndFile = FreeFile()
            strFile = FormatPath(gstrCurDir & cPathLog) & cFileParameterLog

            'Open Log File
            FileOpen(hndFile, strFile, OpenMode.Append)
            PrintLine(hndFile, Now.ToString(cFormatDateTime) & " - " & strParameter & " - Old:" & strSetting & " - New:" & strValue)

            'Close log file
            FileClose(hndFile)

        End If
        CheckDataChange = strValue
    End Function

End Class