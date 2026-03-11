Option Strict Off
Option Explicit On

Module mdlGeneral
    '***************************************************************
    '
    'Module:    mdlGeneral.bas
    '
    'Description:   This module contains global variables for the application.
    '               Also, common functions are also found here.
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
    '09/01/08   fjm         Converted to VB.Net 2008
    '2009-12-17 fjm         Added Thickness sensor
    '2010-07-14 dld         Added ME Thickness Sensor Option 
    '2016-09-21 fjm         Created for CEOLTG
    '***************************************************************

#Region "DLL declarations"
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpApplicationName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
#End Region

#Region "User Defined Types"
    Public Structure typSetting
        Dim Name As String
        Dim Value As String
    End Structure

    Public Structure typProduct
        Dim TankID As String
        Dim FormingDateTime As Date
        Dim ProductCode As String
        Dim GlassCode As String
        Dim NumberOfZones As Long
    End Structure
#End Region

#Region "Enuermations"
    'Public Enum enumError
    '    errNone = 0
    '    errSuccess
    '    errFailure
    'End Enum
    Enum enumLtgController
        precitec = 0
        keyenceCl3000 = 1
    End Enum

    Enum enum3States
        stateNA = 0 'NA = Not Applicable
        stateNo = 1
        stateYes = 2
    End Enum

    Enum enumDAQMode
        'daqNone = -1
        daqIdle = 0
        daqSheet
        daqStandard
        daqSlideProfile
        daqHardware
    End Enum

    Enum enumMessageType
        Incoming
        Outgoing
    End Enum

    Enum enumGaugeState
        gsIdle = 0
        gsSheet
        gsHardwareCheck
        gsLTGRunVerification
    End Enum

    Enum enumSubState
        ssIdle = 0
        ssStart
        ssWaitForSheet
        ssCollectingData
        ssProcessingData
        ssPostSheetClear
    End Enum

    Enum enumGrading
        gdNotGraded = -1
        gdFail = 0
        gdPass = 1
    End Enum

    Enum enumJobHeightInit
        ghNoMove = 0
        ghProduct
        ghHome
    End Enum

    Public Enum enumLaserMode
        lsrNone = -1
        lsrMonitor = 0
        lsrCollectData

    End Enum
    Public Enum enumError
        errNone = 0
        errSuccess
        errFailure
    End Enum
#End Region

#Region "Constants"
    Public Const cDebugPath As String = "c:\debug\CEOLTG\"

    Public Const cFileParameterLog As String = "ParameterChange.log"
    Public Const cFileDll As String = "CEOLTG.dll"
    Public Const cFileExtConfig As String = ".cfg"
    Public Const cFileExtProductSave As String = ".prd"
    Public Const cFileLastProduct As String = "LastProduct.cfg"
    Public Const cPathConfig As String = "Config\"
    Public Const cPathLog As String = "Log\"
    Public Const cFileGlassIndex As String = "GlassIndex.ini"

    Public Const cFormatDateTime As String = "yyyy-MM-dd HH:mm"
    Public cFormatLTGThickness As String = "0.00000"
    Public cFormatQAThickness As String = "0.0000"

    Public Const cGray As Integer = -2147483644
#End Region

#Region "Globals"
    Public gblnDebug As Boolean

    Public gOperations As frmOperations = Nothing
    Public gDP As clsDP_LTG = Nothing
    Public gOPC As clsInterface_PLC = Nothing
    Public gSpec As CorningMes.Data.Specs.Spec = Nothing
    Public gPi As clsInterface_Pi = Nothing

    'info
    '
    Public gstrCurDir As String
    Public gstrLastDir As String
    Public gLog As clsLogger
    Public gConfig As clsFile_Config
    Public gLTG As clsInterface_LTG

    Public gblnMeasurementEnabled As Boolean = False
    Public gState As enumGaugeState         'Gauge State
    Public gSubState As enumSubState 'Gauge Substate
    Public gLastSubState As enumSubState 'Last Gauge Substate
    Public gfrmProcessing As New frmProcessing
    Public gdtProcessingStart As Date       'Used on Processing form
    Public gdtProcessingStepStart As Date   'Used on Processing form
    Public gfrmMaint As frmMaintenance
    Public prevVerFileName As String = ""

    Public thicknessArray As Double() = {}
    Public positionArray As Double() = {}
    Public gLtgSensor As enumLtgController = enumLtgController.precitec

    Public gReReadRequested As Boolean = False      'New variable 3/3/26 to tell state machine to re-read config when appropriate...leoc
#End Region

    'This subroutine initializes the application
    Public Function ApplicationInit() As enumError
        Dim errReturn As enumError = enumError.errNone
        Dim strObject As String = ""

        Try
            'Get Command Line parameters
            If InStr(UCase(Microsoft.VisualBasic.Command()), "/DEBUG") Then
                gblnDebug = True
            Else
                gblnDebug = False
            End If

            'Instantiate Objects
            gLog = New clsLogger
            gfrmMaint = New frmMaintenance
            gOperations = New frmOperations
            gOPC = New clsInterface_PLC
            gPi = New clsInterface_Pi  'fjm, 2017-01-12

            strObject = "clsInterface_LTG"
            'Select Case gLtgSensor
            '    Case enumLtgController.KeyenceCl3000
            '        gLTG = New clsInterface_LTG_KeyenceCL3000
            '    Case enumLtgController.precitec
            '        gLTG = New clsInterface_LTG_Precitec
            'End Select

            strObject = "clsDP_LTG"
            gDP = New clsDP_LTG

            strObject = "clsFile_Config"
            gConfig = New clsFile_Config

            'Clear Object info
            strObject = ""

            'Get Current Directory
            If gblnDebug Then
                gstrCurDir = cDebugPath
            Else
                gstrCurDir = My.Application.Info.DirectoryPath
            End If
            gstrCurDir = FormatPath(gstrCurDir)

            'Initialize last directory
            gstrLastDir = gstrCurDir

            'Create Subdirectories
            CreateDirectory(gstrCurDir & cPathConfig)
            ' CreateDirectory(gstrCurDir & cPathMES)

            'Display Start Message
            'Added Version, fjm, 2009-11-12
            gLog.LogMsg("*************************************")
            gLog.LogMsg(My.Application.Info.AssemblyName _
                & " v" & My.Application.Info.Version.Major _
                & "." & My.Application.Info.Version.Minor _
                & "." & My.Application.Info.Version.Build & " Application Started!")

            Dim processes() As System.Diagnostics.Process = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)
            If processes IsNot Nothing AndAlso processes.Length > 1 Then
                gLog.LogMsg(String.Format("{0} copies of '{1}' already running!", processes.Length - 1, Process.GetCurrentProcess.ProcessName))
                MsgBox("SOLTG already running.  Ending.")
                End
            End If

            'Read Configuration
            If gConfig.ReadConfig() <> enumError.errSuccess Then
                errReturn = enumError.errFailure
            Else
                InitGauge()
            End If



            'If No Error then success
            If errReturn <> enumError.errFailure Then
                errReturn = enumError.errSuccess
            End If

            Return errReturn
        Catch ex As Exception
            Dim strMsg As String = My.Application.Info.ProductName & " initialization error." & vbCr _
                & "Error = " & ex.Message & vbCr _
                & IIf(strObject <> "", "Object=" & strObject & vbCr, "") _
                & "Application Closing."

            MsgBox(strMsg, MsgBoxStyle.Critical, My.Application.Info.ProductName)
            If Not gLog Is Nothing Then
                gLog.LogErr("mdlGeneral.ApplicaitonInit(), " & strMsg)
            End If

            Return enumError.errFailure
        End Try
    End Function

    Public Sub InitGauge()
        'Select Case gLtgSensor
        '    Case enumLtgController.keyenceCl3000
        '        gLTG = New clsInterface_LTG_KeyenceCL3000
        '    Case enumLtgController.precitec
        '        gLTG = New clsInterface_LTG_Precitec
        'End Select
        'Log Gauge ID after reading config, fjm, 2009-11-19
        gLog.LogMsg("GaugeID=" & gConfig.GaugeID)

        'Create Tank Directory if doesn't exist
        CreateDirectory(gConfig.DataPath)
        CreateDirectory(gConfig.SpecFilesPath)
        If gPi.PiImportFileEnable Then
            CreateDirectory(gPi.PiImportFilePath)
        End If

        'Clear Processing Times
        gdtProcessingStart = New Date(0)
        gdtProcessingStepStart = New Date(0)

        'Initialize LTG Communications
        gLog.LogDebug(9, "gLTG.Connect()")
        gLTG.Connect()


        cFormatLTGThickness = ("0." & StrDup(gConfig.DecimalPlaces, "0"c))
        cFormatQAThickness = ("0." & StrDup(gConfig.DecimalPlaces, "0"c))

        'Set Gauge State
        gState = enumGaugeState.gsIdle
    End Sub

    Public Sub CreateLTG()
        If Not gLTG Is Nothing Then
            gLTG.Disconnect()
            gLTG = Nothing
        End If

        Select Case gLtgSensor
            Case enumLtgController.keyenceCl3000
                gLTG = New clsInterface_LTG_KeyenceCL3000
            Case enumLtgController.precitec
                gLTG = New clsInterface_LTG_Precitec
        End Select
    End Sub

    Public Sub ApplicationExit()
        Try

            'Display Start Message
            If Not gLog Is Nothing Then
                gLog.LogMsg(My.Application.Info.AssemblyName & " Application Stopped!")
                gLog.LogMsg("*************************************")
            End If

            'gOPC.Disconnect()
            'Destroy Objects
            gDP = Nothing
            gPi = Nothing

            If Not gLTG Is Nothing Then
                gLTG.Disconnect()
                gLTG = Nothing
            End If

            ' gGauge = Nothing
            gConfig = Nothing           'Do the 2nd to last
            gLog.ThreadExit = True
            gLog = Nothing              'Do this last

        Catch ex As Exception
            gLog.ThreadExit = True

        End Try
    End Sub


    '***************************************************************
    'This subroutine displays the Gauge Processing Form
    Public Sub ShowProcessing(ByRef strMsg As String)
        ' On Error Resume Next

        'Show Message
        gfrmProcessing.txtStatus.Text = strMsg

        'Capture Start Time if not defined
        If gdtProcessingStart = New Date(0) Then
            gdtProcessingStart = Now
            'gdtProcessingStepStart = Now
        End If

        'Display Processing Time and Step Time
        gfrmProcessing.txtElapsedTime.Text = Now.Subtract(gdtProcessingStart).TotalSeconds.ToString("0.0")
        'gLog.LogMsg("elapsed time " & gfrmProcessing.txtElapsedTime.Text)
        'gfrmProcessing.txtStepTime.Text = Now.Subtract(gdtProcessingStepStart).TotalSeconds.ToString("0.0")

        'Capture Step Start
        'gdtProcessingStepStart = Now

        'Show Form
        gfrmProcessing.Show()
        gfrmProcessing.Update()

    End Sub

    '***************************************************************
    'This subroutine hides the Gauge Processing Form
    Public Sub HideProcessing()
        gdtProcessingStart = New Date(0)
        gdtProcessingStepStart = New Date(0)
        gfrmProcessing.Hide()
    End Sub

    '***************************************************************
    'This subroutine checks the contrast graph Y Axis Max Value
    'It does not allow the Graph to Auto Scale Below the defined constant
    Public Sub CheckYAxisScale(ByRef objGraph As NationalInstruments.UI.WindowsForms.ScatterGraph, ByRef dblScaleMin As Double, Optional ByRef blnSetMin As Boolean = False)

        With objGraph
            Dim dRangeMin As Double = 0
            Dim dRangeMax As Double = 0
            Dim dTempValue As Double = 0

            dTempValue = .YAxes.Item(0).Range.Maximum
            dRangeMax = CInt(dTempValue)

            'If Set Min enabled check Max and Min
            If blnSetMin Then
                'Check Scale Maximum and Minimum against
                If .YAxes.Item(0).Range.Maximum < dblScaleMin And .YAxes.Item(0).Range.Minimum > -dblScaleMin Then
                    .YAxes.Item(0).Mode = AxisMode.Fixed
                    dRangeMin = CInt(-dblScaleMin)
                    dRangeMax = CInt(dblScaleMin)

                    'Set Y Axis Range
                    .YAxes.Item(0).Range = New Range(dRangeMin, dRangeMax)
                    .Refresh()
                End If

            Else
                'Check Scale Maximum against
                If .YAxes.Item(0).Range.Maximum < dblScaleMin Then
                    dRangeMin = 0
                    dRangeMax = dblScaleMin

                    'Set Y Axis Range
                    .YAxes.Item(0).Range = New Range(dRangeMin, dRangeMax)
                    .Refresh()
                End If
            End If

        End With

    End Sub

    '***************************************************************
    'This subroutine sets the contrast graph X Axis Values
    Public Sub SetXAxisScale(ByRef objGraph As NationalInstruments.UI.WindowsForms.ScatterGraph, ByRef dblSize As Double)

        Dim dblScaleMax As Double

        If dblSize Mod 100 > 0 Then
            dblScaleMax = (Int(dblSize / 100) + 1) * 100
        Else
            dblScaleMax = dblSize
        End If

        With objGraph
            ''Turn off Auto Scale
            ''.Axes.Item(1).AutoScale = False
            '.XAxes.Item(0).Mode = AxisMode.Fixed
            ''.Axes.Item(1).Maximum = dblScaleMax
            ''.Axes.Item(1).Minimum = 0
            '.XAxes.Item(0).Range = New Range(0, dblScaleMax)
            '.XAxes.Item(0).MajorDivisions.Base = 200
            '.XAxes.Item(0).MajorDivisions.Interval = 4
            '.Refresh()
        End With
    End Sub

    'This subroutine issues a gauge stop.
    'The DAQ is stopped and State set to Idle
    Public Sub GaugeStop()
        gLTG.SetMode(enumLaserMode.lsrNone)
        gLTG.Disconnect()

        'Set Gauge to Idle
        SetGaugeState(enumGaugeState.gsIdle)
    End Sub

    'This function returns the Gauge State as Text
    'Return the passed state, not the current gauge state, fjm, 9/2/03
    Public Function GetGaugeState(ByRef intState As enumGaugeState) As String
        'Dim strState As String

        'Based On Gauge State

        'Return State as Text
        GetGaugeState = intState.ToString().Remove(0, 2)
    End Function

    Public Function SetGaugeState(ByVal gsNewState As enumGaugeState) As enumError
        'Try
        Dim errReturn As enumError

        On Error Resume Next

        'Dim newReportableReadyState As ReportableReadyState = ReportableReadyState.NotReady
        'Dim newReportableRunState As ReportableRunState = ReportableRunState.Stopped

        'Initialize Variables
        errReturn = enumError.errNone

        ''Clear Any Previous Erros
        'If gsNewState <> enumGaugeState.gsIdle Then
        '    gLTG.LastError = ""
        'End If

        If gsNewState = enumGaugeState.gsIdle Then
            gSubState = enumSubState.ssIdle

            ' newReportableRunState = ReportableRunState.Stopped

        ElseIf gsNewState = enumGaugeState.gsSheet Then
            gLog.LogMsg("Gauge State:  gSheet")
            'newReportableRunState = ReportableRunState.Running
            'newReportableReadyState = ReportableReadyState.Ready

        ElseIf gsNewState = enumGaugeState.gsHardwareCheck Then
            'newReportableReadyState = ReportableReadyState.NotReady
            ' newReportableRunState = ReportableRunState.Stopped

        ElseIf gsNewState = enumGaugeState.gsLTGRunVerification Then
            gLog.LogMsg("Gauge State:  " & GetGaugeState(gsNewState))
            'newReportableReadyState = ReportableReadyState.NotReady
            'newReportableRunState = ReportableRunState.Stopped


        ElseIf gState <> enumGaugeState.gsIdle Then 'Gauge must be Idle
            errReturn = enumError.errFailure
            gLog.LogMsg("Gauge State not Idle, Desired State: " & GetGaugeState(gsNewState))
        End If
        'If No Error then Success
        If errReturn <> enumError.errFailure Then
            'Success, set gauge state after handling SLD's, 
            errReturn = enumError.errSuccess
            Dim stateChangeFlag As Boolean = False
            If gsNewState <> gState Then
                stateChangeFlag = True
            End If

            gState = gsNewState

            If stateChangeFlag Then
                gLog.LogMsg("Gauge State set to: " & GetGaugeState(gsNewState))
            End If



        Else
            'Set Gauge State to Idle, 
            gState = enumGaugeState.gsIdle
        End If

        gSubState = enumSubState.ssIdle

        'Return Status
        SetGaugeState = errReturn


    End Function



    '***************************************************************
    'This function parses the setting into Name and Value
    Public Function GetSetting(ByVal strEntry As String) As typSetting
        Dim intTok As Short

        GetSetting.Name = String.Empty
        GetSetting.Value = 0

        'Locate delimiter
        intTok = InStr(strEntry, "=")

        If intTok > 0 Then
            'Parse Name and Value
            GetSetting.Name = Trim(UCase(Left(strEntry, intTok - 1)))
            strEntry = Right(strEntry, Len(strEntry) - intTok)

            'Check for Comment at end of value
            intTok = InStr(strEntry, ";")
            If intTok > 0 Then
                GetSetting.Value = Trim(Left(strEntry, intTok - 1))
            Else
                GetSetting.Value = Trim(strEntry)
            End If
        Else
            GetSetting.Name = String.Empty
        End If
    End Function

    '***************************************************************
    'This function formats the path statement
    'The path should be terminated with "\" when appending a file
    Public Function FormatPath(ByRef strPath As String) As String
        If Right(strPath, 1) <> "\" Then
            strPath = strPath & "\"
        End If
        FormatPath = strPath
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RunBatch(ByRef strFile As String) As enumError
        Dim errReturn As enumError

        On Error GoTo ErrorHandler

        'Initialize Variables
        errReturn = enumError.errNone

        'Run Batch
        Shell(strFile, AppWinStyle.MinimizedNoFocus)

        'If no error, then success
        If errReturn <> enumError.errFailure Then
            errReturn = enumError.errSuccess
        End If

        'Return Status
        RunBatch = errReturn
        Exit Function
ErrorHandler:
        errReturn = enumError.errFailure

        'Log Message
        gLog.LogErr("RunBatch( " & strFile & " ), " & Err.Description)

        'Return Status
        RunBatch = errReturn
    End Function

    '***************************************************************
    'This function formats the width of the string
    Public Function FormatWidth(ByRef strString As String, ByRef intLength As Short, Optional ByRef blnLeftJustify As Boolean = True) As String
        'Make sure string is not too long
        If Len(strString) > intLength Then
            FormatWidth = Left(strString, intLength)

            'If left justify, place spaces at end
        ElseIf blnLeftJustify Then
            FormatWidth = strString & New String(" ", intLength - Len(strString))

            'Else Right justify by placing spaces at beginning
        Else
            FormatWidth = New String(" ", intLength - Len(strString)) & strString
        End If
    End Function

    '***************************************************************
    'This subroutine creates a pause/delay before continuing
    Public Sub Pause(ByRef sngSeconds As Single)
        'Dim dtStart As Date

        'Calculate end time
        'dtStart = Now

        'While Now.Subtract(dtStart).TotalSeconds < sngSeconds

        Threading.Thread.Sleep(sngSeconds * 1000)

        'End While
    End Sub

    Public Sub Pause2(ByRef sngSeconds As Single)

        Dim dt As DateTime = DateTime.Now.AddMilliseconds(sngSeconds * 1000)
        While DateTime.Now < dt
            Application.DoEvents()
        End While


    End Sub

    '***************************************************************
    '***************************************************************
    'This function determines if the time has expired, fjm, 07/06/04
    Public Function TimeExpired(ByRef dtStart As Date, ByRef intSeconds As Short) As Boolean
        Dim blnExpired As Boolean

        On Error Resume Next

        If Now.Subtract(dtStart).TotalSeconds > intSeconds Then
            blnExpired = True
        Else
            blnExpired = False
        End If

        'Return Status
        TimeExpired = blnExpired
    End Function

    '***************************************************************
    'This subroutine creates the directory if it does not exist.
    'It handles the fact that the subdirectories used already have the
    'backslash already appended.
    Public Sub CreateDirectory(ByVal strDir As String)
        On Error Resume Next

        'Removing Trailing Backslash
        If Right(strDir, 1) = "\" Then
            strDir = Left(strDir, Len(strDir) - 1)
        End If

        'Create Directory
        MkDir(strDir)
    End Sub

    '***************************************************************
    'This function converts a boolean to a string and returns YES or NO
    Public Function BoolToYesNo(ByVal blnValue As Boolean) As String
        If blnValue Then
            BoolToYesNo = "YES"
        Else
            BoolToYesNo = "NO"
        End If
    End Function

    '***************************************************************
    'This function converts a boolean to a string and returns ON or OFF
    Public Function BoolToOnOff(ByVal blnValue As Boolean) As String
        If blnValue Then
            BoolToOnOff = "ON"
        Else
            BoolToOnOff = "OFF"
        End If
    End Function

    '***************************************************************
    'This function converts the long value to binary and returns a string.
    'For example, a value of 15 would return 0000 0000 0000 0000 0000 0000 0000 1111
    Public Function LongToBinary(ByVal intValue As Integer) As String
        Dim strBinary As String
        Dim intIndex As Integer

        'Initialize Variables
        strBinary = ""

        'Convert Value in Binary
        For intIndex = 31 To 0 Step -1
            If intValue >= 2 ^ intIndex Then
                intValue = intValue - 2 ^ intIndex
                strBinary = strBinary & "1"
            Else
                strBinary = strBinary & "0"
            End If

            'Add Space every 4
            If (intIndex Mod 4) = 0 And Not intIndex = 0 Then
                strBinary = strBinary & " "
            End If
        Next intIndex

        'Return Binary as String
        LongToBinary = strBinary
    End Function

    '***************************************************************
    'This function returns the string name of the zone
    Public Function ZoneToString(ByRef intZone As Integer, ByRef intNumberOfZones As Integer) As String
        Dim strZone As String

        'Initialize Variables
        strZone = ""

        'Determine number of Zones
        Select Case intNumberOfZones
            Case 3
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "Middle"
                    Case 3 : strZone = "Comp"
                End Select
            Case 4
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "MidInlet"   '"InletMid"
                    Case 3 : strZone = "MidComp"    '"CompMid"
                    Case 4 : strZone = "Comp"
                End Select
            Case 5
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletMid"
                    Case 3 : strZone = "Middle"
                    Case 4 : strZone = "CompMid"
                    Case 5 : strZone = "Comp"
                End Select
            Case 6
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletMid"
                    Case 3 : strZone = "MidInlet"
                    Case 4 : strZone = "MidComp"
                    Case 5 : strZone = "CompMid"
                    Case 6 : strZone = "Comp"
                End Select
            Case 7
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletMid"
                    Case 3 : strZone = "MidInlet"
                    Case 4 : strZone = "Middle"
                    Case 5 : strZone = "MidComp"
                    Case 6 : strZone = "CompMid"
                    Case 7 : strZone = "Comp"
                End Select
            Case 8
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletMid"
                    Case 3 : strZone = "MidInlet"
                    Case 4 : strZone = "MidMidInlet"
                    Case 5 : strZone = "MidMidComp"
                    Case 6 : strZone = "MidComp"
                    Case 7 : strZone = "CompMid"
                    Case 8 : strZone = "Comp"
                End Select
            Case 9
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletMid"
                    Case 3 : strZone = "MidInlet"
                    Case 4 : strZone = "MidMidInlet"
                    Case 5 : strZone = "Middle"
                    Case 6 : strZone = "MidMidComp"
                    Case 7 : strZone = "MidComp"
                    Case 8 : strZone = "CompMid"
                    Case 9 : strZone = "Comp"
                End Select
            Case 10
                Select Case intZone
                    Case 1 : strZone = "Inlet"
                    Case 2 : strZone = "InletInletMid"
                    Case 3 : strZone = "InletMid"
                    Case 4 : strZone = "MidInlet"
                    Case 5 : strZone = "MidMidInlet"
                    Case 6 : strZone = "MidMidComp"
                    Case 7 : strZone = "MidComp"
                    Case 8 : strZone = "CompMid"
                    Case 9 : strZone = "CompCompMid"
                    Case 10 : strZone = "Comp"
                End Select
        End Select

        'Return Zone Text
        ZoneToString = strZone
    End Function

    Public Sub ListGlassTypes(ByRef cmbCombo As System.Windows.Forms.ComboBox)
        Dim hndFile As Short
        Dim strFile As String
        Dim strLine As String

        On Error GoTo ErrorHandler

        'Initialize Variables
        strFile = gstrCurDir & "/" & cPathConfig & "/GlassCodes.cfg"

        'Clear Combo
        cmbCombo.Items.Clear()

        'Check for file existence
        If Dir(strFile) = "" Then
            cmbCombo.Items.Add("1737F")
            cmbCombo.Items.Add("1737G")
            cmbCombo.Items.Add("2000F")
            cmbCombo.Items.Add("2000G")
            cmbCombo.Items.Add("EagleXG")
        Else
            'Open File
            hndFile = FreeFile()
            FileOpen(hndFile, strFile, OpenMode.Input)

            'Step through file
            While Not EOF(hndFile)
                'Read line and trim
                strLine = LineInput(hndFile)
                strLine = Trim(strLine)

                'Add to Combo
                cmbCombo.Items.Add(strLine)
            End While

            'Close file
            FileClose(hndFile)
        End If


        Exit Sub
ErrorHandler:
        gLog.LogErr("ListGlassTypes, " & Err.Description)
        FileClose(hndFile)
    End Sub

    '***************************************************************
    Public Function GetStitchSheetWidthFactor(ByRef intStitchSheetRatioIndex As Short, _
                                              ByRef blnFirstSide As Boolean) As Single
        Dim sngReturn As Single

        Select Case intStitchSheetRatioIndex
            Case 0 '50:50
                sngReturn = 0.5
            Case 1 '40:60
                If blnFirstSide Then
                    sngReturn = 0.4
                Else
                    sngReturn = 0.6
                End If
            Case 2 '60:40
                If blnFirstSide Then
                    sngReturn = 0.6
                Else
                    sngReturn = 0.4
                End If
            Case Else '50:50
                sngReturn = 0.5
        End Select

        'Return Data
        GetStitchSheetWidthFactor = sngReturn

        On Error GoTo ErrorHandler
        Exit Function
ErrorHandler:
        gLog.LogErr("GetStitchSheetWidthFactor(), Error:" & Err.Description)
    End Function

    '***************************************************************
    'This subroutine purges old files
    Public Sub FilePurge(ByRef strPath As String, ByRef strFileFilter As String, ByRef intLogDuration As Integer)
        Dim strFile As String
        Dim dtFile As Date

        On Error GoTo ErrorHandler

        'Step through log files, purging old
        strFile = Dir(FormatPath(strPath) & strFileFilter)
        While strFile <> ""
            'Get file date
            dtFile = FileDateTime(FormatPath(strPath) & strFile)

            'if file is older then LogDuration, then delete
            If Now.Subtract(dtFile).TotalDays > intLogDuration Then
                Kill(FormatPath(strPath) & strFile)
            End If

            'Get next file
            strFile = Dir()
        End While

        Exit Sub
ErrorHandler:
        gLog.LogErr("FilePurge(), Path=" & strPath & ", Error=" & Err.Description)
    End Sub

    '***************************************************************
    '// Return the number of keys found on the specified section
    '// if found, sKeys will contain a string of keys seperated by ","
    '// Added by SL on 11/15/02
    Public Function GetFromINI(ByRef sSection As String, _
                               ByRef sKey As String, _
                               ByRef sDefault As String, _
                               ByRef sIniFile As String) As String
        Dim sBuffer As String
        Dim lRet As Integer

        On Error Resume Next

        ' Fill String with 255 spaces
        sBuffer = New String(Chr(0), 255)
        ' Call DLL
        lRet = GetPrivateProfileString(sSection, sKey, "", sBuffer, Len(sBuffer), sIniFile)
        If lRet = 0 Then
            ' DLL failed, save default
            If sDefault <> "" Then AddToINI(sSection, sKey, sDefault, sIniFile)
            GetFromINI = sDefault
        Else
            ' DLL successful
            ' return string
            GetFromINI = Left(sBuffer, InStr(sBuffer, Chr(0)) - 1)
        End If
    End Function

    '***************************************************************
    '// Returns True if successful. If section does not
    '// exist it creates it.
    Public Function AddToINI(ByRef sSection As String, ByRef sKey As String, ByRef sValue As String, ByRef sIniFile As String) As Boolean
        Dim lRet As Integer

        On Error Resume Next

        ' Call DLL
        lRet = WritePrivateProfileString(sSection, sKey, sValue, sIniFile)
        AddToINI = (lRet)
    End Function

    'NOTE: this function is not being called anymore, it was used to read the GlassIndex from a file, but customer
    'decided not to use this feature. Leave code here just in case customer wants to re-implement...leoc
    Public Function GetIndexOfRefraction(ByVal strGlassIndexFile As String, strGlassType As String) As Single
        Dim strFile As String = ""
        Dim strIndex As String

        Try
            strFile = gstrCurDir & cPathConfig & strGlassIndexFile

            'Read Refractive Index from INI file
            strIndex = GetFromINI("Index_Of_Refraction", strGlassType, "ERR", strFile)
            If strIndex = "ERR" Then
                gLog.LogErr("GetIndexOfRefraction(), Unable to find glass type: " _
                            & strGlassType & " in File: " & strFile)
                strIndex = CStr(1)
            End If

            Return Val(strIndex)
        Catch ex As Exception
            gLog.LogErr("mdlGeneral", "GetIndexOfRefraction()", ex, strFile)
            Return 1
        End Try

    End Function
End Module
