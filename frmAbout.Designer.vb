<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAbout
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents lblPlatform As System.Windows.Forms.Label
    Public WithEvents lblProductName As System.Windows.Forms.Label
    Public WithEvents lblCompanyProduct As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.btnOK = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblPlatform = New System.Windows.Forms.Label
        Me.lblCompanyProduct = New System.Windows.Forms.Label
        Me.lblProductName = New System.Windows.Forms.Label
        Me.txtVersionNotes = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLastBuild = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(258, 686)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(102, 51)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lblLastBuild)
        Me.Frame1.Controls.Add(Me.lblVersion)
        Me.Frame1.Controls.Add(Me.lblPlatform)
        Me.Frame1.Controls.Add(Me.lblCompanyProduct)
        Me.Frame1.Controls.Add(Me.lblProductName)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(10, 5)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(600, 172)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersion.Location = New System.Drawing.Point(421, 106)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(176, 24)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPlatform
        '
        Me.lblPlatform.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlatform.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlatform.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlatform.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlatform.Location = New System.Drawing.Point(421, 74)
        Me.lblPlatform.Name = "lblPlatform"
        Me.lblPlatform.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlatform.Size = New System.Drawing.Size(176, 32)
        Me.lblPlatform.TabIndex = 2
        Me.lblPlatform.Text = "Windows 7"
        Me.lblPlatform.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCompanyProduct
        '
        Me.lblCompanyProduct.AutoSize = True
        Me.lblCompanyProduct.BackColor = System.Drawing.SystemColors.Control
        Me.lblCompanyProduct.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCompanyProduct.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyProduct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCompanyProduct.Location = New System.Drawing.Point(17, 19)
        Me.lblCompanyProduct.Name = "lblCompanyProduct"
        Me.lblCompanyProduct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCompanyProduct.Size = New System.Drawing.Size(155, 29)
        Me.lblCompanyProduct.TabIndex = 3
        Me.lblCompanyProduct.Text = "Corning Inc."
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProductName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProductName.Location = New System.Drawing.Point(17, 54)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProductName.Size = New System.Drawing.Size(104, 29)
        Me.lblProductName.TabIndex = 4
        Me.lblProductName.Text = "Product"
        '
        'txtVersionNotes
        '
        Me.txtVersionNotes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersionNotes.Location = New System.Drawing.Point(12, 207)
        Me.txtVersionNotes.Multiline = True
        Me.txtVersionNotes.Name = "txtVersionNotes"
        Me.txtVersionNotes.ReadOnly = True
        Me.txtVersionNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVersionNotes.Size = New System.Drawing.Size(595, 473)
        Me.txtVersionNotes.TabIndex = 9
        Me.txtVersionNotes.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(597, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Version Notes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLastBuild
        '
        Me.lblLastBuild.BackColor = System.Drawing.SystemColors.Control
        Me.lblLastBuild.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLastBuild.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastBuild.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastBuild.Location = New System.Drawing.Point(421, 130)
        Me.lblLastBuild.Name = "lblLastBuild"
        Me.lblLastBuild.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLastBuild.Size = New System.Drawing.Size(176, 24)
        Me.lblLastBuild.TabIndex = 5
        Me.lblLastBuild.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(620, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVersionNotes)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(22, 118)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVersionNotes As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblLastBuild As System.Windows.Forms.Label
#End Region
End Class