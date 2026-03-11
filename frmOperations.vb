Option Strict Off
Option Explicit On

Imports System.Collections.Generic
Imports System.Windows.Forms.AxHost

Friend Class frmOperations
    Inherits System.Windows.Forms.Form
    '***************************************************************
    '
    'Module:    frmOperations.frm
    '
    'Description:   This is the main form for the Auto Cord Gauge.
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
    '2009-09-28 fjm         Added AutoPeaking if AutoNoiseCheck Fails
    '2009-10-27 fjm         Added check for GaugeCom IsBeaded and IsBroken to ignore inlet sensor to support manual gauge
    '                       For Manual gauge, just disable measurment bacause there is no servo
    '                       Added FacilityPowerLoss
    '2009-12-17 fjm         Added Thickness Sensor
    '2010-02-14 fjm         Added GaugeComStatus_Thread for timer calls to GaugeCom
    '2016-10-11 fjm         Updated for CEOLTG
    '***************************************************************

#Region "Constants"
    Const cAccept As String = "Accept"
    Const cReject As String = "Reject"
#End Region

#Region "Publics"

    Public PLCWaitTime As DateTime
#End Region

#Region "Privates"
    Private _oPrevSheet As clsData_LTG = Nothing
    Private _oSheet As clsData_Sheet = Nothing

    Private _swCycleTime As New System.Diagnostics.Stopwatch
    Private _dtLastHeartBeat As DateTime = DateTime.MinValue
    Private _dtPostSheetClearStart As DateTime = DateTime.MinValue

    Private _iSheetsSinceLastSaveCnt As Integer = 0

#End Region

#Region "Constructor/Destructor"
    Private Sub frmOperations_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            Me._oSheet = New clsData_Sheet
            Me._oPrevSheet = New clsData_LTG(Nothing)
            gLog.LogDebug(5, "frmOperations Load")

            'Show First Tab
            Me.SSTab1.SelectedIndex = 0

            'Hide Sheet Information and Sheet Data
            Me.grpSheetInfo.Visible = False
            Me.grpResults.Visible = False
            Me.SSTab1.Visible = True

            Me.Text &= "- Thickness Gauge"
            Me.Text &= " v" & My.Application.Info.Version.Major.ToString() _
                & "." & My.Application.Info.Version.Minor.ToString() & "." _
                & My.Application.Info.Version.Build.ToString()

            ' gConfig.Product.ReadCompressionBeadWidth(gLTG.CompressionBeadWidthFilePath)
            Me.txtGaugeID.Text = gConfig.GaugeID
            Me.txtBODID.Text = gConfig.BODID.ToString()
            Me.lblEngineerOutputEnabled.Visible = gConfig.LTGEngineerOutput
            Me.lblDropIfReject_Disabled.Visible = Not gConfig.DropIfReject

            'Define Start Location of Processing Form
            Dim iX As Integer = (Me.Width - gfrmProcessing.Width) / 2
            Dim iY As Integer = (SSTab1.Top - gfrmProcessing.Height)
            gfrmProcessing.Location = New Point(iX, iY)

            'Open OPC Connection
            gOPC.Connect()

            Me.tmrMain.Enabled = True

            'Set Graph X & Y Axis
            Me.gphDisplacement.YAxes(0).Mode = AxisMode.Fixed
            Me.gphDisplacement.YAxes(0).Inverted = gConfig.DistanceGraphInverted
            Me.gphDisplacement.YAxes(0).Range = New Range(gConfig.DistanceGraphMin, gConfig.DistanceGraphMax)
            Me.gphDisplacement.XAxes(0).Mode = AxisMode.AutoScaleExact

            'Set Graph X & Y Axis
            Me.gphThickness.YAxes(0).Mode = AxisMode.Fixed
            Me.gphThickness.YAxes(0).Range = New Range(gConfig.ThicknessGraphMin, gConfig.ThicknessGraphMax)
            Me.gphThickness.XAxes(0).Mode = AxisMode.AutoScaleExact
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "frmOperationsLoad event error", ex)
        End Try
    End Sub

    Private Sub frmOperations_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Event Handlers"
    Private Sub btnExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnExit.Click
        On Error Resume Next
        GaugeStop()
        Me.Close()
    End Sub

    Private Sub btnSheetInformation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSheetInformation.Click
        Try
            With New frmSheetInformation
                .moSheet = Me._oSheet
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then

                    'Check if Measurment Enabled
                    If Not gblnMeasurementEnabled Then
                        'Enable Measurement
                        Me.MeasurementEnable(True)

                        'Display Sheet Information 
                        If Me._oSheet IsNot Nothing Then
                            Me.grpSheetInfo.Visible = True
                            Me.DisplaySheetInfo()
                        End If

                    End If
                End If
            End With
        Catch ex As Exception
            gLog.LogErr(Me.Name, "btnProductSetup_Click", ex)
        End Try
    End Sub

    Private Sub btnMaintenance_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnMaintenance.Click
        On Error Resume Next
        Me.tmrMain.Enabled = False
        With frmLogin
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                'Check Password
                If gConfig.CheckAdminPW(.txtPassword.Text) Then
                    With gfrmMaint
                        Me.tmrMain.Enabled = False
                        .ShowDialog()

                        Me.tmrMain.Enabled = True
                    End With
                Else
                    gLog.LogErr("Invalid Password for access to Maintenance")
                End If
            End If
        End With
        Me.tmrMain.Enabled = True
    End Sub

    Private Sub btnViewLog_Click(sender As Object, e As EventArgs) Handles btnViewLog.Click
        Try
            gLog.ShowLastLogFile()
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "btnViewLog_Click", ex)
        End Try
    End Sub

    Private Sub btnViewConfig_Click(sender As Object, e As EventArgs) Handles btnViewConfig.Click

        With frmLogin
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                'Check Password
                If gConfig.CheckAdminPW(.txtPassword.Text) Then

                    Try
                        Dim strFile As String = FormatPath(gstrCurDir & cPathConfig) & My.Application.Info.AssemblyName & cFileExtConfig
                        Shell("NotePad " & strFile, AppWinStyle.MaximizedFocus)
                    Catch ex As Exception
                        gLog.LogErr(Me.GetType.Name, "btnViewConfig_Click", ex)
                    End Try

                Else
                    gLog.LogErr("Invalid Password for access to Maintenance")
                End If
            End If
        End With


    End Sub

    Private Sub btnReReadConfig_Click(sender As Object, e As EventArgs) Handles btnReReadConfig.Click

        With frmLogin
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                'Check Password
                If gConfig.CheckAdminPW(.txtPassword.Text) Then

                    If gState = enumGaugeState.gsIdle Then
                        Try
                            If gConfig.ReadConfig() = enumError.errSuccess Then
                                'reinitialize gauge
                                mdlGeneral.InitGauge()
                            End If
                        Catch ex As Exception
                            gLog.LogErr(Me.GetType.Name, "btnReReadConfig_Click", ex)
                        End Try
                    Else
                        'New variable, tell state machine it's ok buddy, you can re-read me...leoc
                        mdlGeneral.gReReadRequested = True
                        gLog.LogDebug(3, String.Format("Re-Read request is True. Current state={0} and SubState={1}, waiting for ssPostSheetClear state",
                                                       gState.ToString, gSubState.ToString))
                    End If

                    'Moved this section inside the if state = idle, otherewise it needs
                    'to be done after the sheet has scanned...

                    'Try
                    '    If gConfig.ReadConfig() = enumError.errSuccess Then
                    '        'reinitialize gauge
                    '        mdlGeneral.InitGauge()
                    '    End If
                    'Catch ex As Exception
                    '    gLog.LogErr(Me.GetType.Name, "btnReReadConfig_Click", ex)
                    'End Try

                Else
                    gLog.LogErr("Invalid Password for access to Maintenance")
                End If
            End If
        End With



    End Sub

    Private Sub mnuLogFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLogFile.Click
        Try
            gLog.ShowLastLogFile()
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "mnuLogFile_Click", ex)
        End Try
    End Sub

    Private Sub mnuConfigSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigSave.Click
        Try
            gConfig.SaveConfig()
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "mnuConfigSave_Click", ex)
        End Try
    End Sub

    Private Sub mnuConfigOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigOpen.Click
        Try
            Dim strFile As String = FormatPath(gstrCurDir & cPathConfig) & My.Application.Info.AssemblyName & cFileExtConfig
            Shell("NotePad " & strFile, AppWinStyle.MaximizedFocus)
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "mnuConfigOpen_Click", ex)
        End Try
    End Sub

    Private Sub mnuConfigReRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfigReRead.Click
        Try
            If gConfig.ReadConfig() = enumError.errSuccess Then
                'reinitialize gauge
                mdlGeneral.InitGauge()
            End If
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "mnuConfigReRead_Click", ex)
        End Try
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Try
            frmAbout.Show()
            frmAbout.Activate()
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "mnuAbout_Click", ex)
        End Try
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Try
            Me.StopMeasurement()

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Gauge Engine"
    Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick

        On Error Resume Next
        'Disable Timer, while running code
        Me.tmrMain.Enabled = False

        'Display Time, Status, and State in Status Bar
        lblTime.Text = Now.ToString("HH:mm:ss")
        lblStatus.Text = gLog.Status
        lblTime.Text = GetGaugeState(mdlGeneral.gState)

        'Purge Log File
        gLog.Purge()

        '************************** General Status ****************************
        If Not gblnMeasurementEnabled Then
            Me.btnSheetInformation.BackColor = Color.FromKnownColor(KnownColor.Control)
        End If


        '************************** Send heartbeat ****************************
        If DateTime.Now.Subtract(_dtLastHeartBeat).TotalSeconds >= gOPC.WriteHeartbeatPeriod Then
            _dtLastHeartBeat = DateTime.Now
            gOPC.ToggleOPCHeartBeat()
        End If

        '************************** Measurement ****************************
        'Check for Sheet Running
        If gState = enumGaugeState.gsSheet Then
            'Enable/Disable Buttons
            Me.btnMaintenance.Enabled = False
            Me.btnSheetInformation.Enabled = False
            Me.btnStop.Enabled = True

            Select Case gSubState
                Case enumSubState.ssIdle

                Case enumSubState.ssStart
                    gLTG.SetMode(enumLaserMode.lsrMonitor)

                    gSubState = enumSubState.ssWaitForSheet
                    gLog.LogDebug(6, "Gauge SubState: Waiting for Sheet")

                Case enumSubState.ssWaitForSheet
                    If gLTG.SheetDetected Then
                        gLog.LogDebug(6, "Gauge SubState:  Collecting Data")

                        'Start Cycle Timer
                        _swCycleTime.Restart()

                        'Collect Data
                        gLTG.SetMode(enumLaserMode.lsrCollectData)
                        gSubState = enumSubState.ssCollectingData

                        ShowProcessing("Collecting Data")

                        'Save PLC Data
                        Me._oSheet.Info.UID = gOPC.UID
                        Me._oSheet.Info.BornDT = gOPC.BornDT
                        gLog.LogDebug(9, String.Format("Sheet Info from PLC:  UID={0}, BornDT={1:yyyy-MM-dd hh:mm:ss}", gOPC.UID, gOPC.BornDT))

                    End If

                Case enumSubState.ssCollectingData
                    If gLTG.EndOfSheetDetected Then
                        gLog.LogDebug(6, "Gauge SubState:  Processing Data")

                        'Scan Complete
                        gSubState = enumSubState.ssProcessingData
                        ShowProcessing("Processing Data")
                    ElseIf _swCycleTime.Elapsed.TotalSeconds > gConfig.MeasurementTimeout Then
                        HideProcessing()
                        gLog.LogMsg("Measurement Timeout during data collection.")
                        Me.lblResults.Text = "Timeout"
                        Me.lblResults.BackColor = Color.Yellow
                        GotoPostSheetClear()
                    End If

                Case enumSubState.ssProcessingData
                    Me._oSheet.Init()

                    'Process Sheet first
                    gDP.ProcessSheet(Me._oSheet)

                    'Calculate QA Values , v1.1.7
                    'PREFORM BEFORE OK/Reject Logic
                    'Round VBSOffset to Integer, fjm, v1.1.12
                    'Use IsMarked to determine, QAStart and QAEnd, v1.1.16
                    gLog.LogDebug(1, "gSpec.IsMarked = " + gSpec.IsMarked.ToString)
                    If gSpec.IsMarked Then
                        _oSheet.Info.VBSOffset = Math.Round((_oSheet.LTG.SizeWidth_Measured - _oSheet.Info.ProductWidth) / 2)
                        _oSheet.Info.QAStart = _oSheet.Info.VBSOffset + _oSheet.Info.TrimCompression
                        _oSheet.Info.QAEnd = _oSheet.Info.QASheetWidth + _oSheet.Info.QAStart
                    Else
                        'From v1.1.2 code
                        _oSheet.Info.VBSOffset = 0
                        _oSheet.Info.QAStart = (_oSheet.Info.ProductWidth - _oSheet.Info.QASheetWidth) / 2
                        _oSheet.Info.QAEnd = _oSheet.Info.QASheetWidth + _oSheet.Info.QAStart
                    End If


                    If gConfig.CalculatedQATrimEnabled Then

                        '1.	Full width measured the same
                        '2.	Calculate trim size the same – (full width minus cut size from product code) / 2
                        '   a.Could be decimals now instead of whole numbers if cut size Is decimal
                        '3.	Get non-QA size from product code – can be decimal Or whole number
                        '4.	Calculate QA start as: 
                        '   a.Trim +non QA size 
                        '   b.Round down to the nearest whole number
                        '5.	Calculate QA end as: 
                        '   a.QA start before rounding down + QA size 
                        '   b.Round up to the nearest whole number
                        '6.	All attributes/comparison against spec would use the rounded down QA start And rounded up QA end points as the quality area for comparison
                        _oSheet.Info.QAStart = Math.Floor(_oSheet.Info.QAStart)
                        _oSheet.Info.QAEnd = Math.Ceiling(_oSheet.Info.QAEnd)
                        _oSheet.Info.VBSOffset = Math.Floor((_oSheet.LTG.SizeWidth_Measured - _oSheet.Info.ProductWidth) / 2)
                    End If



                    'Init Reason code, v1.1.21
                    Me._oSheet.Info.Reason = clsData_Info.cReasonNone

                    If gConfig.AppDispAndJudgeEnable Then
                        'Width Reject, v1.1.18
                        If gConfig.WidthRejectEnable Then
                            If _oSheet.LTG.SizeWidth_Measured < gConfig.WidthRejectMin Then
                                Me._oSheet.Info.Reason = clsData_Info.cReasonReject
                                Me._oSheet.Info.ReasonString = "Reject Min WIDTH"
                                Me._oSheet.Info.Results = "REJECT"

                                'v1.1.24
                                gLog.LogDebug(9, String.Format("Reject Min WIDTH: Reason={0}, SizeWidth_Measured={1:0.000}, WidthRejectMin={2:0.000}",
                                                               _oSheet.Info.Reason.ToString, _oSheet.LTG.SizeWidth_Measured, gConfig.WidthRejectMin))

                            ElseIf _oSheet.LTG.SizeWidth_Measured > gConfig.WidthRejectMax Then
                                Me._oSheet.Info.Reason = clsData_Info.cReasonReject
                                Me._oSheet.Info.ReasonString = "Reject Max WIDTH"
                                Me._oSheet.Info.Results = "REJECT"

                                'v1.1.24
                                gLog.LogDebug(9, String.Format("Reject Max WIDTH: Reason={0}, SizeWidth_Measured={1:0.000}, WidthRejectMin={2:0.000}",
                                                               _oSheet.Info.Reason.ToString, _oSheet.LTG.SizeWidth_Measured, gConfig.WidthRejectMax))
                            End If
                        End If

                        'Get Results
                        'Always run RejectLogic, v1.1.21
                        Dim oResults As OKRejectResult = RunOKRejectLogicAgainstSpec(_oSheet)

                        'Check if reason code, v1.1.18
                        'Only use oResults, if a reason has not been provided, v1.1.21
                        If Me._oSheet.Info.Reason = clsData_Info.cReasonNone Then
                            Me._oSheet.Info.Reason = oResults.Reason
                            Me._oSheet.Info.ReasonString = oResults.ReasonString    'v1.1.12
                            Me._oSheet.Info.Results = oResults.LineMode

                            'v1.1.24
                            gLog.LogDebug(9, "Save Results from RunOKRejectLogicAgainstSpec()")
                        End If
                        'v1.1.24
                        gLog.LogDebug(9, String.Format("Sheet Final Results: Reason={0}, ReasonString={1}, Results={2}",
                                                               _oSheet.Info.Reason.ToString, _oSheet.Info.ReasonString, _oSheet.Info.Results))

                        'Send Results to PLC
                        gOPC.SendResultsToPLC(_oSheet.Info, _oSheet.LTG)
                    End If
                    'Display Results
                    Me.txtSheetUID.Text = _oSheet.Info.UID.ToString("0")
                    Me.lblResults.Text = _oSheet.Info.Results
                    Me.lblResults.BackColor = Me.BackColor
                    Me.txtVBSOffset.Text = _oSheet.Info.VBSOffset.ToString("0") 'fjm, v1.1.7
                    Me.DisplayThicknessResults()
                    Me.DisplayDistanceResults()
                    Me.DisplayQAResults()  'fjm, v1.1.8

                    'Save Current Data as Previous
                    'ArrayToFile("c:\SOCG\DATA\Previous.csv", "Position,Thickness", dblXData, dblPrevious)
                    Me._oPrevSheet.Sheet.Position = _oSheet.LTG.Sheet.Position.Clone
                    Me._oPrevSheet.Sheet.Thickness = _oSheet.LTG.Sheet.Thickness.Clone
                    Me._oPrevSheet.Sheet.Distance = _oSheet.LTG.Sheet.Distance.Clone

                    'Goto Post Sheet Clear SubState
                    GotoPostSheetClear()

                    'Get cycle time
                    Me._swCycleTime.Stop()
                    Me._oSheet.LTG.CycleTime = Me._swCycleTime.Elapsed.TotalSeconds

                    'Save Measurement Results to File
                    Me.SaveResults()

                    HideProcessing()
                Case enumSubState.ssPostSheetClear  'Added, fjm, 2016-12-13
                    If gLTG.PostSheetClear Then
                        If Now.Subtract(Me._dtPostSheetClearStart).TotalSeconds > gConfig.PostSheetClearTime Then

                            'added this logic to handle re-read at the end of the state machine
                            If mdlGeneral.gReReadRequested Then

                                'reset the requested bit to false
                                mdlGeneral.gReReadRequested = False

                                're-read the config file - pass in new True parameter for re-read
                                'so that it doesn't re-init the sensor mode
                                If gConfig.ReadConfig(True) = enumError.errSuccess Then
                                    'reinitialize gauge
                                    'mdlGeneral.InitGauge()
                                    gLog.LogDebug(3, "Re-Read configuration successful while in the ssPostSheetClear")
                                Else
                                    gLog.LogDebug(3, "Re-Read configuration NOT successful while in the ssPostSheetClear")
                                End If

                            End If

                            'this was the original state transition...leoc
                            gSubState = enumSubState.ssWaitForSheet
                        End If
                    Else
                        'Keep reseting PostSheetClearStart until sensor is clear
                        Me._dtPostSheetClearStart = Now
                    End If
            End Select
        End If

        'Re-Enable Timer
        Me.tmrMain.Enabled = True

    End Sub


#End Region

#Region "Display Functions"
    Public Sub DisplaySheetInfo()
        On Error Resume Next

        'Display Data
        Me.txtBODID.Text = gConfig.BODID.ToString()
        Me.txtGlassCode.Text = _oSheet.Info.GlassCode
        Me.txtProductCode.Text = _oSheet.Info.ProductCode.Substring(_oSheet.Info.ProductCode.LastIndexOf("_") + 1)
        Me.txtSize.Text = _oSheet.Info.ProductWidth
        Me.txtThickness.Text = _oSheet.Info.Thickness.ToString("0.000") '& " mm"
        Me.txtGaugeID.Text = _oSheet.Info.GaugeID
        Me.txtLastMeasurementTime.Text = _oSheet.Info.MeasureDT.ToString()
        Me.txtQASheetWidth.Text = _oSheet.Info.QASheetWidth.ToString("0")

        'NOTE: this is no longer needed...leoc
        'Me.txtRefractiveIndex.Text = _oSheet.Info.GlassRefIdx.ToString("0.000")
    End Sub



    Private Sub DisplayQAResults()
        Try
            Me.txtQAStart.Text = _oSheet.Info.QAStart.ToString("0") 'fjm, v1.1.7
            Me.txtQAEnd.Text = _oSheet.Info.QAEnd.ToString("0") 'fjm, v1.1.7
            Me.txtQAThicknessAvg.Text = _oSheet.LTG.QAThicknessAvg.ToString(cFormatQAThickness) 'fjm, v1.1.8
            Me.txtQAThicknessMin.Text = _oSheet.LTG.QAThicknessMin.ToString(cFormatQAThickness) 'fjm, v1.1.8
            Me.txtQAThicknessMax.Text = _oSheet.LTG.QAThicknessMax.ToString(cFormatQAThickness) 'fjm, v1.1.8
            Me.txtQAThicknessRng.Text = _oSheet.LTG.QAThicknessRng.ToString(cFormatQAThickness) 'fjm, v1.1.12

            'Add MWR as Annotations to Thickness Graph, v1.1.12
            Dim iCnt As Integer = 0
            For Each oMWR As clsSpec_MWR In _oSheet.LTG.QAMWR
                iCnt += 1

                'Add Annotation
                Dim oAnno As UI.XYPointAnnotation = New UI.XYPointAnnotation()
                Me.gphThickness.Annotations.Add(oAnno)

                Dim xPos As Double = Me.gphThickness.XAxes(0).Range.Minimum
                Dim yPos As Double = 0
                With Me.gphThickness.YAxes(0).Range
                    yPos = .Maximum - (.Maximum - .Minimum) * (iCnt - 1) * 0.05
                End With

                With oAnno
                    .CaptionVisible = True
                    .ArrowVisible = False
                    .ShapeVisible = False

                    .Caption = String.Format("MWR {0}mm = {1}um", oMWR.WindowSize, oMWR.CalcMWR * 1000)
                    .CaptionForeColor = If(oMWR.Reject, Color.Red, Color.Black)
                    .CaptionAlignment = New UI.AnnotationCaptionAlignment(BoundsAlignment.None, 0, 0)
                    .SetPosition(xPos, yPos)
                End With
            Next

        Catch ex As Exception
            gLog.LogErr(Me.Name, "DisplayQAResults", ex)
        End Try
    End Sub

    Private Sub DisplayThicknessResults()
        Try
            Dim dblCurrent() As Double = {}
            Dim dblPrevious() As Double = {}

            'Clear Graph
            Me.gphThickness.ClearData()

            Me.lbl1.Text = "Current Scan"
            Me.lbl1.ForeColor = Color.Red
            Me.lbl2.Text = "Previous Scan"
            Me.lbl2.ForeColor = Color.Lime

            Me.grpResults.Visible = True
            Me.lblMeasuredWidth.Visible = True
            Me.lblConsecutiveBadPts.Visible = True
            Me.lblGoodPoints.Visible = True
            Me.lblOverallBadPts.Visible = True
            Me.txtLTGBadConsecutive.Visible = True
            Me.txtLTGBadOverall.Visible = True
            Me.txtLTGGoodPointsLocated.Visible = True
            Me.txtThickness_MeasuredWidth.Visible = True

            'Set Caption for Y-Axis
            Me.gphThickness.XAxes(0).Caption = "Position"

            With _oSheet.LTG
                'Set Title
                Me.gphThickness.Text = "Nominal Thickness = " & _oSheet.LTG.Info.Thickness.ToString("0.0000")

                'NOTE: no longer reading from the file, just update from the sensor...leoc
                'using the same variable name, however, it's being read from the sensor and not from the config file...
                'Chain of events: chrocodile reads and populates the LastSensorIdxRef, then the text field is updated with the
                'correct value.
                Me.txtPrecitecRefIdx.Text = gLTG.LastSensorIdxRef.ToString("0.000")


                'Display Measured Width
                Me.txtThickness_MeasuredWidth.Text = _oSheet.LTG.SizeWidth_Measured.ToString("0")
                Me.txtLastMeasurementTime.Text = _oSheet.Info.MeasureDT.ToString()

                'Display Good Points Status
                If .GoodPointsLocated Then
                    Me.txtLTGGoodPointsLocated.Text = cAccept
                    Me.txtLTGGoodPointsLocated.BackColor = Color.FromKnownColor(KnownColor.Control)
                Else
                    Me.txtLTGGoodPointsLocated.Text = cReject
                    Me.txtLTGGoodPointsLocated.BackColor = Color.Red
                End If

                'Display Bad Point Counts
                Me.txtLTGBadOverall.Text = .BadOverallCnt.ToString("0")
                If .BadOverallCnt > gDP.MaxBadOverallCnt Then
                    Me.txtLTGBadOverall.BackColor = Color.Red
                Else
                    Me.txtLTGBadOverall.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
                Me.txtLTGBadConsecutive.Text = .BadConsecutiveCnt.ToString("0")
                If .BadConsecutiveCnt > gDP.MaxBadConsecutiveCnt Then
                    Me.txtLTGBadConsecutive.BackColor = Color.Red
                Else
                    Me.txtLTGBadConsecutive.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If

                'Clear Annotations, v1.1.12
                Me.gphThickness.Annotations.Clear()

                'Set Graph X & Y Axis
                Me.gphThickness.YAxes(0).Mode = AxisMode.Fixed
                Me.gphThickness.YAxes(0).Range = New Range(gConfig.ThicknessGraphMin, gConfig.ThicknessGraphMax)
                Me.gphThickness.XAxes(0).Mode = AxisMode.AutoScaleExact

                'Plot Current
                'gLog.LogDebug(9, ".Sheet.Thickness.Length = " & .Sheet.Thickness.Length)
                If .Sheet.Thickness.Length >= 2 Then
                    'Display Deviation from Nominal, v1.0.24, fjm
                    dblCurrent = AddArray(.Sheet.Thickness, -_oSheet.Info.Thickness)
                    Me.gphThickness.Plots(1).PlotXY(.Sheet.Position.ToArray(), dblCurrent)

                    'ArrayToFile("c:\SOCG\DATA\Current.csv", "Position,Thickness", dblXData, dblCurrent)

                    'Plot Quality Area
                    Dim dFirst As Double = .Sheet.Position.First
                    Dim dLast As Double = .Sheet.Position.Last
                    Dim dQStart As Double = _oSheet.Info.QAStart
                    Dim dQEnd As Double = _oSheet.Info.QAEnd
                    Dim lstPosition As New List(Of Double)
                    Dim lstValue As New List(Of Double)
                    lstPosition.Add(IIf(dFirst > dQStart, dQStart, dFirst))
                    lstPosition.Add(dQStart)
                    lstPosition.Add(dQEnd)
                    lstPosition.Add(IIf(dLast < dQEnd, dQEnd, dLast))
                    lstValue.Add(1)
                    lstValue.Add(1)
                    lstValue.Add(0)
                    lstValue.Add(1)
                    Me.gphThickness.Plots(0).PlotXY(lstPosition.ToArray(), lstValue.ToArray)
                End If

            End With

            'Plot Previous
            If Not Me._oPrevSheet Is Nothing Then
                With Me._oPrevSheet.Sheet
                    If .Thickness.Length >= 2 Then
                        'Display Deviation from Nominal, v1.0.24, fjm
                        dblPrevious = AddArray(.Thickness, -_oSheet.Info.Thickness)
                        Me.gphThickness.Plots(2).PlotXY(.Position.ToArray(), dblPrevious)
                    End If
                End With
            End If

        Catch ex As Exception
            gLog.LogErr(Me.Name, "DisplayThicknessResults", ex)
        End Try

    End Sub

    Private Sub DisplayDistanceResults()
        Try
            'Clear Graph
            Me.gphDisplacement.ClearData()

            'Set Caption for Y-Axis
            Me.gphDisplacement.XAxes(0).Caption = "Position"

            With _oSheet.LTG
                'Set Title
                Me.gphDisplacement.Text = "Displacement"

                'Get Distance
                Dim dDistance() As Double = .Sheet.Distance.Clone
                Dim dPosition() As Double = .Sheet.Position.Clone

                'Set Graph X & Y Axis
                Me.gphDisplacement.YAxes(0).Mode = AxisMode.Fixed
                Me.gphDisplacement.YAxes(0).Inverted = gConfig.DistanceGraphInverted
                Me.gphDisplacement.YAxes(0).Range = New Range(gConfig.DistanceGraphMin, gConfig.DistanceGraphMax)
                Me.gphDisplacement.XAxes(0).Mode = AxisMode.AutoScaleExact

                'Check if need to plot based on linear fit, fjm, 2017-07-26
                If gConfig.DistanceGraphLinearFitEnable Then
                    gphDisplacement.Caption = "Displacement with Linear Fit"
                    dDistance = Me.GetLinearFit(dPosition, dDistance)
                Else
                    gphDisplacement.Caption = "Displacement"
                End If

                'Calculate Surface Variation, fjm, 2017-10-16
                Dim dDiff As Double = dDistance.Max() - dDistance.Min()
                txtSurfaceVariation.Text = dDiff.ToString("0.000")

                'Plot Current
                'gLog.LogDebug(9, ".Sheet.Distance.Length = " & .Sheet.Distance.Length)
                If .Sheet.Distance.Length >= 2 Then
                    'Me.gphDisplacement.Plots(1).PlotXY(.Sheet.Position, .Sheet.Distance)
                    Me.gphDisplacement.Plots(1).PlotXY(dPosition, dDistance)
                End If
            End With


            'Plot Previous
            If Not Me._oPrevSheet Is Nothing Then
                With Me._oPrevSheet.Sheet
                    If .Distance.Length >= 2 Then
                        'Get Distance
                        Dim dDistance() As Double = .Distance.Clone
                        Dim dPosition() As Double = .Position.Clone

                        'Check if need to plot based on linear fit, fjm, 2017-07-26
                        If gConfig.DistanceGraphLinearFitEnable Then
                            dDistance = Me.GetLinearFit(dPosition, dDistance)
                        End If

                        'Me.gphDisplacement.Plots(0).PlotXY(.Position, .Distance)
                        Me.gphDisplacement.Plots(0).PlotXY(dPosition, dDistance)
                    End If
                End With

            End If
        Catch ex As Exception
            gLog.LogErr(Me.Name, "DisplayDistanceResults", ex)
        End Try

    End Sub

    Private Function GetLinearFit(ByRef dX() As Double, ByRef dY() As Double) As Double()
        Dim dFit() As Double = dY.Clone
        Dim dReturn() As Double = Nothing

        Try
            Dim dSlope As Double = 0
            Dim dIntercept As Double = 0
            Dim dResidue As Double = 0

            'Calculate LinearFit
            dFit = CurveFit.LinearFit(dX, dY, FitMethod.LeastSquare, dSlope, dIntercept, dResidue)

            dReturn = dFit.Clone
            For i As Integer = 0 To dReturn.GetUpperBound(0)
                dReturn(i) = (dY(i) - dFit(i)) / Math.Sqrt(1 - dSlope ^ 2)
            Next

        Catch ex As Exception
            gLog.LogErr(Me.Name, "GetLinearFit", ex)
        End Try

        'Return Data
        Return dReturn

    End Function
#End Region

#Region "Private Functions"

    Private Sub GotoPostSheetClear()
        Try
            'Set Modes to monitor for next sheet
            gLTG.SetMode(enumLaserMode.lsrMonitor)
            gSubState = enumSubState.ssPostSheetClear
            gLog.LogDebug(6, "Gauge SubState:  Post Sheet Clear Wait")
            Me._dtPostSheetClearStart = Now

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)

        End Try
    End Sub

    Private Sub StopMeasurement()
        MeasurementEnable(False)
        gLog.LogDebug(9, "Gauge Stopped")
    End Sub

    Private Sub StartMeasurement()

        If Not gblnMeasurementEnabled Then
            'Enable Measurement
            Me.MeasurementEnable(True)
            If Not Me._oSheet Is Nothing Then
                Me.grpSheetInfo.Visible = True
                DisplaySheetInfo()
            End If

        End If
    End Sub

    Private Sub MeasurementEnable(ByVal blnEnable As Boolean)

        On Error Resume Next

        'If Measurement Not in progress, clear gauge state and Measurement Enabled
        'Hide Processing
        If Not blnEnable Then
            SetGaugeState(enumGaugeState.gsIdle)
            gSubState = enumSubState.ssIdle
            gLTG.SetMode(enumLaserMode.lsrMonitor)

            gblnMeasurementEnabled = False
            HideProcessing()

        Else
            gblnMeasurementEnabled = True
        End If

        'Enabled/Disable Buttons
        Me.btnMaintenance.Enabled = Not blnEnable
        Me.btnSheetInformation.Enabled = Not blnEnable
        Me.btnExit.Enabled = Not blnEnable

    End Sub

    Private Sub SaveResults()

        Try
            ShowProcessing("Saving Results.")

            'Increment File Count
            Me._iSheetsSinceLastSaveCnt += 1

            'Check for Engineer Output
            If gConfig.LTGEngineerOutput Then
                Me._oSheet.LTG.SaveEngineerData()
            End If

            'If UID Synch enabled, determine if this sheet should be saved, fjm, 2017-05-30
            Dim bUIDSynchSave As Boolean = False
            If gConfig.DataFileSaveUIDSynch And gConfig.DataFileSavePeriod > 0 Then
                Dim iRemainder As Integer = 0
                Math.DivRem(Me._oSheet.Info.UID, gConfig.DataFileSavePeriod, iRemainder)

                If iRemainder = 0 Then bUIDSynchSave = True
            End If

            'Check criteria before saving file
            If Not Me._oSheet.LTG.Passed Then
                gLog.LogMsg("Data file not saved, Passed = False")
            ElseIf Me._iSheetsSinceLastSaveCnt < gConfig.DataFileSavePeriod And Not gConfig.DataFileSaveUIDSynch Then
                gLog.LogMsg(String.Format("Data file not saved, DataFileSavePeriod={0}, CurrentCount={1}", gConfig.DataFileSavePeriod, Me._iSheetsSinceLastSaveCnt))
            ElseIf Not gConfig.DataFileSaveUIDSynch Or bUIDSynchSave Then
                Me._oSheet.LTG.SaveSheetData()

                'Reset File Count
                Me._iSheetsSinceLastSaveCnt = 0

                'Run Batch file if enabled
                If gConfig.MESBatchFile.Length > 0 Then
                    RunBatch(gConfig.MESBatchFile.Trim())
                    gLog.LogDebug(6, "Successfully executed Thickness MESBatchFile")
                End If
            End If

            'Save Pi if enabled
            If Me._oSheet.LTG.Passed And gPi.PiImportFileEnable Then
                gPi.WritePiImport(Me._oSheet)
            End If

            'Save LastMeasurement
            If Me._oSheet.LTG.Passed And gConfig.LastMeasurement Then
                Me._oSheet.LTG.SaveLastMeasurement()
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "SaveData", ex)
        End Try
    End Sub






#End Region


End Class