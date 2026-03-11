Option Strict Off
Option Explicit On
Friend Class clsData_Sheet
	'***************************************************************
	'
	'Class:    clsData_Sheet
	'
	'Description:   This class is used for storing the Sheet data.
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
	'03/13/03   fjm         Created
	'06/14/03   fjm         Added Index for Archive Paths based on Purpose
	'12/29/05   fjm         Modifications for combined ACG and LTG gauge.
    '07/10/07   fjm         Added ability to flip ACG sheet orientation
    '2009-12-14 fjm         Added Spike Detection
	'2009-12-17 fjm         Added Thickness Sensor
    '2012-01-13 rkp         Modified for SOLTG
	'***************************************************************
	
	'************************** Constants **************************
	
    '************************** Publics *****************************

    Public Info As New clsData_Info
    Public LTG As clsData_LTG
    '*************************************************************
 	Public Sub New()
        MyBase.New()

        Me.LTG = New clsData_LTG(Me.Info)
    End Sub

	'*************************************************************
	'This subroutine intitialize class
	Public Sub Init()
        'Init LTG, fjm, 2009-12-30
        Me.LTG.Init()
        Me.LTG.Info = Me.Info

        'Initialize Values
        'Me.Info.LeftEdge = 0
        Me.Info.MeasureDT = Now

        'Reset Measured Width
        Me.LTG.SizeWidth_Measured = Me.Info.ProductWidth    'v1.1.7
        Me.LTG.SensorIdxRef = 0
    End Sub


End Class