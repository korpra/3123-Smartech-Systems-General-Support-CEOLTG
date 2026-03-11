<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSheetInformation
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
    Public WithEvents txtWidth As System.Windows.Forms.TextBox
    Public WithEvents txtThickness As System.Windows.Forms.TextBox
    Public WithEvents _Label1_21 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_14 As System.Windows.Forms.Label
    Public WithEvents fraProduct As System.Windows.Forms.GroupBox
    Public WithEvents btnStartDataAcquisition As System.Windows.Forms.Button
    Public WithEvents btnExit As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSheetInformation))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtGlassCode = New System.Windows.Forms.TextBox()
        Me.txtGlassType = New System.Windows.Forms.TextBox()
        Me.txtThickness = New System.Windows.Forms.TextBox()
        Me.fraProduct = New System.Windows.Forms.GroupBox()
        Me.cmbProductFile = New System.Windows.Forms.ComboBox()
        Me.cmbPurpose = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtQASheetWidth = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTrimCompression = New System.Windows.Forms.TextBox()
        Me.txtTrimInlet = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._Label1_21 = New System.Windows.Forms.Label()
        Me._Label1_10 = New System.Windows.Forms.Label()
        Me._Label1_14 = New System.Windows.Forms.Label()
        Me.btnStartDataAcquisition = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpWidthReject = New System.Windows.Forms.GroupBox()
        Me.chkWidthRejectEnable = New System.Windows.Forms.CheckBox()
        Me.txtWidthRejectMin = New System.Windows.Forms.TextBox()
        Me.txtWidthRejectMax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fraProduct.SuspendLayout()
        Me.grpWidthReject.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtGlassCode
        '
        Me.txtGlassCode.AcceptsReturn = True
        Me.txtGlassCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlassCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlassCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlassCode.Location = New System.Drawing.Point(191, 76)
        Me.txtGlassCode.MaxLength = 0
        Me.txtGlassCode.Name = "txtGlassCode"
        Me.txtGlassCode.ReadOnly = True
        Me.txtGlassCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlassCode.Size = New System.Drawing.Size(74, 20)
        Me.txtGlassCode.TabIndex = 67
        Me.txtGlassCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtGlassCode, "Glass Code")
        '
        'txtGlassType
        '
        Me.txtGlassType.AcceptsReturn = True
        Me.txtGlassType.BackColor = System.Drawing.SystemColors.Control
        Me.txtGlassType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlassType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlassType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlassType.Location = New System.Drawing.Point(191, 102)
        Me.txtGlassType.MaxLength = 0
        Me.txtGlassType.Name = "txtGlassType"
        Me.txtGlassType.ReadOnly = True
        Me.txtGlassType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlassType.Size = New System.Drawing.Size(74, 20)
        Me.txtGlassType.TabIndex = 66
        Me.txtGlassType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtGlassType, "Glass Type")
        '
        'txtThickness
        '
        Me.txtThickness.AcceptsReturn = True
        Me.txtThickness.BackColor = System.Drawing.SystemColors.Control
        Me.txtThickness.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtThickness.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThickness.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtThickness.Location = New System.Drawing.Point(191, 128)
        Me.txtThickness.MaxLength = 0
        Me.txtThickness.Name = "txtThickness"
        Me.txtThickness.ReadOnly = True
        Me.txtThickness.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtThickness.Size = New System.Drawing.Size(74, 20)
        Me.txtThickness.TabIndex = 24
        Me.txtThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtThickness, "Product Thickness")
        '
        'fraProduct
        '
        Me.fraProduct.BackColor = System.Drawing.SystemColors.Control
        Me.fraProduct.Controls.Add(Me.cmbProductFile)
        Me.fraProduct.Controls.Add(Me.cmbPurpose)
        Me.fraProduct.Controls.Add(Me.Label17)
        Me.fraProduct.Controls.Add(Me.txtQASheetWidth)
        Me.fraProduct.Controls.Add(Me.Label16)
        Me.fraProduct.Controls.Add(Me.txtTrimCompression)
        Me.fraProduct.Controls.Add(Me.txtTrimInlet)
        Me.fraProduct.Controls.Add(Me.txtGlassCode)
        Me.fraProduct.Controls.Add(Me.txtGlassType)
        Me.fraProduct.Controls.Add(Me.Label14)
        Me.fraProduct.Controls.Add(Me.Label13)
        Me.fraProduct.Controls.Add(Me.Label12)
        Me.fraProduct.Controls.Add(Me.Label11)
        Me.fraProduct.Controls.Add(Me.txtHeight)
        Me.fraProduct.Controls.Add(Me.txtWidth)
        Me.fraProduct.Controls.Add(Me.Label4)
        Me.fraProduct.Controls.Add(Me.txtThickness)
        Me.fraProduct.Controls.Add(Me._Label1_21)
        Me.fraProduct.Controls.Add(Me._Label1_10)
        Me.fraProduct.Controls.Add(Me._Label1_14)
        Me.fraProduct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraProduct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraProduct.Location = New System.Drawing.Point(9, 13)
        Me.fraProduct.Name = "fraProduct"
        Me.fraProduct.Padding = New System.Windows.Forms.Padding(0)
        Me.fraProduct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraProduct.Size = New System.Drawing.Size(392, 285)
        Me.fraProduct.TabIndex = 13
        Me.fraProduct.TabStop = False
        Me.fraProduct.Text = "Product Specification"
        '
        'cmbProductFile
        '
        Me.cmbProductFile.Location = New System.Drawing.Point(159, 20)
        Me.cmbProductFile.Name = "cmbProductFile"
        Me.cmbProductFile.Size = New System.Drawing.Size(230, 22)
        Me.cmbProductFile.TabIndex = 272
        '
        'cmbPurpose
        '
        Me.cmbPurpose.AutoCompleteCustomSource.AddRange(New String() {"Production", "Experiemnt", "Development"})
        Me.cmbPurpose.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPurpose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPurpose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPurpose.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPurpose.Items.AddRange(New Object() {"Development", "Experiment", "Production"})
        Me.cmbPurpose.Location = New System.Drawing.Point(159, 48)
        Me.cmbPurpose.Name = "cmbPurpose"
        Me.cmbPurpose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPurpose.Size = New System.Drawing.Size(230, 22)
        Me.cmbPurpose.Sorted = True
        Me.cmbPurpose.TabIndex = 74
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(3, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(182, 22)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Purpose:"
        '
        'txtQASheetWidth
        '
        Me.txtQASheetWidth.AcceptsReturn = True
        Me.txtQASheetWidth.BackColor = System.Drawing.SystemColors.Control
        Me.txtQASheetWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQASheetWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQASheetWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQASheetWidth.Location = New System.Drawing.Point(191, 258)
        Me.txtQASheetWidth.MaxLength = 0
        Me.txtQASheetWidth.Name = "txtQASheetWidth"
        Me.txtQASheetWidth.ReadOnly = True
        Me.txtQASheetWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQASheetWidth.Size = New System.Drawing.Size(74, 20)
        Me.txtQASheetWidth.TabIndex = 72
        Me.txtQASheetWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(3, 261)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(172, 22)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "QA Sheet Width:"
        '
        'txtTrimCompression
        '
        Me.txtTrimCompression.AcceptsReturn = True
        Me.txtTrimCompression.BackColor = System.Drawing.SystemColors.Control
        Me.txtTrimCompression.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrimCompression.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrimCompression.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrimCompression.Location = New System.Drawing.Point(191, 206)
        Me.txtTrimCompression.MaxLength = 0
        Me.txtTrimCompression.Name = "txtTrimCompression"
        Me.txtTrimCompression.ReadOnly = True
        Me.txtTrimCompression.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrimCompression.Size = New System.Drawing.Size(74, 20)
        Me.txtTrimCompression.TabIndex = 69
        Me.txtTrimCompression.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTrimInlet
        '
        Me.txtTrimInlet.AcceptsReturn = True
        Me.txtTrimInlet.BackColor = System.Drawing.Color.Gold
        Me.txtTrimInlet.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrimInlet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrimInlet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrimInlet.Location = New System.Drawing.Point(191, 232)
        Me.txtTrimInlet.MaxLength = 0
        Me.txtTrimInlet.Name = "txtTrimInlet"
        Me.txtTrimInlet.ReadOnly = True
        Me.txtTrimInlet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrimInlet.Size = New System.Drawing.Size(74, 20)
        Me.txtTrimInlet.TabIndex = 68
        Me.txtTrimInlet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTrimInlet.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(3, 208)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(182, 22)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Trim Compression:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gold
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(3, 234)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(182, 22)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Trim Inlet:"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(3, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(182, 22)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Glass Code:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(3, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(182, 22)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Glass Type:"
        '
        'txtHeight
        '
        Me.txtHeight.AcceptsReturn = True
        Me.txtHeight.BackColor = System.Drawing.SystemColors.Control
        Me.txtHeight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHeight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHeight.Location = New System.Drawing.Point(191, 180)
        Me.txtHeight.MaxLength = 0
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ReadOnly = True
        Me.txtHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHeight.Size = New System.Drawing.Size(74, 20)
        Me.txtHeight.TabIndex = 38
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidth
        '
        Me.txtWidth.AcceptsReturn = True
        Me.txtWidth.BackColor = System.Drawing.SystemColors.Control
        Me.txtWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWidth.Location = New System.Drawing.Point(191, 154)
        Me.txtWidth.MaxLength = 0
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.ReadOnly = True
        Me.txtWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWidth.Size = New System.Drawing.Size(74, 20)
        Me.txtWidth.TabIndex = 38
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(3, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(172, 22)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Product Height:"
        '
        '_Label1_21
        '
        Me._Label1_21.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_21.Location = New System.Drawing.Point(3, 157)
        Me._Label1_21.Name = "_Label1_21"
        Me._Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_21.Size = New System.Drawing.Size(172, 22)
        Me._Label1_21.TabIndex = 37
        Me._Label1_21.Text = "Product Width:"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(3, 130)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(182, 22)
        Me._Label1_10.TabIndex = 28
        Me._Label1_10.Text = "Product Thickness:"
        '
        '_Label1_14
        '
        Me._Label1_14.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_14.Location = New System.Drawing.Point(3, 22)
        Me._Label1_14.Name = "_Label1_14"
        Me._Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_14.Size = New System.Drawing.Size(182, 22)
        Me._Label1_14.TabIndex = 15
        Me._Label1_14.Text = "Product File:"
        '
        'btnStartDataAcquisition
        '
        Me.btnStartDataAcquisition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartDataAcquisition.BackColor = System.Drawing.SystemColors.Control
        Me.btnStartDataAcquisition.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnStartDataAcquisition.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartDataAcquisition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnStartDataAcquisition.Location = New System.Drawing.Point(410, 299)
        Me.btnStartDataAcquisition.Name = "btnStartDataAcquisition"
        Me.btnStartDataAcquisition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStartDataAcquisition.Size = New System.Drawing.Size(112, 52)
        Me.btnStartDataAcquisition.TabIndex = 1
        Me.btnStartDataAcquisition.Text = "Start Data Acquisition"
        Me.btnStartDataAcquisition.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExit.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(410, 357)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExit.Size = New System.Drawing.Size(112, 52)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'grpWidthReject
        '
        Me.grpWidthReject.BackColor = System.Drawing.SystemColors.Control
        Me.grpWidthReject.Controls.Add(Me.chkWidthRejectEnable)
        Me.grpWidthReject.Controls.Add(Me.txtWidthRejectMin)
        Me.grpWidthReject.Controls.Add(Me.txtWidthRejectMax)
        Me.grpWidthReject.Controls.Add(Me.Label6)
        Me.grpWidthReject.Controls.Add(Me.Label7)
        Me.grpWidthReject.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpWidthReject.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpWidthReject.Location = New System.Drawing.Point(9, 304)
        Me.grpWidthReject.Name = "grpWidthReject"
        Me.grpWidthReject.Padding = New System.Windows.Forms.Padding(0)
        Me.grpWidthReject.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grpWidthReject.Size = New System.Drawing.Size(392, 106)
        Me.grpWidthReject.TabIndex = 13
        Me.grpWidthReject.TabStop = False
        Me.grpWidthReject.Text = "Width Reject"
        '
        'chkWidthRejectEnable
        '
        Me.chkWidthRejectEnable.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.chkWidthRejectEnable.Location = New System.Drawing.Point(3, 26)
        Me.chkWidthRejectEnable.Name = "chkWidthRejectEnable"
        Me.chkWidthRejectEnable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkWidthRejectEnable.Size = New System.Drawing.Size(230, 21)
        Me.chkWidthRejectEnable.TabIndex = 70
        Me.chkWidthRejectEnable.Text = "Enable"
        Me.chkWidthRejectEnable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkWidthRejectEnable.UseVisualStyleBackColor = True
        '
        'txtWidthRejectMin
        '
        Me.txtWidthRejectMin.AcceptsReturn = True
        Me.txtWidthRejectMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWidthRejectMin.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidthRejectMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWidthRejectMin.Location = New System.Drawing.Point(191, 52)
        Me.txtWidthRejectMin.MaxLength = 0
        Me.txtWidthRejectMin.Name = "txtWidthRejectMin"
        Me.txtWidthRejectMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWidthRejectMin.Size = New System.Drawing.Size(74, 20)
        Me.txtWidthRejectMin.TabIndex = 67
        Me.txtWidthRejectMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidthRejectMax
        '
        Me.txtWidthRejectMax.AcceptsReturn = True
        Me.txtWidthRejectMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtWidthRejectMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWidthRejectMax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidthRejectMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWidthRejectMax.Location = New System.Drawing.Point(191, 78)
        Me.txtWidthRejectMax.MaxLength = 0
        Me.txtWidthRejectMax.Name = "txtWidthRejectMax"
        Me.txtWidthRejectMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWidthRejectMax.Size = New System.Drawing.Size(74, 20)
        Me.txtWidthRejectMax.TabIndex = 66
        Me.txtWidthRejectMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(3, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(182, 22)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Measured Width Minimum (mm):"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(3, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(182, 22)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Measured Width Maximum (mm):"
        '
        'frmSheetInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(529, 414)
        Me.Controls.Add(Me.grpWidthReject)
        Me.Controls.Add(Me.fraProduct)
        Me.Controls.Add(Me.btnStartDataAcquisition)
        Me.Controls.Add(Me.btnExit)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(5, 32)
        Me.Name = "frmSheetInformation"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sheet Information"
        Me.ToolTip1.SetToolTip(Me, "Glass code")
        Me.fraProduct.ResumeLayout(False)
        Me.fraProduct.PerformLayout()
        Me.grpWidthReject.ResumeLayout(False)
        Me.grpWidthReject.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents txtTrimCompression As System.Windows.Forms.TextBox
    Public WithEvents txtTrimInlet As System.Windows.Forms.TextBox
    Public WithEvents txtGlassCode As System.Windows.Forms.TextBox
    Public WithEvents txtGlassType As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents txtQASheetWidth As System.Windows.Forms.TextBox
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents cmbPurpose As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProductFile As ComboBox
    Public WithEvents txtHeight As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents grpWidthReject As GroupBox
    Friend WithEvents chkWidthRejectEnable As CheckBox
    Public WithEvents txtWidthRejectMin As TextBox
    Public WithEvents txtWidthRejectMax As TextBox
    Public WithEvents Label6 As Label
    Public WithEvents Label7 As Label
#End Region
End Class