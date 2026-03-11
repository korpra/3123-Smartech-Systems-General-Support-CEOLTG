Option Strict Off
Option Explicit On
'***************************************************************
'
'Module:    frmProcess.frm
'
'Description:   This is for post analysis of the data.
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
'03/09/03   fjm         Created
'09/03/03   fjm         Added Check for Previous Instance
'12/22/08   dfs         Changed to Online Cord Gauge
'
'***************************************************************
Friend Class frmSplash
    Inherits System.Windows.Forms.Form

    'Private initializeFlag As Boolean = True


    'Private Sub frmSplash_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Me.Refresh()
    '    Application.DoEvents()
    '    If (initializeFlag) Then
    '        initializeFlag = False
    '        System.Threading.Thread.Sleep(30000)
    '        If ApplicationInit() <> enumError.errSuccess Then
    '            Me.Close()
    '        Else
    '            If gDAQ Is Nothing Then
    '                Me.lblDAQmx.Visible = True
    '                Me.optOperations.Enabled = False
    '                Me.optProcessEngineering.Checked = True
    '            End If

    '            btnOK.Enabled = True
    '            btnCancel.Enabled = True
    '            Me.LabelInitializing.Visible = False
    '        End If

    '    End If


    'End Sub

    Private Sub frmSplash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            lblVersion.Text = "Version " & My.Application.Info.Version.Major _
                & "." & My.Application.Info.Version.Minor _
                & "." & My.Application.Info.Version.Build
            lblProductName.Text = My.Application.Info.Title


            If ApplicationInit() <> enumError.errSuccess Then
                Me.Close()
            Else
                
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSplash_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ApplicationExit()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If optOperations.Checked Then
                Me.btnOK.Tag = "1"
                Me.Visible = False
                frmOperations.ShowDialog()
            Else
                'Get Password
                With frmLogin
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        'Check Password
                        If Not gConfig.CheckAdminPW(.txtPassword.Text) Then
                            gLog.LogErr("Invalid Password for access to Process")
                        Else
                            Me.btnOK.Tag = "1"
                            Me.Visible = False
                            'frmProcess.ShowDialog()
                        End If
                    End If
                End With
            End If

            If Me.btnOK.Tag = "1" Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub



    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    gMotion.Disconnect()
    '    gMotion.KillACRObject()
    '    gMotion = Nothing
    '    mdlGeneral.RebuildGMotion()

    'End Sub
End Class