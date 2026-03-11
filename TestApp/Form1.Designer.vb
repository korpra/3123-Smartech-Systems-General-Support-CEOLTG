<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ScatterGraph1 = New NationalInstruments.UI.WindowsForms.ScatterGraph()
        Me.XAxis1 = New NationalInstruments.UI.XAxis()
        Me.YAxis1 = New NationalInstruments.UI.YAxis()
        Me.ScatterPlot1 = New NationalInstruments.UI.ScatterPlot()
        Me.ScatterPlot2 = New NationalInstruments.UI.ScatterPlot()
        Me.YAxis2 = New NationalInstruments.UI.YAxis()
        CType(Me.ScatterGraph1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScatterGraph1
        '
        Me.ScatterGraph1.Location = New System.Drawing.Point(133, 51)
        Me.ScatterGraph1.Name = "ScatterGraph1"
        Me.ScatterGraph1.Plots.AddRange(New NationalInstruments.UI.ScatterPlot() {Me.ScatterPlot2, Me.ScatterPlot1})
        Me.ScatterGraph1.Size = New System.Drawing.Size(743, 462)
        Me.ScatterGraph1.TabIndex = 0
        Me.ScatterGraph1.UseColorGenerator = True
        Me.ScatterGraph1.XAxes.AddRange(New NationalInstruments.UI.XAxis() {Me.XAxis1})
        Me.ScatterGraph1.YAxes.AddRange(New NationalInstruments.UI.YAxis() {Me.YAxis1, Me.YAxis2})
        '
        'ScatterPlot1
        '
        Me.ScatterPlot1.LineColor = System.Drawing.Color.Fuchsia
        Me.ScatterPlot1.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor
        Me.ScatterPlot1.XAxis = Me.XAxis1
        Me.ScatterPlot1.YAxis = Me.YAxis1
        '
        'ScatterPlot2
        '
        Me.ScatterPlot2.FillMode = NationalInstruments.UI.PlotFillMode.Fill
        Me.ScatterPlot2.FillToBaseColor = System.Drawing.Color.DarkGray
        Me.ScatterPlot2.LineColor = System.Drawing.Color.DarkGray
        Me.ScatterPlot2.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor
        Me.ScatterPlot2.LineStep = NationalInstruments.UI.LineStep.YXStep
        Me.ScatterPlot2.XAxis = Me.XAxis1
        Me.ScatterPlot2.YAxis = Me.YAxis2
        '
        'YAxis2
        '
        Me.YAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed
        Me.YAxis2.Range = New NationalInstruments.UI.Range(0R, 1.0R)
        Me.YAxis2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 585)
        Me.Controls.Add(Me.ScatterGraph1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.ScatterGraph1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ScatterGraph1 As NationalInstruments.UI.WindowsForms.ScatterGraph
    Friend WithEvents ScatterPlot1 As NationalInstruments.UI.ScatterPlot
    Friend WithEvents XAxis1 As NationalInstruments.UI.XAxis
    Friend WithEvents YAxis1 As NationalInstruments.UI.YAxis
    Friend WithEvents ScatterPlot2 As NationalInstruments.UI.ScatterPlot
    Friend WithEvents YAxis2 As NationalInstruments.UI.YAxis
End Class
