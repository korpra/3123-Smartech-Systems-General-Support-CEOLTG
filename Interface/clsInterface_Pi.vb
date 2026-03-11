Friend Class clsInterface_Pi
    '***************************************************************
    '
    'Class:    clsInterface_Pi
    '
    'Description:   This class is used for interface with Pi.
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
    '2017-01-12 fjm         Created
    '***************************************************************

#Region "Constants"
    Public Const cDisplacementPiTagUpperBound As Integer = 250
#End Region

#Region "Publics"
    Public PiImportFileEnable As Boolean = False
    Public PiImportFilePath As String = "c:\CEOLTG\Pi\"
    Public PiImportFilePeriod As Integer = 1
#End Region

#Region "Privates"
    Private sPiTags(cDisplacementPiTagUpperBound) As String    'list of pi tags representing position on glass index 0 = 0mm, 1 = 1mm, ... 250 = 250mm
    Private _iSheetsSinceLastSaveCnt As Integer = 0
#End Region

#Region "Properties"
    ''' <summary>
    ''' Display Pi Tags for positions on the glass
    ''' </summary>
    ''' <param name="iPosition">Integer Value from 0mm to 250mm</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplacementPiTag(iPosition As Integer) As String
        Get
            Dim sReturn As String = ""

            If iPosition >= Me.sPiTags.GetLowerBound(0) And iPosition <= Me.sPiTags.GetUpperBound(0) Then
                sReturn = Me.sPiTags(iPosition)
            End If

            Return sReturn
        End Get
        Set(value As String)
            If iPosition >= Me.sPiTags.GetLowerBound(0) And iPosition <= Me.sPiTags.GetUpperBound(0) Then
                Me.sPiTags(iPosition) = value
            End If
        End Set
    End Property
#End Region

#Region "Functions"
    Public Sub WritePiImport(oSheet As clsData_Sheet)
        Dim hndFile As Integer = -1
        Try
            'Increment Count
            Me._iSheetsSinceLastSaveCnt += 1

            If Me._iSheetsSinceLastSaveCnt < Me.PiImportFilePeriod Then
                gLog.LogMsg(String.Format("Pi Import File not saved, PiImportFilePeriod={0}, CurrentCount={1}", Me.PiImportFilePeriod, Me._iSheetsSinceLastSaveCnt))
            Else
                Me._iSheetsSinceLastSaveCnt = 0

                Dim dt As Date = oSheet.Info.MeasureDT
                Dim myCIenUS As New System.Globalization.CultureInfo("en-US", False)
                Dim oData As clsData_LTG_Readings = oSheet.LTG.Sheet

                'Open File
                hndFile = FreeFile()
                FileOpen(hndFile, Me.PiImportFilePath & "CEOLTG_PiImport_" & dt.ToString("yyyy-MM-dd_HH-mm-ss") & ".txt", OpenMode.Output)

                'Step through Pi Tags
                Dim dDisplacement As Double = 0
                Dim iDataIndex As Integer = 0
                Dim iUpper As Integer = oData.Position.GetUpperBound(0)
                For iTargetPos As Integer = 0 To cDisplacementPiTagUpperBound
                    Dim strTagname As String
                    Dim strDateTime As String
                    Dim strValue As String

                    'Define Tagname
                    strTagname = Me.DisplacementPiTag(iTargetPos) & ","

                    'Define Date/Time
                    strDateTime = dt.ToString("dd-MMM-yyyy HH:mm:ss", myCIenUS) & ","

                    'Get Displacement
                    If iTargetPos <= oData.Position(0) Then
                        dDisplacement = Me.Interpolate(oData.Position(0), oData.Position(1), oData.Distance(0), oData.Distance(1), iTargetPos)
                    ElseIf iTargetPos >= oData.Position(0) And iTargetPos <= oData.Position(iUpper) Then
                        While iTargetPos > oData.Position(iDataIndex) And iDataIndex < iUpper - 1
                            iDataIndex += 1
                        End While

                        dDisplacement = Me.Interpolate(oData.Position(iDataIndex), oData.Position(iDataIndex + 1), oData.Distance(iDataIndex), oData.Distance(iDataIndex + 1), iTargetPos)
                    Else
                        dDisplacement = Me.Interpolate(oData.Position(iUpper - 1), oData.Position(iUpper), oData.Distance(iUpper - 1), oData.Distance(iUpper), iTargetPos)
                    End If
                    strValue = dDisplacement.ToString()

                    'Format Line
                    Dim sLine As String = strTagname.PadRight(34, " ") _
                        & strDateTime.PadRight(18, " ") _
                        & strValue.PadLeft(19, " ")

                    'Print Line
                    PrintLine(hndFile, sLine)
                Next
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "WritePiImport", ex)

        Finally
            If hndFile <> -1 Then
                FileClose(hndFile)
            End If
        End Try

    End Sub

    
    Private Function Interpolate(X1 As Double, X2 As Double, Y1 As Double, Y2 As Double, InputX As Double) As Double
        Try
            Dim dReturn As Double = 0
            Dim dSlope As Double = 0
            Dim dOffset As Double = 0

            If X1 <> X2 Then
                dSlope = (Y2 - Y1) / (X2 - X1)
                dReturn = dSlope * (InputX - X1) + Y1
            End If

            Return dReturn
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "Interpolate", ex, X1, X2, Y1, Y2)
            Return 0
        End Try
    End Function

#End Region

End Class
