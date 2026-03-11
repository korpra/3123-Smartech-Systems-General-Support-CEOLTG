<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSplash
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
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents btnOK As System.Windows.Forms.Button
    Public WithEvents optProcessEngineering As System.Windows.Forms.RadioButton
    Public WithEvents optOperations As System.Windows.Forms.RadioButton
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents lblPlatform As System.Windows.Forms.Label
    Public WithEvents lblProductName As System.Windows.Forms.Label
    Public WithEvents lblCompanyProduct As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.optProcessEngineering = New System.Windows.Forms.RadioButton()
        Me.optOperations = New System.Windows.Forms.RadioButton()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.LabelInitializing = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblPlatform = New System.Windows.Forms.Label()
        Me.lblCompanyProduct = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblDAQmx = New System.Windows.Forms.Label()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(203, 681)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(102, 51)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.optProcessEngineering)
        Me.Frame2.Controls.Add(Me.optOperations)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(200, 592)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(222, 77)
        Me.Frame2.TabIndex = 5
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Application"
        '
        'optProcessEngineering
        '
        Me.optProcessEngineering.BackColor = System.Drawing.SystemColors.Control
        Me.optProcessEngineering.Cursor = System.Windows.Forms.Cursors.Default
        Me.optProcessEngineering.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optProcessEngineering.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optProcessEngineering.Location = New System.Drawing.Point(20, 46)
        Me.optProcessEngineering.Name = "optProcessEngineering"
        Me.optProcessEngineering.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optProcessEngineering.Size = New System.Drawing.Size(172, 22)
        Me.optProcessEngineering.TabIndex = 7
        Me.optProcessEngineering.TabStop = True
        Me.optProcessEngineering.Text = "Process Engineering"
        Me.optProcessEngineering.UseVisualStyleBackColor = False
        Me.optProcessEngineering.Visible = False
        '
        'optOperations
        '
        Me.optOperations.BackColor = System.Drawing.SystemColors.Control
        Me.optOperations.Checked = True
        Me.optOperations.Cursor = System.Windows.Forms.Cursors.Default
        Me.optOperations.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOperations.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optOperations.Location = New System.Drawing.Point(20, 16)
        Me.optOperations.Name = "optOperations"
        Me.optOperations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optOperations.Size = New System.Drawing.Size(172, 22)
        Me.optOperations.TabIndex = 6
        Me.optOperations.TabStop = True
        Me.optOperations.Text = "Operations"
        Me.optOperations.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.LabelInitializing)
        Me.Frame1.Controls.Add(Me.lblVersion)
        Me.Frame1.Controls.Add(Me.lblPlatform)
        Me.Frame1.Controls.Add(Me.lblCompanyProduct)
        Me.Frame1.Controls.Add(Me.lblProductName)
        Me.Frame1.Controls.Add(Me.PictureBox1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(10, 5)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(600, 572)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        '
        'LabelInitializing
        '
        Me.LabelInitializing.BackColor = System.Drawing.SystemColors.Control
        Me.LabelInitializing.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelInitializing.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInitializing.ForeColor = System.Drawing.Color.Red
        Me.LabelInitializing.Location = New System.Drawing.Point(78, 536)
        Me.LabelInitializing.Name = "LabelInitializing"
        Me.LabelInitializing.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelInitializing.Size = New System.Drawing.Size(441, 24)
        Me.LabelInitializing.TabIndex = 12
        Me.LabelInitializing.Text = "Initializing..."
        Me.LabelInitializing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelInitializing.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersion.Location = New System.Drawing.Point(418, 493)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(176, 24)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPlatform
        '
        Me.lblPlatform.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlatform.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlatform.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlatform.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlatform.Location = New System.Drawing.Point(418, 461)
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
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(105, 157)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(390, 279)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(320, 681)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(102, 51)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblDAQmx
        '
        Me.lblDAQmx.BackColor = System.Drawing.SystemColors.Control
        Me.lblDAQmx.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDAQmx.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDAQmx.ForeColor = System.Drawing.Color.Red
        Me.lblDAQmx.Location = New System.Drawing.Point(88, 565)
        Me.lblDAQmx.Name = "lblDAQmx"
        Me.lblDAQmx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDAQmx.Size = New System.Drawing.Size(441, 24)
        Me.lblDAQmx.TabIndex = 11
        Me.lblDAQmx.Text = "NI DAQmx drivers not loaded.  Operations disabled!"
        Me.lblDAQmx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDAQmx.Visible = False
        '
        'frmSplash
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(620, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDAQmx)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(22, 118)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lblDAQmx As System.Windows.Forms.Label
    Public WithEvents LabelInitializing As System.Windows.Forms.Label
#End Region
End Class