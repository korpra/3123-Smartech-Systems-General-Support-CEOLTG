<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMaintenance
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
        InitializeComponent()
        'AddHandler gclsEvent.VelocityUpdate, AddressOf DisplayNewVelocity

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
    Public WithEvents tmrMain As System.Windows.Forms.Timer

    Public WithEvents cmdExit As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button()
        Me._Label1_17 = New System.Windows.Forms.Label()
        Me._Label1_16 = New System.Windows.Forms.Label()
        Me._Label1_13 = New System.Windows.Forms.Label()
        Me._Label1_10 = New System.Windows.Forms.Label()
        Me._Label1_9 = New System.Windows.Forms.Label()
        Me._Label1_8 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me._Label1_34 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tpHardware = New System.Windows.Forms.TabPage()
        Me.fraLTG = New System.Windows.Forms.GroupBox()
        Me.txtIntensity = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.lblLTGIntensity2 = New System.Windows.Forms.Label()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtThickness = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLTGDistance = New System.Windows.Forms.Label()
        Me._Label1_24 = New System.Windows.Forms.Label()
        Me.SSTab1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtDistance2 = New System.Windows.Forms.TextBox()
        Me.lblLTGDistance2 = New System.Windows.Forms.Label()
        Me.StatusBar.SuspendLayout()
        Me.tpHardware.SuspendLayout()
        Me.fraLTG.SuspendLayout()
        Me.SSTab1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button6.Location = New System.Drawing.Point(246, 165)
        Me.Button6.Name = "Button6"
        Me.Button6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button6.Size = New System.Drawing.Size(98, 57)
        Me.Button6.TabIndex = 92
        Me.Button6.Text = "Reset Servo"
        Me.ToolTip1.SetToolTip(Me.Button6, "Home Servo is necesary after a reset.")
        Me.Button6.UseVisualStyleBackColor = False
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 50
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(900, 648)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(112, 42)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        '_Label1_17
        '
        Me._Label1_17.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_17.Location = New System.Drawing.Point(30, 180)
        Me._Label1_17.Name = "_Label1_17"
        Me._Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_17.Size = New System.Drawing.Size(152, 22)
        Me._Label1_17.TabIndex = 66
        Me._Label1_17.Text = "System Status:"
        '
        '_Label1_16
        '
        Me._Label1_16.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_16.Location = New System.Drawing.Point(30, 90)
        Me._Label1_16.Name = "_Label1_16"
        Me._Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_16.Size = New System.Drawing.Size(152, 22)
        Me._Label1_16.TabIndex = 61
        Me._Label1_16.Text = "Servo Homed:"
        '
        '_Label1_13
        '
        Me._Label1_13.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_13.Location = New System.Drawing.Point(30, 150)
        Me._Label1_13.Name = "_Label1_13"
        Me._Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_13.Size = New System.Drawing.Size(152, 22)
        Me._Label1_13.TabIndex = 59
        Me._Label1_13.Text = "Returning:"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(30, 270)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(152, 22)
        Me._Label1_10.TabIndex = 27
        Me._Label1_10.Text = "Position:"
        '
        '_Label1_9
        '
        Me._Label1_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(30, 240)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(152, 22)
        Me._Label1_9.TabIndex = 25
        Me._Label1_9.Text = "Error Status:"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(30, 210)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(152, 22)
        Me._Label1_8.TabIndex = 23
        Me._Label1_8.Text = "Axis Status:"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(30, 120)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(152, 22)
        Me._Label1_0.TabIndex = 21
        Me._Label1_0.Text = "Home:"
        '
        '_Label1_34
        '
        Me._Label1_34.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_34.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_34.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_34.Location = New System.Drawing.Point(30, 60)
        Me._Label1_34.Name = "_Label1_34"
        Me._Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_34.Size = New System.Drawing.Size(152, 22)
        Me._Label1_34.TabIndex = 17
        Me._Label1_34.Text = "Faulted:"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(30, 300)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(152, 22)
        Me._Label1_3.TabIndex = 10
        Me._Label1_3.Text = "Commanded Position:"
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(30, 330)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(152, 22)
        Me._Label1_1.TabIndex = 8
        Me._Label1_1.Text = "Commanded Velocity:"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(30, 30)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(152, 22)
        Me._Label1_2.TabIndex = 6
        Me._Label1_2.Text = "Ready:"
        '
        'StatusBar
        '
        Me.StatusBar.AutoSize = False
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusBar.Location = New System.Drawing.Point(0, 694)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.ShowItemToolTips = True
        Me.StatusBar.Size = New System.Drawing.Size(1013, 22)
        Me.StatusBar.TabIndex = 10
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripStatusLabel1.Text = "Idle"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.ToolTipText = "Gauge State"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(798, 22)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "Ready"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel3.ToolTipText = "Gauge Status"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel4.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripStatusLabel4.Text = "HH:mm:ss"
        Me.ToolStripStatusLabel4.ToolTipText = "Current Time"
        '
        'tpHardware
        '
        Me.tpHardware.BackColor = System.Drawing.SystemColors.Control
        Me.tpHardware.Controls.Add(Me.fraLTG)
        Me.tpHardware.Location = New System.Drawing.Point(4, 26)
        Me.tpHardware.Name = "tpHardware"
        Me.tpHardware.Size = New System.Drawing.Size(889, 658)
        Me.tpHardware.TabIndex = 2
        Me.tpHardware.Text = "Hardware"
        '
        'fraLTG
        '
        Me.fraLTG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraLTG.BackColor = System.Drawing.SystemColors.Control
        Me.fraLTG.Controls.Add(Me.txtDistance2)
        Me.fraLTG.Controls.Add(Me.lblLTGDistance2)
        Me.fraLTG.Controls.Add(Me.txtIntensity)
        Me.fraLTG.Controls.Add(Me.Label1)
        Me.fraLTG.Controls.Add(Me.txtPosition)
        Me.fraLTG.Controls.Add(Me.lblLTGIntensity2)
        Me.fraLTG.Controls.Add(Me.txtDistance)
        Me.fraLTG.Controls.Add(Me.txtStatus)
        Me.fraLTG.Controls.Add(Me.txtThickness)
        Me.fraLTG.Controls.Add(Me.Label2)
        Me.fraLTG.Controls.Add(Me.lblLTGDistance)
        Me.fraLTG.Controls.Add(Me._Label1_24)
        Me.fraLTG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraLTG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraLTG.Location = New System.Drawing.Point(0, 3)
        Me.fraLTG.Name = "fraLTG"
        Me.fraLTG.Padding = New System.Windows.Forms.Padding(0)
        Me.fraLTG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraLTG.Size = New System.Drawing.Size(883, 176)
        Me.fraLTG.TabIndex = 95
        Me.fraLTG.TabStop = False
        Me.fraLTG.Text = "Thickness"
        '
        'txtIntensity
        '
        Me.txtIntensity.AcceptsReturn = True
        Me.txtIntensity.BackColor = System.Drawing.SystemColors.Menu
        Me.txtIntensity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIntensity.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtIntensity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIntensity.Location = New System.Drawing.Point(86, 112)
        Me.txtIntensity.MaxLength = 0
        Me.txtIntensity.Name = "txtIntensity"
        Me.txtIntensity.ReadOnly = True
        Me.txtIntensity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIntensity.Size = New System.Drawing.Size(112, 26)
        Me.txtIntensity.TabIndex = 106
        Me.txtIntensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Intensity:"
        '
        'txtPosition
        '
        Me.txtPosition.AcceptsReturn = True
        Me.txtPosition.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPosition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPosition.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtPosition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPosition.Location = New System.Drawing.Point(86, 144)
        Me.txtPosition.MaxLength = 0
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.txtPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPosition.Size = New System.Drawing.Size(112, 26)
        Me.txtPosition.TabIndex = 104
        Me.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLTGIntensity2
        '
        Me.lblLTGIntensity2.BackColor = System.Drawing.SystemColors.Control
        Me.lblLTGIntensity2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLTGIntensity2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLTGIntensity2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLTGIntensity2.Location = New System.Drawing.Point(5, 153)
        Me.lblLTGIntensity2.Name = "lblLTGIntensity2"
        Me.lblLTGIntensity2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLTGIntensity2.Size = New System.Drawing.Size(75, 15)
        Me.lblLTGIntensity2.TabIndex = 105
        Me.lblLTGIntensity2.Text = "Position:"
        '
        'txtDistance
        '
        Me.txtDistance.AcceptsReturn = True
        Me.txtDistance.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDistance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDistance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDistance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDistance.Location = New System.Drawing.Point(86, 80)
        Me.txtDistance.MaxLength = 0
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.ReadOnly = True
        Me.txtDistance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDistance.Size = New System.Drawing.Size(112, 26)
        Me.txtDistance.TabIndex = 98
        Me.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStatus
        '
        Me.txtStatus.AcceptsReturn = True
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Menu
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStatus.Location = New System.Drawing.Point(86, 16)
        Me.txtStatus.MaxLength = 0
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.Size = New System.Drawing.Size(794, 26)
        Me.txtStatus.TabIndex = 94
        '
        'txtThickness
        '
        Me.txtThickness.AcceptsReturn = True
        Me.txtThickness.BackColor = System.Drawing.SystemColors.Menu
        Me.txtThickness.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtThickness.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtThickness.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtThickness.Location = New System.Drawing.Point(86, 48)
        Me.txtThickness.MaxLength = 0
        Me.txtThickness.Name = "txtThickness"
        Me.txtThickness.ReadOnly = True
        Me.txtThickness.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtThickness.Size = New System.Drawing.Size(112, 26)
        Me.txtThickness.TabIndex = 94
        Me.txtThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Status:"
        '
        'lblLTGDistance
        '
        Me.lblLTGDistance.BackColor = System.Drawing.SystemColors.Control
        Me.lblLTGDistance.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLTGDistance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLTGDistance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLTGDistance.Location = New System.Drawing.Point(5, 89)
        Me.lblLTGDistance.Name = "lblLTGDistance"
        Me.lblLTGDistance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLTGDistance.Size = New System.Drawing.Size(72, 15)
        Me.lblLTGDistance.TabIndex = 99
        Me.lblLTGDistance.Text = "Distance:"
        '
        '_Label1_24
        '
        Me._Label1_24.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_24.Location = New System.Drawing.Point(5, 57)
        Me._Label1_24.Name = "_Label1_24"
        Me._Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_24.Size = New System.Drawing.Size(81, 15)
        Me._Label1_24.TabIndex = 95
        Me._Label1_24.Text = "Thickness:"
        '
        'SSTab1
        '
        Me.SSTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SSTab1.Controls.Add(Me.tpHardware)
        Me.SSTab1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSTab1.HotTrack = True
        Me.SSTab1.ItemSize = New System.Drawing.Size(42, 22)
        Me.SSTab1.Location = New System.Drawing.Point(0, 3)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 2
        Me.SSTab1.Size = New System.Drawing.Size(897, 688)
        Me.SSTab1.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(889, 658)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hardware"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Location = New System.Drawing.Point(602, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 131)
        Me.GroupBox3.TabIndex = 262
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Keyence Settings"
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(173, 91)
        Me.TextBox1.MaxLength = 0
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(74, 20)
        Me.TextBox1.TabIndex = 264
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(9, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(159, 22)
        Me.Label20.TabIndex = 263
        Me.Label20.Text = "Stationary Sensor 2 IP"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(9, 60)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(158, 22)
        Me.Label22.TabIndex = 262
        Me.Label22.Text = "Stationary Sensor 1 IP"
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Location = New System.Drawing.Point(173, 27)
        Me.TextBox2.MaxLength = 0
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox2.Size = New System.Drawing.Size(74, 20)
        Me.TextBox2.TabIndex = 259
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsReturn = True
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox3.Location = New System.Drawing.Point(173, 59)
        Me.TextBox3.MaxLength = 0
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox3.Size = New System.Drawing.Size(74, 20)
        Me.TextBox3.TabIndex = 261
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(9, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(148, 22)
        Me.Label23.TabIndex = 258
        Me.Label23.Text = "Moving Sensor IP"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Location = New System.Drawing.Point(329, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(235, 131)
        Me.GroupBox4.TabIndex = 96
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Servo Properties"
        '
        'TextBox4
        '
        Me.TextBox4.AcceptsReturn = True
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.Location = New System.Drawing.Point(150, 31)
        Me.TextBox4.MaxLength = 0
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox4.Size = New System.Drawing.Size(74, 20)
        Me.TextBox4.TabIndex = 259
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsReturn = True
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox5.Location = New System.Drawing.Point(150, 62)
        Me.TextBox5.MaxLength = 0
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox5.Size = New System.Drawing.Size(74, 20)
        Me.TextBox5.TabIndex = 261
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(20, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(124, 22)
        Me.Label24.TabIndex = 260
        Me.Label24.Text = "Acceleration:"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(20, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(124, 22)
        Me.Label25.TabIndex = 258
        Me.Label25.Text = "Current Velocity "
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.TextBox6)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.TextBox7)
        Me.GroupBox5.Controls.Add(Me.TextBox8)
        Me.GroupBox5.Controls.Add(Me.TextBox9)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.TextBox10)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.TextBox11)
        Me.GroupBox5.Controls.Add(Me.TextBox12)
        Me.GroupBox5.Controls.Add(Me.TextBox13)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.TextBox14)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.TextBox15)
        Me.GroupBox5.Controls.Add(Me.TextBox16)
        Me.GroupBox5.Controls.Add(Me.TextBox17)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox5.Location = New System.Drawing.Point(3, 182)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox5.Size = New System.Drawing.Size(863, 243)
        Me.GroupBox5.TabIndex = 95
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Thickness"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(659, 68)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(141, 24)
        Me.Label26.TabIndex = 125
        Me.Label26.Text = "Stationary Sensor 2"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(409, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(141, 24)
        Me.Label27.TabIndex = 124
        Me.Label27.Text = "Stationary Sensor 1"
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsReturn = True
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox6.Location = New System.Drawing.Point(748, 173)
        Me.TextBox6.MaxLength = 0
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox6.Size = New System.Drawing.Size(112, 26)
        Me.TextBox6.TabIndex = 122
        Me.TextBox6.Text = "????"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(659, 182)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(83, 15)
        Me.Label28.TabIndex = 123
        Me.Label28.Text = "Intensity2:"
        '
        'TextBox7
        '
        Me.TextBox7.AcceptsReturn = True
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox7.Location = New System.Drawing.Point(748, 202)
        Me.TextBox7.MaxLength = 0
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox7.Size = New System.Drawing.Size(112, 26)
        Me.TextBox7.TabIndex = 120
        Me.TextBox7.Text = "????"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.AcceptsReturn = True
        Me.TextBox8.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox8.Location = New System.Drawing.Point(748, 144)
        Me.TextBox8.MaxLength = 0
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox8.Size = New System.Drawing.Size(112, 26)
        Me.TextBox8.TabIndex = 118
        Me.TextBox8.Text = "????"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox9
        '
        Me.TextBox9.AcceptsReturn = True
        Me.TextBox9.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox9.Location = New System.Drawing.Point(748, 115)
        Me.TextBox9.MaxLength = 0
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox9.Size = New System.Drawing.Size(112, 26)
        Me.TextBox9.TabIndex = 116
        Me.TextBox9.Text = "????"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(659, 211)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(67, 15)
        Me.Label29.TabIndex = 121
        Me.Label29.Text = "Error:"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(659, 153)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(83, 15)
        Me.Label30.TabIndex = 119
        Me.Label30.Text = "Intensity1:"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(659, 124)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(67, 15)
        Me.Label32.TabIndex = 117
        Me.Label32.Text = "Thickness:"
        '
        'TextBox10
        '
        Me.TextBox10.AcceptsReturn = True
        Me.TextBox10.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox10.Location = New System.Drawing.Point(495, 175)
        Me.TextBox10.MaxLength = 0
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox10.Size = New System.Drawing.Size(112, 26)
        Me.TextBox10.TabIndex = 114
        Me.TextBox10.Text = "????"
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(409, 185)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(80, 15)
        Me.Label33.TabIndex = 115
        Me.Label33.Text = "Intensity2:"
        '
        'TextBox11
        '
        Me.TextBox11.AcceptsReturn = True
        Me.TextBox11.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox11.Location = New System.Drawing.Point(495, 204)
        Me.TextBox11.MaxLength = 0
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox11.Size = New System.Drawing.Size(112, 26)
        Me.TextBox11.TabIndex = 112
        Me.TextBox11.Text = "????"
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox12
        '
        Me.TextBox12.AcceptsReturn = True
        Me.TextBox12.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox12.Location = New System.Drawing.Point(495, 146)
        Me.TextBox12.MaxLength = 0
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox12.Size = New System.Drawing.Size(112, 26)
        Me.TextBox12.TabIndex = 110
        Me.TextBox12.Text = "????"
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox13
        '
        Me.TextBox13.AcceptsReturn = True
        Me.TextBox13.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox13.Location = New System.Drawing.Point(495, 117)
        Me.TextBox13.MaxLength = 0
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox13.Size = New System.Drawing.Size(112, 26)
        Me.TextBox13.TabIndex = 108
        Me.TextBox13.Text = "????"
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(409, 214)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(67, 15)
        Me.Label34.TabIndex = 113
        Me.Label34.Text = "Error:"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(409, 156)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(80, 15)
        Me.Label35.TabIndex = 111
        Me.Label35.Text = "Intensity1:"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(409, 124)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(67, 15)
        Me.Label36.TabIndex = 109
        Me.Label36.Text = "Thickness:"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(502, 31)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(272, 24)
        Me.Label37.TabIndex = 107
        Me.Label37.Text = "Stationary Sensor Thickness Information"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(48, 31)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(248, 24)
        Me.Label38.TabIndex = 106
        Me.Label38.Text = "Moving Sensor Thickness Information"
        '
        'TextBox14
        '
        Me.TextBox14.AcceptsReturn = True
        Me.TextBox14.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox14.Location = New System.Drawing.Point(129, 173)
        Me.TextBox14.MaxLength = 0
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox14.Size = New System.Drawing.Size(112, 26)
        Me.TextBox14.TabIndex = 104
        Me.TextBox14.Text = "????"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(48, 182)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(75, 15)
        Me.Label39.TabIndex = 105
        Me.Label39.Text = "Intensity2:"
        '
        'TextBox15
        '
        Me.TextBox15.AcceptsReturn = True
        Me.TextBox15.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox15.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox15.Location = New System.Drawing.Point(129, 202)
        Me.TextBox15.MaxLength = 0
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox15.Size = New System.Drawing.Size(112, 26)
        Me.TextBox15.TabIndex = 100
        Me.TextBox15.Text = "????"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox16
        '
        Me.TextBox16.AcceptsReturn = True
        Me.TextBox16.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox16.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox16.Location = New System.Drawing.Point(129, 144)
        Me.TextBox16.MaxLength = 0
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox16.Size = New System.Drawing.Size(112, 26)
        Me.TextBox16.TabIndex = 98
        Me.TextBox16.Text = "????"
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox17
        '
        Me.TextBox17.AcceptsReturn = True
        Me.TextBox17.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox17.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox17.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox17.Location = New System.Drawing.Point(129, 115)
        Me.TextBox17.MaxLength = 0
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox17.Size = New System.Drawing.Size(112, 26)
        Me.TextBox17.TabIndex = 94
        Me.TextBox17.Text = "????"
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(48, 211)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(67, 15)
        Me.Label40.TabIndex = 101
        Me.Label40.Text = "Error:"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(48, 153)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(72, 15)
        Me.Label41.TabIndex = 99
        Me.Label41.Text = "Intensity1:"
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(48, 124)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(67, 15)
        Me.Label42.TabIndex = 95
        Me.Label42.Text = "Thickness:"
        '
        'GroupBox6
        '
        Me.GroupBox6.AccessibleDescription = "\"
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.TextBox18)
        Me.GroupBox6.Controls.Add(Me.TextBox19)
        Me.GroupBox6.Controls.Add(Me.TextBox20)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.Label45)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox6.Location = New System.Drawing.Point(3, 13)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox6.Size = New System.Drawing.Size(311, 131)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "DAQ Board"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(3, 92)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(82, 22)
        Me.Label43.TabIndex = 100
        Me.Label43.Text = "Counter 1:"
        '
        'TextBox18
        '
        Me.TextBox18.AcceptsReturn = True
        Me.TextBox18.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox18.Location = New System.Drawing.Point(142, 89)
        Me.TextBox18.MaxLength = 0
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox18.Size = New System.Drawing.Size(138, 20)
        Me.TextBox18.TabIndex = 99
        Me.TextBox18.Text = "????"
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox19
        '
        Me.TextBox19.AcceptsReturn = True
        Me.TextBox19.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox19.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox19.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox19.Location = New System.Drawing.Point(143, 60)
        Me.TextBox19.MaxLength = 0
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox19.Size = New System.Drawing.Size(137, 20)
        Me.TextBox19.TabIndex = 47
        Me.TextBox19.Text = "????"
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox20
        '
        Me.TextBox20.AcceptsReturn = True
        Me.TextBox20.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox20.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox20.Location = New System.Drawing.Point(143, 30)
        Me.TextBox20.MaxLength = 0
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox20.Size = New System.Drawing.Size(137, 20)
        Me.TextBox20.TabIndex = 45
        Me.TextBox20.TabStop = False
        Me.TextBox20.Text = "????"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(3, 62)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(82, 22)
        Me.Label44.TabIndex = 48
        Me.Label44.Text = "Encoder 1:"
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(3, 32)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(132, 22)
        Me.Label45.TabIndex = 46
        Me.Label45.Text = "DAQ Status:"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox7.Controls.Add(Me.Button1)
        Me.GroupBox7.Controls.Add(Me.Button2)
        Me.GroupBox7.Controls.Add(Me.Button3)
        Me.GroupBox7.Controls.Add(Me.Button4)
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.Button5)
        Me.GroupBox7.Controls.Add(Me.Button6)
        Me.GroupBox7.Controls.Add(Me.TextBox23)
        Me.GroupBox7.Controls.Add(Me.TextBox24)
        Me.GroupBox7.Controls.Add(Me.Label48)
        Me.GroupBox7.Controls.Add(Me.Label49)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox7.Location = New System.Drawing.Point(4, 431)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(878, 224)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Servo"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(38, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(98, 57)
        Me.Button1.TabIndex = 102
        Me.Button1.Text = "Go Home"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(142, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(98, 57)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "Enable Drive"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button3.Location = New System.Drawing.Point(38, 165)
        Me.Button3.Name = "Button3"
        Me.Button3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button3.Size = New System.Drawing.Size(98, 57)
        Me.Button3.TabIndex = 100
        Me.Button3.Text = "Disable Drive"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Location = New System.Drawing.Point(246, 89)
        Me.Button4.Name = "Button4"
        Me.Button4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button4.Size = New System.Drawing.Size(98, 57)
        Me.Button4.TabIndex = 99
        Me.Button4.Text = "Move"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TextBox21)
        Me.GroupBox8.Controls.Add(Me.Label46)
        Me.GroupBox8.Controls.Add(Me.TextBox22)
        Me.GroupBox8.Controls.Add(Me.Label47)
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox8.Location = New System.Drawing.Point(494, 15)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(377, 170)
        Me.GroupBox8.TabIndex = 98
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Axis Status"
        '
        'TextBox21
        '
        Me.TextBox21.AcceptsReturn = True
        Me.TextBox21.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox21.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox21.Location = New System.Drawing.Point(127, 57)
        Me.TextBox21.MaxLength = 0
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox21.Size = New System.Drawing.Size(83, 20)
        Me.TextBox21.TabIndex = 67
        Me.TextBox21.TabStop = False
        Me.TextBox21.Text = "????"
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.SystemColors.Control
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(7, 60)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(130, 16)
        Me.Label46.TabIndex = 68
        Me.Label46.Text = "Servo Homed:"
        '
        'TextBox22
        '
        Me.TextBox22.AcceptsReturn = True
        Me.TextBox22.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox22.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox22.Location = New System.Drawing.Point(127, 36)
        Me.TextBox22.MaxLength = 0
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox22.Size = New System.Drawing.Size(83, 20)
        Me.TextBox22.TabIndex = 67
        Me.TextBox22.TabStop = False
        Me.TextBox22.Text = "????"
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(7, 39)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(130, 16)
        Me.Label47.TabIndex = 68
        Me.Label47.Text = "Faulted:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button5.Location = New System.Drawing.Point(142, 89)
        Me.Button5.Name = "Button5"
        Me.Button5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button5.Size = New System.Drawing.Size(98, 57)
        Me.Button5.TabIndex = 91
        Me.Button5.Text = "Home Servo"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'TextBox23
        '
        Me.TextBox23.AcceptsReturn = True
        Me.TextBox23.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox23.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox23.Location = New System.Drawing.Point(122, 43)
        Me.TextBox23.MaxLength = 0
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.ReadOnly = True
        Me.TextBox23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox23.Size = New System.Drawing.Size(243, 20)
        Me.TextBox23.TabIndex = 87
        Me.TextBox23.TabStop = False
        Me.TextBox23.Text = "0000 0000 0000 0000 0000 0000 0000 0000"
        Me.TextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox24
        '
        Me.TextBox24.AcceptsReturn = True
        Me.TextBox24.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox24.Location = New System.Drawing.Point(122, 18)
        Me.TextBox24.MaxLength = 0
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.ReadOnly = True
        Me.TextBox24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox24.Size = New System.Drawing.Size(243, 20)
        Me.TextBox24.TabIndex = 88
        Me.TextBox24.TabStop = False
        Me.TextBox24.Text = "0000 0000 0000 0000 0000 0000 0000 0000"
        Me.TextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.Control
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(29, 44)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(132, 17)
        Me.Label48.TabIndex = 90
        Me.Label48.Text = "Error Status:"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.Control
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(29, 21)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(132, 17)
        Me.Label49.TabIndex = 89
        Me.Label49.Text = "System Status:"
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(889, 658)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage1"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtDistance2
        '
        Me.txtDistance2.AcceptsReturn = True
        Me.txtDistance2.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDistance2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDistance2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDistance2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDistance2.Location = New System.Drawing.Point(290, 80)
        Me.txtDistance2.MaxLength = 0
        Me.txtDistance2.Name = "txtDistance2"
        Me.txtDistance2.ReadOnly = True
        Me.txtDistance2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDistance2.Size = New System.Drawing.Size(112, 26)
        Me.txtDistance2.TabIndex = 108
        Me.txtDistance2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLTGDistance2
        '
        Me.lblLTGDistance2.BackColor = System.Drawing.SystemColors.Control
        Me.lblLTGDistance2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLTGDistance2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLTGDistance2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLTGDistance2.Location = New System.Drawing.Point(209, 89)
        Me.lblLTGDistance2.Name = "lblLTGDistance2"
        Me.lblLTGDistance2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLTGDistance2.Size = New System.Drawing.Size(72, 15)
        Me.lblLTGDistance2.TabIndex = 109
        Me.lblLTGDistance2.Text = "Distance2:"
        '
        'frmMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1013, 716)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.cmdExit)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(5, 32)
        Me.Name = "frmMaintenance"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Maintenance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.tpHardware.ResumeLayout(False)
        Me.fraLTG.ResumeLayout(False)
        Me.fraLTG.PerformLayout()
        Me.SSTab1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents _Label1_17 As System.Windows.Forms.Label
    Public WithEvents _Label1_16 As System.Windows.Forms.Label
    Public WithEvents _Label1_13 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents _Label1_34 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Public WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents SSTab1 As System.Windows.Forms.TabControl
    Public WithEvents tpHardware As System.Windows.Forms.TabPage
    Public WithEvents fraLTG As System.Windows.Forms.GroupBox
    Public WithEvents txtPosition As System.Windows.Forms.TextBox
    Public WithEvents lblLTGIntensity2 As System.Windows.Forms.Label
    Public WithEvents txtDistance As System.Windows.Forms.TextBox
    Public WithEvents txtThickness As System.Windows.Forms.TextBox
    Public WithEvents lblLTGDistance As System.Windows.Forms.Label
    Public WithEvents _Label1_24 As System.Windows.Forms.Label
    Public WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents TextBox2 As System.Windows.Forms.TextBox
    Public WithEvents TextBox3 As System.Windows.Forms.TextBox
    Public WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents TextBox4 As System.Windows.Forms.TextBox
    Public WithEvents TextBox5 As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents TextBox6 As System.Windows.Forms.TextBox
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents TextBox7 As System.Windows.Forms.TextBox
    Public WithEvents TextBox8 As System.Windows.Forms.TextBox
    Public WithEvents TextBox9 As System.Windows.Forms.TextBox
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents TextBox10 As System.Windows.Forms.TextBox
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents TextBox11 As System.Windows.Forms.TextBox
    Public WithEvents TextBox12 As System.Windows.Forms.TextBox
    Public WithEvents TextBox13 As System.Windows.Forms.TextBox
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents TextBox14 As System.Windows.Forms.TextBox
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents TextBox15 As System.Windows.Forms.TextBox
    Public WithEvents TextBox16 As System.Windows.Forms.TextBox
    Public WithEvents TextBox17 As System.Windows.Forms.TextBox
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents TextBox18 As System.Windows.Forms.TextBox
    Public WithEvents TextBox19 As System.Windows.Forms.TextBox
    Public WithEvents TextBox20 As System.Windows.Forms.TextBox
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Button2 As System.Windows.Forms.Button
    Public WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Public WithEvents TextBox21 As System.Windows.Forms.TextBox
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents TextBox22 As System.Windows.Forms.TextBox
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Button5 As System.Windows.Forms.Button
    Public WithEvents Button6 As System.Windows.Forms.Button
    Public WithEvents TextBox23 As System.Windows.Forms.TextBox
    Public WithEvents TextBox24 As System.Windows.Forms.TextBox
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Public WithEvents txtIntensity As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtStatus As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtDistance2 As TextBox
    Public WithEvents lblLTGDistance2 As Label
#End Region
End Class