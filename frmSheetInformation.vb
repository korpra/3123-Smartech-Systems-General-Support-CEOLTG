Option Strict Off
Option Explicit On
Imports System
Imports System.IO
Imports System.Collections.Generic

Friend Class frmSheetInformation
    Inherits System.Windows.Forms.Form


    '***************************************************************
    '
    'Module:    frmProductSetup.frm
    '
    'Description:   This form is used to define the Product Information for the Run.
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
    '2009-09-28 fjm         Save LastProductCode to use as DEFAULT
    '2010-02-25 fjm         Renamed form from SheetInformation to ProductSetup
    '2016-10-10 fjm         Updated for CEOLTG
    '
    '***************************************************************

#Region "Publics"
    Public moSheet As clsData_Sheet
    Public LastChangeDateTime As DateTime = DateTime.Now
#End Region

#Region "Local Classes"
    Private Class clsSpecFile
        Public SpecFileName As String = String.Empty
        Public ProductCode As String = String.Empty

        Public Sub New(sSpecFileName As String)
            Try
                Me.SpecFileName = sSpecFileName

                'Init Product Code to filename then try to parse
                Me.ProductCode = sSpecFileName
                Me.ProductCode = sSpecFileName.Substring(sSpecFileName.LastIndexOf("_") + 1)
                Me.ProductCode = Me.ProductCode.Substring(0, Me.ProductCode.Length - 4)

            Catch ex As Exception

            End Try

        End Sub
    End Class
#End Region

#Region "Privates"
    Private _bLoading As Boolean
    Private _lstSpecFiles As New List(Of clsSpecFile)
    Private _sSelectedProductFile As String = String.Empty
    Private _oSpec As CorningMes.Data.Specs.Spec = Nothing

#End Region

#Region "Constructor"
    Private Sub frmSheetInformation_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            Me._bLoading = True

            'List Products
            Me.ListProducts(Me.cmbProductFile)

            'Set Privous Product Setup
            Me.cmbProductFile.Text = gConfig.LastProductFile
            Me.cmbPurpose.Text = gConfig.LastPurpose

            'If not Purpose, set Production
            If Me.cmbPurpose.Text = String.Empty Then
                Me.cmbPurpose.Text = "Production"
            End If

            'Width Reject Logic, v1.1.18
            If Not gConfig.WidthRejectVisible Then
                Me.grpWidthReject.Visible = False
                Me.Size = New Drawing.Size(545, 340)
            End If
            Me.chkWidthRejectEnable.Checked = gConfig.WidthRejectEnable
            Me.txtWidthRejectMin.Text = gConfig.WidthRejectMin.ToString("0.000")
            Me.txtWidthRejectMax.Text = gConfig.WidthRejectMax.ToString("0.000")

            'Loading Complete
            Me._bLoading = False

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
        _bLoading = False
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnExit.Click
        'Me.Close()
        Me.Hide()
    End Sub

    Private Sub btnStartDataAcquisition_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnStartDataAcquisition.Click
        Try
            'Check data entered
            If Me.cmbProductFile.SelectedIndex = -1 Or Me.cmbProductFile.Text.Trim = String.Empty Then
                MsgBox("Please enter a valid Product Code!", MsgBoxStyle.Critical, "Save Product Error")
            ElseIf Me.cmbPurpose.SelectedIndex = -1 Or Me.cmbPurpose.Text.Trim = String.Empty Then
                MsgBox("Please enter a valid Purpose!", MsgBoxStyle.Critical, "Save Product Error")
            Else
                'Save Data
                With Me.moSheet.Info
                    .GaugeID = gConfig.GaugeID
                    .TankID = gConfig.TankID
                    .GlassCode = Me.txtGlassCode.Text
                    .GlassType = Me.txtGlassType.Text
                    .TrimInlet = Val(Me.txtTrimInlet.Text)
                    .TrimCompression = Val(Me.txtTrimCompression.Text)
                    .ProductCode = Me.cmbProductFile.Text
                    .Thickness = Val(Me.txtThickness.Text)
                    .QASheetWidth = Val(Me.txtQASheetWidth.Text)

                    .Purpose = Me.cmbPurpose.Text
                    .ProductWidth = Val(Me.txtWidth.Text)

                    'NOTE: hardcoded GlassRefIdx = 1 whereever used, don't need to do the lookup 
                    'in the Glass Index file, keeping code for now just in case customer decides to implement
                    'this feature again...leoc
                    '.GlassRefIdx = GetIndexOfRefraction(cFileGlassIndex, .GlassCode)
                End With

                'Save Specs
                gSpec = Me._oSpec

                'Save Config Data
                With gConfig
                    .LastProductFile = Me.cmbProductFile.Text
                    .LastPurpose = Me.cmbPurpose.Text

                    'Width Reject, v1.1.18
                    .WidthRejectEnable = chkWidthRejectEnable.Checked
                    .WidthRejectMin = Val(txtWidthRejectMin.Text)
                    .WidthRejectMax = Val(txtWidthRejectMax.Text)

                    'NOTE: not saving lastglassrefidx to the config file anymore...leoc
                    '.LastGlassRefIdx = Me.moSheet.Info.GlassRefIdx

                    .SaveConfig()
                End With

                'Set Gauge State - Sheet Running
                If SetGaugeState(enumGaugeState.gsSheet) = enumError.errSuccess Then
                    'Set Gauge Sub State - Start Scan
                    gSubState = enumSubState.ssStart
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    gLog.LogMsg("SetGaugeState Error")
                End If

                'Unload Form
                Me.Hide()
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "btnStartDataAcquisition_Click", ex)
        End Try
    End Sub

    Private Sub cmbProductCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductFile.SelectedIndexChanged
        Try
            If Not Me._bLoading Then
                Me.LastChangeDateTime = DateTime.Now
            End If

            'First Clear fields:
            Me.txtGlassCode.Text = ""
            Me.txtGlassType.Text = ""
            Me.txtThickness.Text = ""
            Me.txtWidth.Text = ""
            Me.txtHeight.Text = ""
            Me.txtTrimCompression.Text = ""
            Me.txtTrimInlet.Text = ""
            Me.txtQASheetWidth.Text = ""

            If Me.cmbProductFile.Enabled AndAlso Me.cmbProductFile.Text <> String.Empty Then
                'Read Product File
                Me._oSpec = Me.ReadSpecFile(Me.cmbProductFile.Text)
                If _oSpec IsNot Nothing Then
                    Dim dWidth As Double = 0
                    Dim dQAWidth As Double = 0
                    Dim dTrimComp As Double = 0

                    If _oSpec.GlassCode IsNot Nothing Then
                        Me.txtGlassCode.Text = Me._oSpec.GlassCode
                    End If

                    If _oSpec.GlassType IsNot Nothing Then
                        Me.txtGlassType.Text = Me._oSpec.GlassType
                    End If

                    'Updated from TargetThickness to TargetThick, fjm , 3/16/2025
                    If _oSpec.Thickness.TargetThick.HasValue Then
                        Me.txtThickness.Text = Math.Round(_oSpec.Thickness.TargetThick.Value.Distance, 3).ToString("0.000")
                    End If

                    If _oSpec.Squareness.NominalWidth.HasValue Then
                        dWidth = _oSpec.Squareness.NominalWidth.Value
                        Me.txtWidth.Text = dWidth.ToString("0.000")
                    End If

                    If _oSpec.Squareness.NominalLength.HasValue Then
                        Me.txtHeight.Text = _oSpec.Squareness.NominalLength.Value.ToString("0.000")
                    End If

                    If _oSpec.QAOffset.HasValue Then
                        dTrimComp = _oSpec.QAOffset.Value.Distance
                        'Truncate to a decimal
                        Me.txtTrimCompression.Text = Math.Truncate(dTrimComp).ToString("0")
                    End If

                    If _oSpec.QualityWidth.HasValue Then
                        dQAWidth = _oSpec.QualityWidth.Value.Distance
                        'Me.QASheetWidth = Math.Round(tmpQAWidth * 25.4, 1)
                        Me.txtQASheetWidth.Text = Math.Round(dQAWidth * 25.4, 0).ToString("0")
                    End If

                    If dQAWidth > 0 AndAlso gConfig.CalculatedQATrimEnabled Then
                        Dim QAFull As Double = dQAWidth * 25.4
                        Me.txtQASheetWidth.Text = Math.Ceiling(QAFull).ToString("0")
                    End If

                    'Calculate Inlet Trim
                    'Note:  Appears to be mixing inch (dQAWidth) and mm (dTrimComp)
                    Me.txtTrimInlet.Text = (dWidth - dQAWidth - dTrimComp).ToString("0.000")
                End If
            End If
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "Error Reading Product File", ex)
            MsgBox("Error Reading Product File" & vbCr & Err.Description, MsgBoxStyle.Critical, "Product File Error!")
        End Try
    End Sub
#End Region

#Region "Private Functions"
    Private Sub ListProducts(ByRef cmbCombo As System.Windows.Forms.ComboBox)
        'Clear Lists
        Me._lstSpecFiles.Clear()
        cmbCombo.Items.Clear()

        'Display List of Products
        Dim sFile As String = Dir(FormatPath(gConfig.SpecFilesPath) & gConfig.SpecFilenameFormat)
        While sFile <> ""
            Dim sTemp As String = ExtractProductCode(sFile)
            Dim oSpecFile As New clsSpecFile(sFile)
            Me._lstSpecFiles.Add(oSpecFile)
            cmbCombo.Items.Add(oSpecFile.ProductCode)

            'Get next file
            sFile = Dir()
        End While
    End Sub

    Private Function ExtractProductCode(ByRef sSpecFileName As String) As String
        Try

            Dim iTok As Short
            Dim sProductCode As String = sSpecFileName

            'First Remove Path
            iTok = InStr(sProductCode, "\")
            While iTok > 0
                sProductCode = sProductCode.Substring(Len(sProductCode) - iTok)
                iTok = InStr(sProductCode, "\")
            End While

            'Now Remove Extension
            iTok = InStr(sProductCode, ".")
            If iTok > 0 Then
                sProductCode = sProductCode.Substring(0, iTok - 1)
            End If

            'Return Filename
            Return sProductCode

        Catch ex As Exception
            Return sSpecFileName
        End Try

    End Function

    Private Function ReadSpecFile(ByVal sProductCode As String) As CorningMes.Data.Specs.Spec
        Try
            Dim oSpec As CorningMes.Data.Specs.Spec = Nothing

            'Get Filename for Product Code
            Dim sFileName As String = Me.GetSpecFileName(sProductCode)
            If String.IsNullOrEmpty(sFileName) Then
                gLog.LogErr("Spec File not found for product code: " & sProductCode)
            Else
                'Open Spec File
                Dim sFile As String = FormatPath(gConfig.SpecFilesPath) & sFileName
                oSpec = CorningMes.Data.Specs.SpecManager.ReadSpecs(sFile, True).Item(Now).Item
                If oSpec Is Nothing Then
                    gLog.LogErr("Spec File not found: " & sFile)
                Else
                    'Success    
                    gLog.LogMsg("Read Spec File: " & sFile)
                End If
            End If

            Return oSpec

            Exit Function
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return Nothing
        End Try
    End Function

    Private Function GetSpecFileName(sProductCode As String) As String
        Try
            Dim sFileName As String = String.Empty

            For Each oSpecFile As clsSpecFile In Me._lstSpecFiles
                If oSpecFile.ProductCode = sProductCode Then
                    sFileName = oSpecFile.SpecFileName
                    Exit For
                End If
            Next

            Return sFileName
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return String.Empty
        End Try
    End Function
#End Region

End Class
