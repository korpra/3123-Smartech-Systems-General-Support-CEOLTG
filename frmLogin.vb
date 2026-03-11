Option Strict Off
Option Explicit On
Friend Class frmLogin
	Inherits System.Windows.Forms.Form
	'***************************************************************
	'
	'Module:    frmLogin.frm
	'
	'Description:   This is the user to enter passwords for access to
	'               various application features.
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
	'
	'***************************************************************
	
	'***************************************************************
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtPassword.Text = ""
        Me.txtPassword.Focus()
    End Sub
	
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

End Class