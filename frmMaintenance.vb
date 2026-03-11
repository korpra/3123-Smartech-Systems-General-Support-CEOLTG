Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Imports NationalInstruments.Analysis.Math

Friend Class frmMaintenance
    Inherits System.Windows.Forms.Form
    '***************************************************************
    '
    'Module:    frmMaintenance.frm
    '
    'Description:   This form contains the maintenance functionality of the gauge.
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
    '2009-10-27 fjm         Added Facility Power Loss
    '2009-12-17 fjm         Added Thickness Sensor
    '2009-12-30 fjm         Changed from Timer object for sheet trigger to new thread
    '
    '***************************************************************

    '************************** Enumerations ***********************
    Enum enumStatusBar
        sbState = 0
        sbStatus
        sbTime
    End Enum

    '************************** Locals *****************************
    'Private mSheetTrigger_Thread As Threading.Thread = Nothing
    Private mblnThreadExit As Boolean = False

    Private blnError As Boolean = False
    Private blnConnectionDown As Boolean


    '***************************************************************
    Private Sub frmMaintenance_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Try
            'gOperations.tmrMain.Enabled = False
            'Show First Tab
            Me.SSTab1.SelectedIndex = 0
            'If Not (gMotion.bHome) Then

            ''Start Hardware Check
            'If SetGaugeState(mdlGeneral.enumGaugeState.gsHardwareCheck) Then
            '    gDAQ.StartDAQ(mdlGeneral.enumDAQMode.daqHardware)
            'End If


            'If gLKH.Connect(LKHEthernetOpenParameter) Then
            'gLog.LogMsg("Connected to LKH")
            'gLKH.StartLKH(enumLaserMode.lsrHardware)
            'Else
            'gLog.LogMsg("Error Connecting to LKH")
            'End If


            'Enable Time
            Me.tmrMain.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMaintenance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        'Enable Time
        Me.tmrMain.Enabled = False

        'Clear text boxes of the sensors
        Me.txtThickness.Text = ""
        Me.txtDistance.Text = ""
        Me.txtDistance2.Text = ""
        Me.txtPosition.Text = ""

        'Wait for Thread to exit
        Me.mblnThreadExit = True

        SetGaugeState(enumGaugeState.gsIdle)

    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tmrMain_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrMain.Tick
        On Error Resume Next

        Me.tmrMain.Enabled = False

        'Display Time, Status, and State in Status Bar
        StatusBar.Items.Item(enumStatusBar.sbTime).Text = Now.ToString("HH:mm:ss")
        StatusBar.Items.Item(enumStatusBar.sbStatus).Text = gLog.Status
        StatusBar.Items.Item(enumStatusBar.sbState).Text = GetGaugeState(mdlGeneral.gState)

        If Me.SSTab1.SelectedTab Is Me.tpHardware Then

            DisplayHardware()
        End If

        Me.tmrMain.Enabled = True

    End Sub

    '***************************************************************
    'This subroutine calculates and displays the Velocity and Acceleration data
    Private Sub DisplayHardware()

        On Error Resume Next
        'Display Keyence Info
        Me.txtStatus.Text = gLTG.SensorStatus
        Me.txtThickness.Text = gLTG.LastThickness.ToString(cFormatLTGThickness)
        Me.txtDistance.Text = gLTG.LastDistance.ToString("0.000")
        Me.txtIntensity.Text = gLTG.LastIntensity.ToString("0.000")
        Me.txtPosition.Text = gLTG.LastPosition.ToString("0.000")
        If gLtgSensor = enumLtgController.KeyenceCl3000 Then
            lblLTGDistance2.Visible = True
            txtDistance2.Visible = True
            txtDistance2.Text = gLTG.LastDistance2.ToString("0.000")
        Else
            lblLTGDistance2.Visible = False
            txtDistance2.Visible = False
        End If

    End Sub

End Class