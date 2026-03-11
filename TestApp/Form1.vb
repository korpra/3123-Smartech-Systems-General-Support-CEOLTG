
Public Class Form1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        test()

    End Sub

    Private Sub test()
        'Plot Quality Area
        Dim lstPosition As New List(Of Double)
        Dim lstValue As New List(Of Double)
        Dim iRemainder As Integer

        For i As Integer = 1 To 100
            lstPosition.Add(i)
            Math.DivRem(i, 10, iRemainder)
            lstValue.Add(iRemainder)

        Next
        Me.ScatterGraph1.Plots(1).PlotXY(lstPosition.ToArray(), lstValue.ToArray)



        lstPosition = New List(Of Double)
        lstValue = New List(Of Double)
        lstPosition.Add(0)
        lstPosition.Add(10)
        lstPosition.Add(90)
        lstPosition.Add(100)
        lstValue.Add(1)
        lstValue.Add(1)
        lstValue.Add(0)
        lstValue.Add(1)
        Me.ScatterGraph1.Plots(0).PlotXY(lstPosition.ToArray(), lstValue.ToArray)

    End Sub

End Class
