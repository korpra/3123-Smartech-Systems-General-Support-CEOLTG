<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOperations
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
    'Public WithEvents gphGrading As NationalInstruments.UI.WindowsForms.ScatterGraph
    'Public WithEvents gphGrading As AxCWUIControlsLib.AxCWGraph
    Public WithEvents tmrMain As System.Windows.Forms.Timer
    Public WithEvents txtThickness As System.Windows.Forms.TextBox
    Public WithEvents txtSize As System.Windows.Forms.TextBox
    Public WithEvents txtProductCode As System.Windows.Forms.TextBox
    Public WithEvents txtGlassCode As System.Windows.Forms.TextBox
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents _Label1_4 As System.Windows.Forms.Label
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents grpSheetInfo As System.Windows.Forms.GroupBox
    Public WithEvents lblGaugeState As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Public WithEvents btnSheetInformation As System.Windows.Forms.Button
    Public WithEvents btnMaintenance As System.Windows.Forms.Button
    Public WithEvents btnExit As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperations))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtPrecitecRefIdx = New System.Windows.Forms.TextBox()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.grpSheetInfo = New System.Windows.Forms.GroupBox()
        Me.txtQASheetWidth = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtThickness = New System.Windows.Forms.TextBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.txtGlassCode = New System.Windows.Forms.TextBox()
        Me._Label1_5 = New System.Windows.Forms.Label()
        Me._Label1_4 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.lblGaugeState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSheetInformation = New System.Windows.Forms.Button()
        Me.btnMaintenance = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLogFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfigOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfigSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfigReRead = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGaugeComJudge = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStop = New System.Windows.Forms.Button()
        Me._Label1_7 = New System.Windows.Forms.Label()
        Me.txtBODID = New System.Windows.Forms.TextBox()
        Me._Label1_6 = New System.Windows.Forms.Label()
        Me.txtGaugeID = New System.Windows.Forms.TextBox()
        Me.GroupBoxGauge = New System.Windows.Forms.GroupBox()
        Me.lblDropIfReject_Disabled = New System.Windows.Forms.Label()
        Me.lblEngineerOutputEnabled = New System.Windows.Forms.Label()
        Me.tpDistance = New System.Windows.Forms.TabPage()
        Me.gphDisplacement = New NationalInstruments.UI.WindowsForms.ScatterGraph()
        Me.ScatterPlot5 = New NationalInstruments.UI.ScatterPlot()
        Me.XAxis1 = New NationalInstruments.UI.XAxis()
        Me.YAxis1 = New NationalInstruments.UI.YAxis()
        Me.ScatterPlot6 = New NationalInstruments.UI.ScatterPlot()
        Me.tpThickness = New System.Windows.Forms.TabPage()
        Me.gphThickness = New NationalInstruments.UI.WindowsForms.ScatterGraph()
        Me.XyPointAnnotation1 = New NationalInstruments.UI.XYPointAnnotation()
        Me.XAxis2 = New NationalInstruments.UI.XAxis()
        Me.YAxis2 = New NationalInstruments.UI.YAxis()
        Me.XyPointAnnotation2 = New NationalInstruments.UI.XYPointAnnotation()
        Me.ScatterPlotQuality = New NationalInstruments.UI.ScatterPlot()
        Me.YAxisQuality = New NationalInstruments.UI.YAxis()
        Me.ScatterPlot3 = New NationalInstruments.UI.ScatterPlot()
        Me.ScatterPlot2 = New NationalInstruments.UI.ScatterPlot()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.SSTab1 = New System.Windows.Forms.TabControl()
        Me.txtLTGGoodPointsLocated = New System.Windows.Forms.TextBox()
        Me.lblMeasuredWidth = New System.Windows.Forms.Label()
        Me.txtLastMeasurementTime = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLTGBadConsecutive = New System.Windows.Forms.TextBox()
        Me.lblOverallBadPts = New System.Windows.Forms.Label()
        Me.txtLTGBadOverall = New System.Windows.Forms.TextBox()
        Me.lblConsecutiveBadPts = New System.Windows.Forms.Label()
        Me.lblGoodPoints = New System.Windows.Forms.Label()
        Me.txtThickness_MeasuredWidth = New System.Windows.Forms.TextBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtQAThicknessRng = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQAThicknessMax = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQAThicknessMin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtQAThicknessAvg = New System.Windows.Forms.TextBox()
        Me.txtQAEnd = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQAStart = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVBSOffset = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRejectReason = New System.Windows.Forms.Label()
        Me.txtSheetUID = New System.Windows.Forms.TextBox()
        Me.txtSurfaceVariation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnViewLog = New System.Windows.Forms.Button()
        Me.btnViewConfig = New System.Windows.Forms.Button()
        Me.btnReReadConfig = New System.Windows.Forms.Button()
        Me.grpSheetInfo.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBoxGauge.SuspendLayout()
        Me.tpDistance.SuspendLayout()
        CType(Me.gphDisplacement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpThickness.SuspendLayout()
        CType(Me.gphThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SSTab1.SuspendLayout()
        Me.grpResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPrecitecRefIdx
        '
        Me.txtPrecitecRefIdx.AcceptsReturn = True
        Me.txtPrecitecRefIdx.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecitecRefIdx.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecitecRefIdx.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecitecRefIdx.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrecitecRefIdx.Location = New System.Drawing.Point(950, 95)
        Me.txtPrecitecRefIdx.MaxLength = 0
        Me.txtPrecitecRefIdx.Name = "txtPrecitecRefIdx"
        Me.txtPrecitecRefIdx.ReadOnly = True
        Me.txtPrecitecRefIdx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrecitecRefIdx.Size = New System.Drawing.Size(67, 20)
        Me.txtPrecitecRefIdx.TabIndex = 264
        Me.txtPrecitecRefIdx.TabStop = False
        Me.txtPrecitecRefIdx.Text = "0.0"
        Me.txtPrecitecRefIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtPrecitecRefIdx, "Read from CHRocodile")
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 10
        '
        'grpSheetInfo
        '
        Me.grpSheetInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSheetInfo.BackColor = System.Drawing.SystemColors.Control
        Me.grpSheetInfo.Controls.Add(Me.txtQASheetWidth)
        Me.grpSheetInfo.Controls.Add(Me.Label6)
        Me.grpSheetInfo.Controls.Add(Me.txtThickness)
        Me.grpSheetInfo.Controls.Add(Me.txtSize)
        Me.grpSheetInfo.Controls.Add(Me.txtProductCode)
        Me.grpSheetInfo.Controls.Add(Me.txtGlassCode)
        Me.grpSheetInfo.Controls.Add(Me._Label1_5)
        Me.grpSheetInfo.Controls.Add(Me._Label1_4)
        Me.grpSheetInfo.Controls.Add(Me._Label1_3)
        Me.grpSheetInfo.Controls.Add(Me._Label1_2)
        Me.grpSheetInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSheetInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSheetInfo.Location = New System.Drawing.Point(441, 3)
        Me.grpSheetInfo.Name = "grpSheetInfo"
        Me.grpSheetInfo.Padding = New System.Windows.Forms.Padding(0)
        Me.grpSheetInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grpSheetInfo.Size = New System.Drawing.Size(590, 92)
        Me.grpSheetInfo.TabIndex = 10
        Me.grpSheetInfo.TabStop = False
        Me.grpSheetInfo.Text = "Product"
        '
        'txtQASheetWidth
        '
        Me.txtQASheetWidth.AcceptsReturn = True
        Me.txtQASheetWidth.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQASheetWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQASheetWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQASheetWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQASheetWidth.Location = New System.Drawing.Point(481, 43)
        Me.txtQASheetWidth.MaxLength = 0
        Me.txtQASheetWidth.Name = "txtQASheetWidth"
        Me.txtQASheetWidth.ReadOnly = True
        Me.txtQASheetWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQASheetWidth.Size = New System.Drawing.Size(100, 20)
        Me.txtQASheetWidth.TabIndex = 50
        Me.txtQASheetWidth.Text = "????"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(341, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(176, 23)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "QA Sheet Width (mm):"
        '
        'txtThickness
        '
        Me.txtThickness.AcceptsReturn = True
        Me.txtThickness.BackColor = System.Drawing.SystemColors.Menu
        Me.txtThickness.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtThickness.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThickness.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtThickness.Location = New System.Drawing.Point(151, 70)
        Me.txtThickness.MaxLength = 0
        Me.txtThickness.Name = "txtThickness"
        Me.txtThickness.ReadOnly = True
        Me.txtThickness.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtThickness.Size = New System.Drawing.Size(100, 20)
        Me.txtThickness.TabIndex = 17
        Me.txtThickness.Text = "????"
        '
        'txtSize
        '
        Me.txtSize.AcceptsReturn = True
        Me.txtSize.BackColor = System.Drawing.SystemColors.Menu
        Me.txtSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSize.Location = New System.Drawing.Point(481, 17)
        Me.txtSize.MaxLength = 0
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSize.Size = New System.Drawing.Size(100, 20)
        Me.txtSize.TabIndex = 16
        Me.txtSize.Text = "????"
        '
        'txtProductCode
        '
        Me.txtProductCode.AcceptsReturn = True
        Me.txtProductCode.BackColor = System.Drawing.SystemColors.Menu
        Me.txtProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProductCode.Location = New System.Drawing.Point(151, 17)
        Me.txtProductCode.MaxLength = 0
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductCode.Size = New System.Drawing.Size(100, 20)
        Me.txtProductCode.TabIndex = 15
        Me.txtProductCode.Text = "????"
        '
        'txtGlassCode
        '
        Me.txtGlassCode.AcceptsReturn = True
        Me.txtGlassCode.BackColor = System.Drawing.SystemColors.Menu
        Me.txtGlassCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlassCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlassCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlassCode.Location = New System.Drawing.Point(151, 44)
        Me.txtGlassCode.MaxLength = 0
        Me.txtGlassCode.Name = "txtGlassCode"
        Me.txtGlassCode.ReadOnly = True
        Me.txtGlassCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlassCode.Size = New System.Drawing.Size(100, 20)
        Me.txtGlassCode.TabIndex = 14
        '
        '_Label1_5
        '
        Me._Label1_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(5, 68)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(112, 18)
        Me._Label1_5.TabIndex = 28
        Me._Label1_5.Text = "Thickness (mm):"
        '
        '_Label1_4
        '
        Me._Label1_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_4.Location = New System.Drawing.Point(341, 17)
        Me._Label1_4.Name = "_Label1_4"
        Me._Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_4.Size = New System.Drawing.Size(145, 23)
        Me._Label1_4.TabIndex = 27
        Me._Label1_4.Text = "Product Width (mm):"
        '
        '_Label1_3
        '
        Me._Label1_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(5, 18)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(112, 18)
        Me._Label1_3.TabIndex = 26
        Me._Label1_3.Text = "Product Code:"
        '
        '_Label1_2
        '
        Me._Label1_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(5, 43)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(112, 18)
        Me._Label1_2.TabIndex = 25
        Me._Label1_2.Text = "Glass Code:"
        '
        'StatusBar
        '
        Me.StatusBar.AutoSize = False
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblGaugeState, Me.lblStatus, Me.lblTime})
        Me.StatusBar.Location = New System.Drawing.Point(0, 727)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.ShowItemToolTips = True
        Me.StatusBar.Size = New System.Drawing.Size(1153, 22)
        Me.StatusBar.TabIndex = 9
        '
        'lblGaugeState
        '
        Me.lblGaugeState.AutoSize = False
        Me.lblGaugeState.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblGaugeState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblGaugeState.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGaugeState.Name = "lblGaugeState"
        Me.lblGaugeState.Size = New System.Drawing.Size(100, 22)
        Me.lblGaugeState.Text = "Idle"
        Me.lblGaugeState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGaugeState.ToolTipText = "Gauge State"
        '
        'lblStatus
        '
        Me.lblStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(938, 22)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Ready"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStatus.ToolTipText = "Gauge Status"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = False
        Me.lblTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.lblTime.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 22)
        Me.lblTime.Text = "HH:mm:ss"
        Me.lblTime.ToolTipText = "Current Time"
        '
        'btnSheetInformation
        '
        Me.btnSheetInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSheetInformation.BackColor = System.Drawing.SystemColors.Control
        Me.btnSheetInformation.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSheetInformation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSheetInformation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSheetInformation.Location = New System.Drawing.Point(1039, 12)
        Me.btnSheetInformation.Name = "btnSheetInformation"
        Me.btnSheetInformation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSheetInformation.Size = New System.Drawing.Size(108, 52)
        Me.btnSheetInformation.TabIndex = 5
        Me.btnSheetInformation.Text = "&Sheet Information"
        Me.btnSheetInformation.UseVisualStyleBackColor = False
        '
        'btnMaintenance
        '
        Me.btnMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaintenance.BackColor = System.Drawing.SystemColors.Control
        Me.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMaintenance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnMaintenance.Location = New System.Drawing.Point(1039, 70)
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMaintenance.Size = New System.Drawing.Size(108, 52)
        Me.btnMaintenance.TabIndex = 2
        Me.btnMaintenance.Text = "Maintenance"
        Me.btnMaintenance.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExit.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExit.Location = New System.Drawing.Point(1041, 693)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExit.Size = New System.Drawing.Size(108, 52)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogFile, Me.mnuConfig, Me.ToolStripSeparator2, Me.mnuAbout})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowCheckMargin = True
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(170, 76)
        '
        'mnuLogFile
        '
        Me.mnuLogFile.Name = "mnuLogFile"
        Me.mnuLogFile.Size = New System.Drawing.Size(169, 22)
        Me.mnuLogFile.Text = "Log File"
        '
        'mnuConfig
        '
        Me.mnuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfigOpen, Me.mnuConfigSave, Me.mnuConfigReRead})
        Me.mnuConfig.Name = "mnuConfig"
        Me.mnuConfig.Size = New System.Drawing.Size(169, 22)
        Me.mnuConfig.Text = "Configuration File"
        '
        'mnuConfigOpen
        '
        Me.mnuConfigOpen.Name = "mnuConfigOpen"
        Me.mnuConfigOpen.Size = New System.Drawing.Size(113, 22)
        Me.mnuConfigOpen.Text = "Open"
        '
        'mnuConfigSave
        '
        Me.mnuConfigSave.Name = "mnuConfigSave"
        Me.mnuConfigSave.Size = New System.Drawing.Size(113, 22)
        Me.mnuConfigSave.Text = "Save"
        '
        'mnuConfigReRead
        '
        Me.mnuConfigReRead.Name = "mnuConfigReRead"
        Me.mnuConfigReRead.Size = New System.Drawing.Size(113, 22)
        Me.mnuConfigReRead.Text = "ReRead"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(169, 22)
        Me.mnuAbout.Text = "About CEOLTG"
        '
        'mnuGaugeComJudge
        '
        Me.mnuGaugeComJudge.Name = "mnuGaugeComJudge"
        Me.mnuGaugeComJudge.Size = New System.Drawing.Size(187, 22)
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackColor = System.Drawing.SystemColors.Control
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnStop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnStop.Location = New System.Drawing.Point(1041, 638)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStop.Size = New System.Drawing.Size(108, 52)
        Me.btnStop.TabIndex = 261
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(10, 18)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(112, 18)
        Me._Label1_7.TabIndex = 23
        Me._Label1_7.Text = "BOD ID:"
        '
        'txtBODID
        '
        Me.txtBODID.AcceptsReturn = True
        Me.txtBODID.BackColor = System.Drawing.SystemColors.Menu
        Me.txtBODID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBODID.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBODID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBODID.Location = New System.Drawing.Point(76, 17)
        Me.txtBODID.MaxLength = 0
        Me.txtBODID.Name = "txtBODID"
        Me.txtBODID.ReadOnly = True
        Me.txtBODID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBODID.Size = New System.Drawing.Size(82, 20)
        Me.txtBODID.TabIndex = 12
        Me.txtBODID.Text = "????"
        '
        '_Label1_6
        '
        Me._Label1_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(10, 43)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(112, 18)
        Me._Label1_6.TabIndex = 29
        Me._Label1_6.Text = "Gauge ID:"
        '
        'txtGaugeID
        '
        Me.txtGaugeID.AcceptsReturn = True
        Me.txtGaugeID.BackColor = System.Drawing.SystemColors.Menu
        Me.txtGaugeID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGaugeID.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGaugeID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGaugeID.Location = New System.Drawing.Point(76, 44)
        Me.txtGaugeID.MaxLength = 0
        Me.txtGaugeID.Name = "txtGaugeID"
        Me.txtGaugeID.ReadOnly = True
        Me.txtGaugeID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGaugeID.Size = New System.Drawing.Size(82, 20)
        Me.txtGaugeID.TabIndex = 18
        Me.txtGaugeID.Text = "????"
        '
        'GroupBoxGauge
        '
        Me.GroupBoxGauge.Controls.Add(Me.txtGaugeID)
        Me.GroupBoxGauge.Controls.Add(Me._Label1_6)
        Me.GroupBoxGauge.Controls.Add(Me.txtBODID)
        Me.GroupBoxGauge.Controls.Add(Me._Label1_7)
        Me.GroupBoxGauge.Controls.Add(Me.lblDropIfReject_Disabled)
        Me.GroupBoxGauge.Controls.Add(Me.lblEngineerOutputEnabled)
        Me.GroupBoxGauge.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxGauge.Location = New System.Drawing.Point(8, 3)
        Me.GroupBoxGauge.Name = "GroupBoxGauge"
        Me.GroupBoxGauge.Size = New System.Drawing.Size(427, 92)
        Me.GroupBoxGauge.TabIndex = 266
        Me.GroupBoxGauge.TabStop = False
        Me.GroupBoxGauge.Text = "Gauge"
        '
        'lblDropIfReject_Disabled
        '
        Me.lblDropIfReject_Disabled.BackColor = System.Drawing.Color.Yellow
        Me.lblDropIfReject_Disabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDropIfReject_Disabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDropIfReject_Disabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDropIfReject_Disabled.ForeColor = System.Drawing.Color.Red
        Me.lblDropIfReject_Disabled.Location = New System.Drawing.Point(216, 43)
        Me.lblDropIfReject_Disabled.Name = "lblDropIfReject_Disabled"
        Me.lblDropIfReject_Disabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDropIfReject_Disabled.Size = New System.Drawing.Size(148, 18)
        Me.lblDropIfReject_Disabled.TabIndex = 30
        Me.lblDropIfReject_Disabled.Text = "Drop If Reject Disabled"
        Me.lblDropIfReject_Disabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEngineerOutputEnabled
        '
        Me.lblEngineerOutputEnabled.BackColor = System.Drawing.SystemColors.Control
        Me.lblEngineerOutputEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEngineerOutputEnabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEngineerOutputEnabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEngineerOutputEnabled.ForeColor = System.Drawing.Color.Red
        Me.lblEngineerOutputEnabled.Location = New System.Drawing.Point(216, 18)
        Me.lblEngineerOutputEnabled.Name = "lblEngineerOutputEnabled"
        Me.lblEngineerOutputEnabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEngineerOutputEnabled.Size = New System.Drawing.Size(148, 18)
        Me.lblEngineerOutputEnabled.TabIndex = 30
        Me.lblEngineerOutputEnabled.Text = "Engineer Output Enabled"
        Me.lblEngineerOutputEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tpDistance
        '
        Me.tpDistance.Controls.Add(Me.gphDisplacement)
        Me.tpDistance.Location = New System.Drawing.Point(4, 26)
        Me.tpDistance.Name = "tpDistance"
        Me.tpDistance.Size = New System.Drawing.Size(1031, 489)
        Me.tpDistance.TabIndex = 3
        Me.tpDistance.Text = "Displacement"
        Me.tpDistance.UseVisualStyleBackColor = True
        '
        'gphDisplacement
        '
        Me.gphDisplacement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gphDisplacement.Caption = "Displacement"
        Me.gphDisplacement.Location = New System.Drawing.Point(0, 0)
        Me.gphDisplacement.Name = "gphDisplacement"
        Me.gphDisplacement.PlotAreaColor = System.Drawing.Color.White
        Me.gphDisplacement.Plots.AddRange(New NationalInstruments.UI.ScatterPlot() {Me.ScatterPlot5, Me.ScatterPlot6})
        Me.gphDisplacement.Size = New System.Drawing.Size(894, 473)
        Me.gphDisplacement.TabIndex = 82
        Me.gphDisplacement.XAxes.AddRange(New NationalInstruments.UI.XAxis() {Me.XAxis1})
        Me.gphDisplacement.YAxes.AddRange(New NationalInstruments.UI.YAxis() {Me.YAxis1})
        '
        'ScatterPlot5
        '
        Me.ScatterPlot5.XAxis = Me.XAxis1
        Me.ScatterPlot5.YAxis = Me.YAxis1
        '
        'XAxis1
        '
        Me.XAxis1.Caption = "Position"
        Me.XAxis1.MajorDivisions.GridColor = System.Drawing.Color.Gray
        Me.XAxis1.MajorDivisions.GridVisible = True
        Me.XAxis1.MajorDivisions.LabelFormat = New NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1")
        '
        'YAxis1
        '
        Me.YAxis1.Caption = "Distance(mm)"
        Me.YAxis1.EditRangeNumericFormatMode = NationalInstruments.UI.NumericFormatMode.CreateGenericMode("F0")
        Me.YAxis1.MajorDivisions.GridColor = System.Drawing.Color.Gray
        Me.YAxis1.MajorDivisions.GridVisible = True
        Me.YAxis1.MajorDivisions.LabelFormat = New NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F3")
        Me.YAxis1.Mode = NationalInstruments.UI.AxisMode.Fixed
        '
        'ScatterPlot6
        '
        Me.ScatterPlot6.LineColor = System.Drawing.Color.Red
        Me.ScatterPlot6.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor
        Me.ScatterPlot6.XAxis = Me.XAxis1
        Me.ScatterPlot6.YAxis = Me.YAxis1
        '
        'tpThickness
        '
        Me.tpThickness.Controls.Add(Me.gphThickness)
        Me.tpThickness.Controls.Add(Me.Label22)
        Me.tpThickness.Controls.Add(Me.Label21)
        Me.tpThickness.Controls.Add(Me.lbl1)
        Me.tpThickness.Controls.Add(Me.lbl2)
        Me.tpThickness.Location = New System.Drawing.Point(4, 26)
        Me.tpThickness.Name = "tpThickness"
        Me.tpThickness.Size = New System.Drawing.Size(1031, 489)
        Me.tpThickness.TabIndex = 2
        Me.tpThickness.Text = "Thickness"
        Me.tpThickness.UseVisualStyleBackColor = True
        '
        'gphThickness
        '
        Me.gphThickness.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gphThickness.Annotations.AddRange(New NationalInstruments.UI.XYAnnotation() {Me.XyPointAnnotation1, Me.XyPointAnnotation2})
        Me.gphThickness.Caption = "Thickness"
        Me.gphThickness.Location = New System.Drawing.Point(0, 0)
        Me.gphThickness.Name = "gphThickness"
        Me.gphThickness.PlotAreaColor = System.Drawing.Color.White
        Me.gphThickness.Plots.AddRange(New NationalInstruments.UI.ScatterPlot() {Me.ScatterPlotQuality, Me.ScatterPlot3, Me.ScatterPlot2})
        Me.gphThickness.Size = New System.Drawing.Size(1031, 489)
        Me.gphThickness.TabIndex = 81
        Me.gphThickness.XAxes.AddRange(New NationalInstruments.UI.XAxis() {Me.XAxis2})
        Me.gphThickness.YAxes.AddRange(New NationalInstruments.UI.YAxis() {Me.YAxis2, Me.YAxisQuality})
        '
        'XyPointAnnotation1
        '
        Me.XyPointAnnotation1.Caption = "XyPointAnnotation1"
        Me.XyPointAnnotation1.CaptionAlignment = New NationalInstruments.UI.AnnotationCaptionAlignment(NationalInstruments.UI.BoundsAlignment.None, 0!, 0!)
        Me.XyPointAnnotation1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XyPointAnnotation1.CaptionForeColor = System.Drawing.Color.Black
        Me.XyPointAnnotation1.ShapeVisible = False
        Me.XyPointAnnotation1.XAxis = Me.XAxis2
        Me.XyPointAnnotation1.XPosition = 0R
        Me.XyPointAnnotation1.YAxis = Me.YAxis2
        Me.XyPointAnnotation1.YPosition = 9.5R
        '
        'XAxis2
        '
        Me.XAxis2.Caption = "Position"
        Me.XAxis2.MajorDivisions.GridColor = System.Drawing.Color.Gray
        Me.XAxis2.MajorDivisions.GridVisible = True
        Me.XAxis2.MajorDivisions.LabelFormat = New NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1")
        '
        'YAxis2
        '
        Me.YAxis2.Caption = "Thickness(mm)"
        Me.YAxis2.EditRangeNumericFormatMode = NationalInstruments.UI.NumericFormatMode.CreateGenericMode("F0")
        Me.YAxis2.MajorDivisions.GridColor = System.Drawing.Color.Gray
        Me.YAxis2.MajorDivisions.GridVisible = True
        Me.YAxis2.MajorDivisions.LabelFormat = New NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F3")
        Me.YAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed
        '
        'XyPointAnnotation2
        '
        Me.XyPointAnnotation2.Caption = "XyPointAnnotation2"
        Me.XyPointAnnotation2.CaptionAlignment = New NationalInstruments.UI.AnnotationCaptionAlignment(NationalInstruments.UI.BoundsAlignment.None, 0!, 0!)
        Me.XyPointAnnotation2.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XyPointAnnotation2.CaptionForeColor = System.Drawing.Color.Black
        Me.XyPointAnnotation2.ShapeVisible = False
        Me.XyPointAnnotation2.XAxis = Me.XAxis2
        Me.XyPointAnnotation2.XPosition = 0R
        Me.XyPointAnnotation2.YAxis = Me.YAxis2
        Me.XyPointAnnotation2.YPosition = 10.0R
        '
        'ScatterPlotQuality
        '
        Me.ScatterPlotQuality.FillMode = NationalInstruments.UI.PlotFillMode.Fill
        Me.ScatterPlotQuality.FillToBaseColor = System.Drawing.Color.DarkGray
        Me.ScatterPlotQuality.LineColor = System.Drawing.Color.DarkGray
        Me.ScatterPlotQuality.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor
        Me.ScatterPlotQuality.LineStep = NationalInstruments.UI.LineStep.YXStep
        Me.ScatterPlotQuality.XAxis = Me.XAxis2
        Me.ScatterPlotQuality.YAxis = Me.YAxisQuality
        '
        'YAxisQuality
        '
        Me.YAxisQuality.Mode = NationalInstruments.UI.AxisMode.Fixed
        Me.YAxisQuality.Range = New NationalInstruments.UI.Range(0R, 1.0R)
        Me.YAxisQuality.Visible = False
        '
        'ScatterPlot3
        '
        Me.ScatterPlot3.XAxis = Me.XAxis2
        Me.ScatterPlot3.YAxis = Me.YAxis2
        '
        'ScatterPlot2
        '
        Me.ScatterPlot2.LineColor = System.Drawing.Color.Red
        Me.ScatterPlot2.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor
        Me.ScatterPlot2.XAxis = Me.XAxis2
        Me.ScatterPlot2.YAxis = Me.YAxis2
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(23, 534)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(89, 14)
        Me.Label22.TabIndex = 250
        Me.Label22.Text = "Compression"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(854, 534)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(44, 14)
        Me.Label21.TabIndex = 249
        Me.Label21.Text = "Inlet"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.White
        Me.lbl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.Red
        Me.lbl1.Location = New System.Drawing.Point(9, 76)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl1.Size = New System.Drawing.Size(98, 22)
        Me.lbl1.TabIndex = 72
        '
        'lbl2
        '
        Me.lbl2.BackColor = System.Drawing.Color.White
        Me.lbl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.Lime
        Me.lbl2.Location = New System.Drawing.Point(115, 76)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl2.Size = New System.Drawing.Size(98, 22)
        Me.lbl2.TabIndex = 256
        '
        'SSTab1
        '
        Me.SSTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SSTab1.Controls.Add(Me.tpThickness)
        Me.SSTab1.Controls.Add(Me.tpDistance)
        Me.SSTab1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSTab1.ItemSize = New System.Drawing.Size(42, 22)
        Me.SSTab1.Location = New System.Drawing.Point(0, 230)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 1
        Me.SSTab1.Size = New System.Drawing.Size(1039, 519)
        Me.SSTab1.TabIndex = 43
        '
        'txtLTGGoodPointsLocated
        '
        Me.txtLTGGoodPointsLocated.AcceptsReturn = True
        Me.txtLTGGoodPointsLocated.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLTGGoodPointsLocated.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLTGGoodPointsLocated.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLTGGoodPointsLocated.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLTGGoodPointsLocated.Location = New System.Drawing.Point(708, 11)
        Me.txtLTGGoodPointsLocated.MaxLength = 0
        Me.txtLTGGoodPointsLocated.Name = "txtLTGGoodPointsLocated"
        Me.txtLTGGoodPointsLocated.ReadOnly = True
        Me.txtLTGGoodPointsLocated.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLTGGoodPointsLocated.Size = New System.Drawing.Size(67, 20)
        Me.txtLTGGoodPointsLocated.TabIndex = 79
        Me.txtLTGGoodPointsLocated.Text = "0"
        Me.txtLTGGoodPointsLocated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMeasuredWidth
        '
        Me.lblMeasuredWidth.BackColor = System.Drawing.SystemColors.Control
        Me.lblMeasuredWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMeasuredWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeasuredWidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMeasuredWidth.Location = New System.Drawing.Point(223, 53)
        Me.lblMeasuredWidth.Name = "lblMeasuredWidth"
        Me.lblMeasuredWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMeasuredWidth.Size = New System.Drawing.Size(141, 23)
        Me.lblMeasuredWidth.TabIndex = 253
        Me.lblMeasuredWidth.Text = "Measured Width (mm):"
        '
        'txtLastMeasurementTime
        '
        Me.txtLastMeasurementTime.AcceptsReturn = True
        Me.txtLastMeasurementTime.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLastMeasurementTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLastMeasurementTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastMeasurementTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLastMeasurementTime.Location = New System.Drawing.Point(367, 32)
        Me.txtLastMeasurementTime.MaxLength = 0
        Me.txtLastMeasurementTime.Name = "txtLastMeasurementTime"
        Me.txtLastMeasurementTime.ReadOnly = True
        Me.txtLastMeasurementTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLastMeasurementTime.Size = New System.Drawing.Size(160, 20)
        Me.txtLastMeasurementTime.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(223, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(141, 23)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Last Measurement:"
        '
        'txtLTGBadConsecutive
        '
        Me.txtLTGBadConsecutive.AcceptsReturn = True
        Me.txtLTGBadConsecutive.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLTGBadConsecutive.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLTGBadConsecutive.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLTGBadConsecutive.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLTGBadConsecutive.Location = New System.Drawing.Point(708, 53)
        Me.txtLTGBadConsecutive.MaxLength = 0
        Me.txtLTGBadConsecutive.Name = "txtLTGBadConsecutive"
        Me.txtLTGBadConsecutive.ReadOnly = True
        Me.txtLTGBadConsecutive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLTGBadConsecutive.Size = New System.Drawing.Size(67, 20)
        Me.txtLTGBadConsecutive.TabIndex = 75
        Me.txtLTGBadConsecutive.Text = "0"
        Me.txtLTGBadConsecutive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOverallBadPts
        '
        Me.lblOverallBadPts.BackColor = System.Drawing.SystemColors.Control
        Me.lblOverallBadPts.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOverallBadPts.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverallBadPts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOverallBadPts.Location = New System.Drawing.Point(564, 32)
        Me.lblOverallBadPts.Name = "lblOverallBadPts"
        Me.lblOverallBadPts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOverallBadPts.Size = New System.Drawing.Size(141, 22)
        Me.lblOverallBadPts.TabIndex = 74
        Me.lblOverallBadPts.Text = "Overall Bad Points:"
        '
        'txtLTGBadOverall
        '
        Me.txtLTGBadOverall.AcceptsReturn = True
        Me.txtLTGBadOverall.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLTGBadOverall.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLTGBadOverall.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLTGBadOverall.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLTGBadOverall.Location = New System.Drawing.Point(708, 32)
        Me.txtLTGBadOverall.MaxLength = 0
        Me.txtLTGBadOverall.Name = "txtLTGBadOverall"
        Me.txtLTGBadOverall.ReadOnly = True
        Me.txtLTGBadOverall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLTGBadOverall.Size = New System.Drawing.Size(67, 20)
        Me.txtLTGBadOverall.TabIndex = 73
        Me.txtLTGBadOverall.Text = "0"
        Me.txtLTGBadOverall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConsecutiveBadPts
        '
        Me.lblConsecutiveBadPts.BackColor = System.Drawing.SystemColors.Control
        Me.lblConsecutiveBadPts.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblConsecutiveBadPts.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutiveBadPts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConsecutiveBadPts.Location = New System.Drawing.Point(564, 53)
        Me.lblConsecutiveBadPts.Name = "lblConsecutiveBadPts"
        Me.lblConsecutiveBadPts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblConsecutiveBadPts.Size = New System.Drawing.Size(141, 22)
        Me.lblConsecutiveBadPts.TabIndex = 76
        Me.lblConsecutiveBadPts.Text = "Consecutive Bad Points:"
        '
        'lblGoodPoints
        '
        Me.lblGoodPoints.BackColor = System.Drawing.SystemColors.Control
        Me.lblGoodPoints.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGoodPoints.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoodPoints.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGoodPoints.Location = New System.Drawing.Point(564, 11)
        Me.lblGoodPoints.Name = "lblGoodPoints"
        Me.lblGoodPoints.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGoodPoints.Size = New System.Drawing.Size(141, 22)
        Me.lblGoodPoints.TabIndex = 80
        Me.lblGoodPoints.Text = "Good Points Located:"
        '
        'txtThickness_MeasuredWidth
        '
        Me.txtThickness_MeasuredWidth.AcceptsReturn = True
        Me.txtThickness_MeasuredWidth.BackColor = System.Drawing.SystemColors.Menu
        Me.txtThickness_MeasuredWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtThickness_MeasuredWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThickness_MeasuredWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtThickness_MeasuredWidth.Location = New System.Drawing.Point(367, 53)
        Me.txtThickness_MeasuredWidth.MaxLength = 0
        Me.txtThickness_MeasuredWidth.Name = "txtThickness_MeasuredWidth"
        Me.txtThickness_MeasuredWidth.ReadOnly = True
        Me.txtThickness_MeasuredWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtThickness_MeasuredWidth.Size = New System.Drawing.Size(67, 20)
        Me.txtThickness_MeasuredWidth.TabIndex = 252
        Me.txtThickness_MeasuredWidth.TabStop = False
        Me.txtThickness_MeasuredWidth.Text = "0.0"
        Me.txtThickness_MeasuredWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblResults
        '
        Me.lblResults.BackColor = System.Drawing.SystemColors.Control
        Me.lblResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResults.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblResults.Font = New System.Drawing.Font("Arial", 24.0!)
        Me.lblResults.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblResults.Location = New System.Drawing.Point(6, 16)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblResults.Size = New System.Drawing.Size(207, 63)
        Me.lblResults.TabIndex = 255
        Me.lblResults.Text = "Results"
        Me.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.txtPrecitecRefIdx)
        Me.grpResults.Controls.Add(Me.Label13)
        Me.grpResults.Controls.Add(Me.txtQAThicknessRng)
        Me.grpResults.Controls.Add(Me.Label11)
        Me.grpResults.Controls.Add(Me.txtQAThicknessMax)
        Me.grpResults.Controls.Add(Me.Label8)
        Me.grpResults.Controls.Add(Me.txtQAThicknessMin)
        Me.grpResults.Controls.Add(Me.Label9)
        Me.grpResults.Controls.Add(Me.Label10)
        Me.grpResults.Controls.Add(Me.txtQAThicknessAvg)
        Me.grpResults.Controls.Add(Me.txtQAEnd)
        Me.grpResults.Controls.Add(Me.Label7)
        Me.grpResults.Controls.Add(Me.txtQAStart)
        Me.grpResults.Controls.Add(Me.Label5)
        Me.grpResults.Controls.Add(Me.txtVBSOffset)
        Me.grpResults.Controls.Add(Me.Label4)
        Me.grpResults.Controls.Add(Me.lblRejectReason)
        Me.grpResults.Controls.Add(Me.lblResults)
        Me.grpResults.Controls.Add(Me.txtSheetUID)
        Me.grpResults.Controls.Add(Me.txtSurfaceVariation)
        Me.grpResults.Controls.Add(Me.txtThickness_MeasuredWidth)
        Me.grpResults.Controls.Add(Me.lblGoodPoints)
        Me.grpResults.Controls.Add(Me.lblConsecutiveBadPts)
        Me.grpResults.Controls.Add(Me.txtLTGBadOverall)
        Me.grpResults.Controls.Add(Me.lblOverallBadPts)
        Me.grpResults.Controls.Add(Me.txtLTGBadConsecutive)
        Me.grpResults.Controls.Add(Me.Label1)
        Me.grpResults.Controls.Add(Me.txtLastMeasurementTime)
        Me.grpResults.Controls.Add(Me.Label3)
        Me.grpResults.Controls.Add(Me.Label2)
        Me.grpResults.Controls.Add(Me.lblMeasuredWidth)
        Me.grpResults.Controls.Add(Me.txtLTGGoodPointsLocated)
        Me.grpResults.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpResults.Location = New System.Drawing.Point(8, 103)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(1023, 121)
        Me.grpResults.TabIndex = 267
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Results"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(806, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(141, 23)
        Me.Label13.TabIndex = 265
        Me.Label13.Text = "Sensor Refractive Index:"
        '
        'txtQAThicknessRng
        '
        Me.txtQAThicknessRng.AcceptsReturn = True
        Me.txtQAThicknessRng.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAThicknessRng.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAThicknessRng.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAThicknessRng.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAThicknessRng.Location = New System.Drawing.Point(950, 74)
        Me.txtQAThicknessRng.MaxLength = 0
        Me.txtQAThicknessRng.Name = "txtQAThicknessRng"
        Me.txtQAThicknessRng.ReadOnly = True
        Me.txtQAThicknessRng.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAThicknessRng.Size = New System.Drawing.Size(67, 20)
        Me.txtQAThicknessRng.TabIndex = 260
        Me.txtQAThicknessRng.TabStop = False
        Me.txtQAThicknessRng.Text = "0.0"
        Me.txtQAThicknessRng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(806, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(141, 23)
        Me.Label11.TabIndex = 262
        Me.Label11.Text = "QA Thickness Rng (mm):"
        '
        'txtQAThicknessMax
        '
        Me.txtQAThicknessMax.AcceptsReturn = True
        Me.txtQAThicknessMax.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAThicknessMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAThicknessMax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAThicknessMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAThicknessMax.Location = New System.Drawing.Point(950, 53)
        Me.txtQAThicknessMax.MaxLength = 0
        Me.txtQAThicknessMax.Name = "txtQAThicknessMax"
        Me.txtQAThicknessMax.ReadOnly = True
        Me.txtQAThicknessMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAThicknessMax.Size = New System.Drawing.Size(67, 20)
        Me.txtQAThicknessMax.TabIndex = 260
        Me.txtQAThicknessMax.TabStop = False
        Me.txtQAThicknessMax.Text = "0.0"
        Me.txtQAThicknessMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(806, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(141, 23)
        Me.Label8.TabIndex = 262
        Me.Label8.Text = "QA Thickness Max (mm):"
        '
        'txtQAThicknessMin
        '
        Me.txtQAThicknessMin.AcceptsReturn = True
        Me.txtQAThicknessMin.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAThicknessMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAThicknessMin.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAThicknessMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAThicknessMin.Location = New System.Drawing.Point(950, 32)
        Me.txtQAThicknessMin.MaxLength = 0
        Me.txtQAThicknessMin.Name = "txtQAThicknessMin"
        Me.txtQAThicknessMin.ReadOnly = True
        Me.txtQAThicknessMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAThicknessMin.Size = New System.Drawing.Size(67, 20)
        Me.txtQAThicknessMin.TabIndex = 261
        Me.txtQAThicknessMin.TabStop = False
        Me.txtQAThicknessMin.Text = "0.0"
        Me.txtQAThicknessMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(806, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(141, 23)
        Me.Label9.TabIndex = 263
        Me.Label9.Text = "QA Thickness Min (mm):"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(806, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(141, 22)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "QA Thickness Avg (mm):"
        '
        'txtQAThicknessAvg
        '
        Me.txtQAThicknessAvg.AcceptsReturn = True
        Me.txtQAThicknessAvg.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAThicknessAvg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAThicknessAvg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAThicknessAvg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAThicknessAvg.Location = New System.Drawing.Point(950, 11)
        Me.txtQAThicknessAvg.MaxLength = 0
        Me.txtQAThicknessAvg.Name = "txtQAThicknessAvg"
        Me.txtQAThicknessAvg.ReadOnly = True
        Me.txtQAThicknessAvg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAThicknessAvg.Size = New System.Drawing.Size(67, 20)
        Me.txtQAThicknessAvg.TabIndex = 258
        Me.txtQAThicknessAvg.Text = "0"
        Me.txtQAThicknessAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtQAEnd
        '
        Me.txtQAEnd.AcceptsReturn = True
        Me.txtQAEnd.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAEnd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAEnd.Location = New System.Drawing.Point(708, 95)
        Me.txtQAEnd.MaxLength = 0
        Me.txtQAEnd.Name = "txtQAEnd"
        Me.txtQAEnd.ReadOnly = True
        Me.txtQAEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAEnd.Size = New System.Drawing.Size(67, 20)
        Me.txtQAEnd.TabIndex = 256
        Me.txtQAEnd.TabStop = False
        Me.txtQAEnd.Text = "0.0"
        Me.txtQAEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(564, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(141, 23)
        Me.Label7.TabIndex = 257
        Me.Label7.Text = "QA End (mm):"
        '
        'txtQAStart
        '
        Me.txtQAStart.AcceptsReturn = True
        Me.txtQAStart.BackColor = System.Drawing.SystemColors.Menu
        Me.txtQAStart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQAStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQAStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQAStart.Location = New System.Drawing.Point(708, 74)
        Me.txtQAStart.MaxLength = 0
        Me.txtQAStart.Name = "txtQAStart"
        Me.txtQAStart.ReadOnly = True
        Me.txtQAStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQAStart.Size = New System.Drawing.Size(67, 20)
        Me.txtQAStart.TabIndex = 256
        Me.txtQAStart.TabStop = False
        Me.txtQAStart.Text = "0.0"
        Me.txtQAStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(564, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(141, 23)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "QA Start (mm):"
        '
        'txtVBSOffset
        '
        Me.txtVBSOffset.AcceptsReturn = True
        Me.txtVBSOffset.BackColor = System.Drawing.SystemColors.Menu
        Me.txtVBSOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVBSOffset.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVBSOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVBSOffset.Location = New System.Drawing.Point(367, 95)
        Me.txtVBSOffset.MaxLength = 0
        Me.txtVBSOffset.Name = "txtVBSOffset"
        Me.txtVBSOffset.ReadOnly = True
        Me.txtVBSOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVBSOffset.Size = New System.Drawing.Size(67, 20)
        Me.txtVBSOffset.TabIndex = 256
        Me.txtVBSOffset.TabStop = False
        Me.txtVBSOffset.Text = "0.0"
        Me.txtVBSOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(223, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(141, 23)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Measured VBSOffset (mm):"
        '
        'lblRejectReason
        '
        Me.lblRejectReason.BackColor = System.Drawing.SystemColors.Control
        Me.lblRejectReason.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRejectReason.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblRejectReason.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRejectReason.Location = New System.Drawing.Point(6, 79)
        Me.lblRejectReason.Name = "lblRejectReason"
        Me.lblRejectReason.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRejectReason.Size = New System.Drawing.Size(207, 26)
        Me.lblRejectReason.TabIndex = 255
        Me.lblRejectReason.Text = "Reject Reason"
        Me.lblRejectReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSheetUID
        '
        Me.txtSheetUID.AcceptsReturn = True
        Me.txtSheetUID.BackColor = System.Drawing.SystemColors.Menu
        Me.txtSheetUID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSheetUID.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSheetUID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSheetUID.Location = New System.Drawing.Point(367, 11)
        Me.txtSheetUID.MaxLength = 0
        Me.txtSheetUID.Name = "txtSheetUID"
        Me.txtSheetUID.ReadOnly = True
        Me.txtSheetUID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSheetUID.Size = New System.Drawing.Size(67, 20)
        Me.txtSheetUID.TabIndex = 252
        Me.txtSheetUID.TabStop = False
        Me.txtSheetUID.Text = "0"
        Me.txtSheetUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSurfaceVariation
        '
        Me.txtSurfaceVariation.AcceptsReturn = True
        Me.txtSurfaceVariation.BackColor = System.Drawing.SystemColors.Menu
        Me.txtSurfaceVariation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSurfaceVariation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurfaceVariation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSurfaceVariation.Location = New System.Drawing.Point(367, 74)
        Me.txtSurfaceVariation.MaxLength = 0
        Me.txtSurfaceVariation.Name = "txtSurfaceVariation"
        Me.txtSurfaceVariation.ReadOnly = True
        Me.txtSurfaceVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSurfaceVariation.Size = New System.Drawing.Size(67, 20)
        Me.txtSurfaceVariation.TabIndex = 252
        Me.txtSurfaceVariation.TabStop = False
        Me.txtSurfaceVariation.Text = "0.0"
        Me.txtSurfaceVariation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(223, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(141, 23)
        Me.Label3.TabIndex = 253
        Me.Label3.Text = "Surface Variation (mm):"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(223, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(141, 23)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Sheet UID:"
        '
        'btnViewLog
        '
        Me.btnViewLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewLog.BackColor = System.Drawing.SystemColors.Control
        Me.btnViewLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnViewLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewLog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewLog.Location = New System.Drawing.Point(1039, 128)
        Me.btnViewLog.Name = "btnViewLog"
        Me.btnViewLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewLog.Size = New System.Drawing.Size(108, 52)
        Me.btnViewLog.TabIndex = 2
        Me.btnViewLog.Text = "Log"
        Me.btnViewLog.UseVisualStyleBackColor = False
        '
        'btnViewConfig
        '
        Me.btnViewConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewConfig.BackColor = System.Drawing.SystemColors.Control
        Me.btnViewConfig.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnViewConfig.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewConfig.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewConfig.Location = New System.Drawing.Point(1039, 186)
        Me.btnViewConfig.Name = "btnViewConfig"
        Me.btnViewConfig.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewConfig.Size = New System.Drawing.Size(108, 52)
        Me.btnViewConfig.TabIndex = 2
        Me.btnViewConfig.Text = "Config"
        Me.btnViewConfig.UseVisualStyleBackColor = False
        '
        'btnReReadConfig
        '
        Me.btnReReadConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReReadConfig.BackColor = System.Drawing.SystemColors.Control
        Me.btnReReadConfig.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnReReadConfig.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReReadConfig.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReReadConfig.Location = New System.Drawing.Point(1039, 244)
        Me.btnReReadConfig.Name = "btnReReadConfig"
        Me.btnReReadConfig.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReReadConfig.Size = New System.Drawing.Size(108, 52)
        Me.btnReReadConfig.TabIndex = 2
        Me.btnReReadConfig.Text = "Re-Read" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Config"
        Me.btnReReadConfig.UseVisualStyleBackColor = False
        '
        'frmOperations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1153, 749)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.GroupBoxGauge)
        Me.Controls.Add(Me.grpSheetInfo)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnSheetInformation)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnReReadConfig)
        Me.Controls.Add(Me.btnViewConfig)
        Me.Controls.Add(Me.btnViewLog)
        Me.Controls.Add(Me.btnMaintenance)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(-6, 32)
        Me.MinimizeBox = False
        Me.Name = "frmOperations"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CEOLTG"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpSheetInfo.ResumeLayout(False)
        Me.grpSheetInfo.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBoxGauge.ResumeLayout(False)
        Me.GroupBoxGauge.PerformLayout()
        Me.tpDistance.ResumeLayout(False)
        CType(Me.gphDisplacement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpThickness.ResumeLayout(False)
        CType(Me.gphThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SSTab1.ResumeLayout(False)
        Me.grpResults.ResumeLayout(False)
        Me.grpResults.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuGaugeComJudge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfigOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfigReRead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfigSave As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents txtQASheetWidth As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents btnStop As System.Windows.Forms.Button
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents txtBODID As System.Windows.Forms.TextBox
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents txtGaugeID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxGauge As System.Windows.Forms.GroupBox
    Friend WithEvents tpDistance As System.Windows.Forms.TabPage
    Private WithEvents gphDisplacement As NationalInstruments.UI.WindowsForms.ScatterGraph
    Private WithEvents ScatterPlot5 As NationalInstruments.UI.ScatterPlot
    Private WithEvents XAxis1 As NationalInstruments.UI.XAxis
    Private WithEvents YAxis1 As NationalInstruments.UI.YAxis
    Private WithEvents ScatterPlot6 As NationalInstruments.UI.ScatterPlot
    Public WithEvents tpThickness As System.Windows.Forms.TabPage
    Private WithEvents gphThickness As NationalInstruments.UI.WindowsForms.ScatterGraph
    Private WithEvents ScatterPlot3 As NationalInstruments.UI.ScatterPlot
    Private WithEvents XAxis2 As NationalInstruments.UI.XAxis
    Private WithEvents YAxis2 As NationalInstruments.UI.YAxis
    Private WithEvents ScatterPlot2 As NationalInstruments.UI.ScatterPlot
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents lbl1 As System.Windows.Forms.Label
    Public WithEvents lbl2 As System.Windows.Forms.Label
    Public WithEvents SSTab1 As System.Windows.Forms.TabControl
    Public WithEvents txtLTGGoodPointsLocated As System.Windows.Forms.TextBox
    Public WithEvents lblMeasuredWidth As System.Windows.Forms.Label
    Public WithEvents txtLastMeasurementTime As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtLTGBadConsecutive As System.Windows.Forms.TextBox
    Public WithEvents lblOverallBadPts As System.Windows.Forms.Label
    Public WithEvents txtLTGBadOverall As System.Windows.Forms.TextBox
    Public WithEvents lblConsecutiveBadPts As System.Windows.Forms.Label
    Public WithEvents lblGoodPoints As System.Windows.Forms.Label
    Public WithEvents txtThickness_MeasuredWidth As System.Windows.Forms.TextBox
    Public WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Public WithEvents txtSheetUID As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtSurfaceVariation As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lblEngineerOutputEnabled As Label
    Public WithEvents txtVBSOffset As TextBox
    Public WithEvents Label4 As Label
    Public WithEvents txtQAEnd As TextBox
    Public WithEvents Label7 As Label
    Public WithEvents txtQAStart As TextBox
    Public WithEvents Label5 As Label
    Public WithEvents txtQAThicknessMax As TextBox
    Public WithEvents Label8 As Label
    Public WithEvents txtQAThicknessMin As TextBox
    Public WithEvents Label9 As Label
    Public WithEvents Label10 As Label
    Public WithEvents txtQAThicknessAvg As TextBox
    Friend WithEvents ScatterPlotQuality As ScatterPlot
    Friend WithEvents YAxisQuality As YAxis
    Friend WithEvents XyPointAnnotation1 As XYPointAnnotation
    Friend WithEvents XyPointAnnotation2 As XYPointAnnotation
    Public WithEvents lblRejectReason As Label
    Public WithEvents txtQAThicknessRng As TextBox
    Public WithEvents Label11 As Label
    Public WithEvents lblDropIfReject_Disabled As Label
    Public WithEvents txtPrecitecRefIdx As TextBox
    Public WithEvents Label13 As Label
    Public WithEvents btnViewLog As Button
    Public WithEvents btnViewConfig As Button
    Public WithEvents btnReReadConfig As Button
#End Region
End Class