Option Strict Off
Option Explicit On
Imports System.IO
'***************************************************************
'
'Module:    frmAbout.frm
'
'Description:   This is the About Dialog Box.
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
'2009-11-11 fjm         Created
'
'***************************************************************
Friend Class frmAbout
    Inherits System.Windows.Forms.Form

    Private Sub frmAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblVersion.Text = "Version " & My.Application.Info.Version.Major _
                & "." & My.Application.Info.Version.Minor _
                & "." & My.Application.Info.Version.Build

            Me.lblProductName.Text = My.Application.Info.Title
            'Load Version Notes
            Me.txtVersionNotes.Text = My.Resources.Version_Notes

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class