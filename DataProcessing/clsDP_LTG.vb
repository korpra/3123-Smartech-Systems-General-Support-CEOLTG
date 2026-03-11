Option Strict Off
Option Explicit On

Imports System.Collections.Generic

Friend Class clsDP_LTG

    '***************************************************************
    '
    'Class:    clsDP_LTG
    '
    'Description:   This class is part of the Data Processing.  It is the
    '               class responsible for processing the LTG data.
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
    '01/05/06   fjm         Created
    '11/28/06   fjm         Added filtering of raw data.
    '                       Corrected Linear Interpolation calculation
    '2010-02-25 fjm         Not using ReadDistance for online gauges
    '2010-09-14 fjm         Added variable FilteringType and function FilterReadings
    '2012-1-13  rkp         Modified for SOLTG
    '2016-10-12 fjm         Updated for CEOLTG
    '***************************************************************

    '************************** Constants **************************
    Const cAIR_REF_IDX As Double = 1 'Refractive index of air

    '************************** Publics ****************************
    Public MaxBadOverallCnt As Short = 100
    Public MaxBadConsecutiveCnt As Short = 3
    Public ReadDistance As Double = 1.0#

    Public LTGTrim As Double = 2
    Public BadPointPercentDev As Double = 3
    Public StdDevFilterFactor As Double = 2
    Public CalibrationStandard As String = "unknown"
    Public CalibrationGlassCode As String = ""
    Public CalibrationGlassType As String = ""
    Public CalibrationGlassRefIdx As Double = 1

    '************************** Privates ***************************
    Dim _iLeftEdgeIndex As Integer
    Dim _iRightEdgeIndex As Integer


    Public Sub New()
        MyBase.New()
    End Sub

    Public Function ProcessSheet(ByRef oData As clsData_Sheet) As enumError
        Dim errReturn As enumError

        On Error Resume Next

        'Process Raw Data
        If GetRawData(oData) <> enumError.errSuccess Then
            errReturn = enumError.errFailure
        End If

        'Determine if need to flip data, fjm, 2018-01-12
        If gConfig.InletLeadingEdge Then
            gLog.LogDebug(9, String.Format("cldDP_LTG.ProcessSheet(): Flip Data"))

            oData.LTG.Raw = Me.FlipData(oData.LTG.Raw)
        End If

        gLog.LogDebug(9, "clsDP_LTG.FindEdges()")
        'Find Edges using Thickness data
        If FindEdges_Thickness(oData, oData.LTG.Raw) <> enumError.errSuccess Then
            gLog.LogErr("clsDP_LTG.FindEdges(): Thickness Failed")
            errReturn = enumError.errFailure
        End If

        'Save Measured Width
        oData.LTG.SizeWidth_Measured = oData.LTG.RightEdge - oData.LTG.LeftEdge

        'Filter Raw Readings, v1.1.0
        If FilterRawData(oData) <> enumError.errSuccess Then
            errReturn = enumError.errFailure
        End If

        'Process Readings
        If ProcessReadings(oData) <> enumError.errSuccess Then
            errReturn = enumError.errFailure
        End If

        'Bin Data, moved from mdlSpecs, v1.1.12
        If gConfig.LTGSpecBinningEnable Then
            If BinData(oData) <> enumError.errSuccess Then
                errReturn = enumError.errFailure
            End If
        End If


        If gConfig.SGFilterEnabled Then
            If SGFilterData(oData) <> enumError.errSuccess Then
                errReturn = enumError.errFailure
            End If
        End If

            'If no errors then success
            If errReturn <> enumError.errFailure Then
            'Return Success
            errReturn = enumError.errSuccess
        End If

        'Return Status
        ProcessSheet = errReturn
    End Function

    ''' <summary>
    ''' Get Raw Data from Sensor
    ''' </summary>
    ''' <param name="oData"></param>
    ''' <returns></returns>
    Public Function GetRawData(ByRef oData As clsData_Sheet) As enumError
        'clsData_LTG

        Dim errReturn As enumError

        On Error GoTo ErrorHandler

        'Initialize Variables
        errReturn = enumError.errNone

        'Get Collected Data
        gLTG.GetSheetData(oData.LTG.Raw)

        'Zero array and check for encoder rollover
        Dim dPrev As Double = Double.NaN
        Dim dOffset As Double = 0
        If oData.LTG.Raw.Position.Count > 0 Then dOffset = oData.LTG.Raw.Position(0)
        For i As Integer = 0 To oData.LTG.Raw.Position.Count - 1
            Dim dPos As Double = oData.LTG.Raw.Position(i) - dOffset

            'Check for rollover
            If Not Double.IsNaN(dPrev) And Math.Abs(dPos - dPrev) > 100000 Then
                'Recalculate Offset by setting Previous and Current values equal (approximation)
                gLog.LogDebug(1, String.Format("GetData(): Encoder Rollover, Previous={0}, Current={1}", dPrev, dPos))
                dOffset = oData.LTG.Raw.Position(i) - dPrev
                dPos = dPrev
            End If

            'Save new value back to position array
            oData.LTG.Raw.Position(i) = dPos
            dPrev = dPos
        Next

        'If no error then success
        If errReturn <> enumError.errFailure Then
            'Return Success
            errReturn = enumError.errSuccess
        End If

        'Return Status
        Return errReturn
        Exit Function
ErrorHandler:
        gLog.LogErr("clsDP_LTG.GetData(), Error:" & Err.Description)
        Return enumError.errFailure
    End Function

    ''' <summary>
    ''' Filter Raw Data
    ''' </summary>
    ''' <param name="oData"></param>
    ''' <returns></returns>
    Private Function FilterRawData(ByRef oData As clsData_Sheet) As enumError
        Dim errReturn As enumError = enumError.errNone

        Try
            Dim oFiltering As New clsDP_Filtering
            Dim oRaw As clsData_LTG_Readings = oData.LTG.Raw


            'Check if Median Window Filter is enabled
            If gConfig.FilterMedianWindowEnable Then
                gLog.LogDebug(9, "clsDP_LTG.FilterRawData(), MovingMedian")
                oRaw.Thickness = oFiltering.MovingMedian(oRaw, oData.LTG.LeftEdge, oData.LTG.RightEdge, gConfig.FilterMedianWindowWindowSize)
            End If

            'If no error then success
            If errReturn <> enumError.errFailure Then
                'Return Success
                errReturn = enumError.errSuccess
            End If

            'Return Status
            Return errReturn
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return enumError.errFailure
        End Try
    End Function

    Private Function SGFilterData(ByRef oData As clsData_Sheet) As enumError
        Dim errReturn As enumError = enumError.errNone

        Try
            Dim oFiltering As New clsDP_Filtering

            gLog.LogDebug(9, "clsDP_LTG.SGFilterData()")
            'need to assign back to the data source

            oData.LTG.Sheet = oFiltering.SGFilterData(oData.LTG.Sheet, gConfig.SGWindowSize)
            'If no error then success
            If errReturn <> enumError.errFailure Then
                'Return Success
                errReturn = enumError.errSuccess
            End If

            'Return Status
            Return errReturn
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return enumError.errFailure
        End Try
    End Function


    Private Function ProcessReadings(ByRef oData As clsData_Sheet) As enumError
        Dim errReturn As enumError = enumError.errNone

        Try
            Dim oRaw As clsData_LTG_Readings = oData.LTG.Raw
            Dim oLTG As clsData_LTG = oData.LTG

            ' gLog.LogDebug(9, "objsheet point count = " & objSheet.PointCnt)
            Dim intBadConsecPoints As Short = 0

            'Initialize Variables
            oData.LTG.BadOverallCnt = 0
            oData.LTG.BadConsecutiveCnt = 0
            oData.LTG.Passed = True
            oData.LTG.GoodPointsLocated = True

            'Define Sheet Start and End Positions
            'Save everything within the sheet, fjm, 2010-02-24
            'Added Trim, fjm, 2016-12-14
            Dim dStart As Double = oData.LTG.LeftEdge + Me.LTGTrim
            Dim dEnd As Double = oData.LTG.RightEdge - Me.LTGTrim

            'Step through saving data
            Dim iRawIndex As Integer = 0
            Dim dLastGoodThickness As Double = 0
            Dim dPrevPosition As Double = -1
            'For iRawIndex As Integer = oRaw.Thickness.GetLowerBound(0) To oRaw.Thickness.GetUpperBound(0)
            For dTarget As Double = 0 To dEnd - dStart Step Me.ReadDistance
                Dim bGood As Boolean = False

                'Step through position array looking for target
                Do While iRawIndex < oRaw.Position.Count - 1 And Not bGood
                    Dim dPos As Double = oRaw.Position(iRawIndex) - dStart

                    'Save Any Good Points for later use in Interpolation Calculation
                    If dPos >= dStart And dPos <= dEnd And oRaw.Thickness(iRawIndex) > 0 Then
                        If dLastGoodThickness = 0 Then
                            bGood = True
                        ElseIf dPos < dTarget Then
                            'Check for Good Point to save for later
                            If GoodPoint(oRaw.Thickness(iRawIndex), dLastGoodThickness) Then
                                bGood = True
                            End If
                        End If
                        If bGood Then
                            'Save Last Good
                            dLastGoodThickness = oRaw.Thickness(iRawIndex)
                        End If
                    End If

                    'Check target
                    bGood = False
                    If dPos >= dTarget And dPos <= dEnd And oRaw.Thickness(iRawIndex) > 0 Then
                        'Check for bad reading
                        'rkp - want to see bad points
                        If dPos <= 0 Then
                            bGood = False
                        ElseIf oLTG.Sheet.PointCnt = 0 Then   'save if first point
                            bGood = True
                        ElseIf GoodPoint(oRaw.Thickness(iRawIndex), dLastGoodThickness) Then
                            bGood = True
                        End If

                        'Convert Thickness
                        'The GlassRefIdx and the CalibratedGlassRefIdx is no longer used...leoc
                        'Dim dblThickness As Double = ConvertThickness(oRaw.Thickness(iRawIndex), _
                        '                                              oData.Info.GlassRefIdx, _
                        '                                              Me.CalibrationGlassRefIdx, _
                        '                                              0)
                        Dim dblThickness As Double = ConvertThickness(oRaw.Thickness(iRawIndex), 1, 1, 0)


                        '********************* Good Point *************************
                        'Check Good Point
                        If bGood Then
                            'Reset Bad Consecutive Count
                            intBadConsecPoints = 0

                            'Save Point
                            If oRaw.Position(iRawIndex) > dPrevPosition Then
                                oLTG.Sheet.AddPoint(dblThickness, _
                                                  oRaw.Distance(iRawIndex), _
                                                  oRaw.Intensity(iRawIndex), _
                                                  dTarget)

                                'Save Last Good Point
                                dLastGoodThickness = oRaw.Thickness(iRawIndex)
                            End If
                        Else
                            If oRaw.Position(iRawIndex) > dPrevPosition Then
                                oLTG.Sheet.AddPoint(oRaw.Thickness(iRawIndex), _
                                                  oRaw.Distance(iRawIndex), _
                                                  oRaw.Intensity(iRawIndex), _
                                                  dTarget)
                                ''********************* Bad Point *************************
                                oData.LTG.AddBadPoint(oRaw.Position(iRawIndex))

                                'Increment Bad Consecutive Count
                                intBadConsecPoints += 1
                                If intBadConsecPoints > oData.LTG.BadConsecutiveCnt Then
                                    oData.LTG.BadConsecutiveCnt = intBadConsecPoints
                                End If
                            End If
                        End If

                        'save prev dblPosition
                        If oRaw.Position(iRawIndex) > dPrevPosition Then
                            dPrevPosition = oRaw.Position(iRawIndex)
                        End If
                    End If

                    'Get Next Point
                    iRawIndex += 1
                Loop
            Next

            'Check Bad Point Counts
            If oData.LTG.BadOverallCnt > Me.MaxBadOverallCnt Then
                oData.LTG.Passed = False
                gLog.LogErr("LTG Max Bad Overall Points Exceeded! Count=" & Me.MaxBadOverallCnt.ToString("0"))
            End If
            If oData.LTG.BadConsecutiveCnt > Me.MaxBadConsecutiveCnt Then
                oData.LTG.Passed = False
                gLog.LogErr("LTG Max Bad Consecutive Points Exceeded! Count=" & Me.MaxBadConsecutiveCnt.ToString("0"))
            End If

            oData.LTG.SensorIdxRef = oRaw.SensorIdxRef

            'If no error then success
            If errReturn <> enumError.errFailure Then
                'Return Success
                errReturn = enumError.errSuccess
            End If

            'Return Status
            Return errReturn
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return enumError.errFailure
        End Try
    End Function

    Private Function GoodPoint(ByRef dblNew As Double, ByRef dblPrevious As Double) As Boolean
        Dim blnReturn As Boolean = False
        Dim dblPerDeviation As Double

        On Error GoTo ErrorHandler

        'Initialize Variables

        'Calculate Percent Deviation
        If dblPrevious <> 0 Then
            dblPerDeviation = (Math.Abs(dblNew - dblPrevious) / dblPrevious) * 100

            'Check Deviation against limit
            If dblPerDeviation < Me.BadPointPercentDev Then
                blnReturn = True
                'rkp @corning
            Else
                blnReturn = True

            End If
        Else
            blnReturn = True
        End If

        'Return Value
        GoodPoint = blnReturn

        Exit Function
ErrorHandler:
        gLog.LogErr("clsDP_LTG.GoodPoint(" & "), Error:" & Err.Description)
        GoodPoint = blnReturn
    End Function

    Private Function InterpThickness(ByRef dblThick1 As Double, _
                                     ByRef dblThick2 As Double, _
                                     ByRef dblPos1 As Double, _
                                     ByRef dblPos2 As Double, _
                                     ByRef dblInterpPos As Double) As Double
        Dim dblReturn As Double
        Dim dblSlope As Double

        On Error GoTo ErrorHandler

        'Initialize Variables
        dblReturn = 0

        'Linear Interpolation
        'Check for divide by 0
        If dblPos2 - dblPos1 <> 0 Then
            'Calculate Slope
            'corrected slope calculation, fjm, 11/27/06
            dblSlope = (dblThick2 - dblThick1) / (dblPos2 - dblPos1)

            'Interpolate new point, y = mx + b
            dblReturn = dblSlope * (dblInterpPos - dblPos1) + dblThick1
        End If

        'Return Value
        InterpThickness = dblReturn

        Exit Function
ErrorHandler:
        gLog.LogErr("clsDP_LTG.InterpThickness(" & "), Error:" & Err.Description)
        InterpThickness = dblReturn
    End Function

    'NOTE: modified function to use constant 1 for GlassRefIdx
    Public Function ConvertThickness(ByRef dblThickness As Double, _
                                     ByRef dblGlassRefIdx As Double, _
                                     ByRef dblSensorCalRefIdx As Double, _
                                     ByVal dblIncident_Radiant_Angle As Double) As Double
        Dim dblConverted As Double = 0

        Try
            'Initialize Variables
            dblConverted = 0

            'Check if Conversion is Needed
            If dblGlassRefIdx = Me.CalibrationGlassRefIdx Then
                dblConverted = dblThickness
            ElseIf dblIncident_Radiant_Angle = 0 Then
                dblConverted = dblThickness * dblSensorCalRefIdx / dblGlassRefIdx
            Else
                'Convert Thickness
                Dim dblNumerator As Double = 2 * dblThickness * Math.Cos(dblIncident_Radiant_Angle) * Math.Tan(ASIN((cAIR_REF_IDX / Me.CalibrationGlassRefIdx) * Math.Sin(dblIncident_Radiant_Angle)))
                dblConverted = dblNumerator / (2 * Math.Cos(dblIncident_Radiant_Angle) * Math.Tan(ASIN((cAIR_REF_IDX / dblGlassRefIdx) * Math.Sin(dblIncident_Radiant_Angle))))
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex, dblThickness)

        End Try

        'Return Value
        Return dblConverted
    End Function

    Private Function ASIN(ByRef Z As Double) As Double
        On Error GoTo ErrorHandler

        Return Math.Atan(Z / Math.Sqrt(-Z * Z + 1))

        Exit Function
ErrorHandler:
        gLog.LogErr("clsDP_LTG.ASIN(" & Z.ToString & "), Error:" & Err.Description)
    End Function

    Private Function FindEdges_Thickness(ByRef oSheet As clsData_Sheet, ByVal oRaw As clsData_LTG_Readings) As enumError

        Try
            Dim iStart As Integer = oRaw.Thickness.GetLowerBound(0)
            Dim iEnd As Integer = oRaw.Thickness.GetUpperBound(0)
            Dim iIndex As Integer
            Dim dPosition() As Double = oRaw.Position.Clone

            'Dim dMinThickness As Double = gLTG.MinThickness
            'Dim dMinIntensity As Double = gLTG.MinIntensity
            Dim iSheetStartMinConsecutiveCnt As Integer = gLTG.SheetStartMinConsectiveCount
            Dim iSheetEndMinConsecutiveCnt As Integer = gLTG.SheetEndMinConsectiveCount

            Dim bFoundLeftEdge As Boolean = False
            Dim bFoundRightEdge As Boolean = False
            Dim iConsecutiveCnt As Integer = 0

            'Initialize Variables
            _iLeftEdgeIndex = 0
            _iRightEdgeIndex = 0
            oSheet.LTG.LeftEdge = -1
            oSheet.LTG.RightEdge = -1

            gLog.LogDebug(9, "Thickness Array Length = " & oRaw.Thickness.Length().ToString())
            'Find Left Edge
            iIndex = iStart
            iConsecutiveCnt = 0
            While Not bFoundLeftEdge And (iIndex <= iEnd)
                If gLTG.GoodPoint(oRaw.Thickness(iIndex), oRaw.Distance(iIndex), oRaw.Distance2(iIndex), oRaw.Intensity(iIndex)) Then
                    iConsecutiveCnt += 1
                    If iConsecutiveCnt = 1 Then
                        _iLeftEdgeIndex = iIndex
                    ElseIf iConsecutiveCnt >= iSheetStartMinConsecutiveCnt Then
                        gLog.LogDebug(9, "LeftEdgeIndex = " & _iLeftEdgeIndex)
                        bFoundLeftEdge = True
                    End If
                Else
                    iConsecutiveCnt = 0
                    iIndex += 1
                End If
            End While

            'Find Right Edge
            iIndex = iEnd
            iConsecutiveCnt = 0
            While Not bFoundRightEdge And (iIndex >= iStart)
                If gLTG.GoodPoint(oRaw.Thickness(iIndex), oRaw.Distance(iIndex), oRaw.Distance2(iIndex), oRaw.Intensity(iIndex)) Then
                    iConsecutiveCnt += 1
                    If iConsecutiveCnt = 1 Then
                        _iRightEdgeIndex = iIndex
                    ElseIf iConsecutiveCnt >= iSheetEndMinConsecutiveCnt Then
                        gLog.LogDebug(9, "RightEdgeIndex = " & _iRightEdgeIndex)
                        bFoundRightEdge = True
                    End If
                Else
                    iConsecutiveCnt = 0
                    iIndex -= 1
                End If
            End While

            'If Edges not found, set to ends of data
            If Not bFoundLeftEdge And iStart > -1 Then
                _iLeftEdgeIndex = iStart
            End If
            If Not bFoundRightEdge And iEnd > -1 Then
                _iRightEdgeIndex = iEnd
            End If

            'Set Sheet Left and Right Edges
            oSheet.LTG.LeftEdge = dPosition(_iLeftEdgeIndex)
            oSheet.LTG.RightEdge = dPosition(_iRightEdgeIndex)

            'Success
            gLog.LogDebug(5, "Left edge position:" & oSheet.LTG.LeftEdge)
            gLog.LogDebug(5, "Right edge position:" & oSheet.LTG.RightEdge)
            'gLog.LogDebug(9, "_iLeftEdgeIndex position=" & dPosition(_iLeftEdgeIndex))
            'gLog.LogDebug(9, "_iRightEdgeIndex position=" & dPosition(_iRightEdgeIndex))
            Return enumError.errSuccess

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return enumError.errFailure
        End Try
    End Function

    Private Function FlipData(oData As clsData_LTG_Readings) As clsData_LTG_Readings
        Try
            Dim oFlipped As New clsData_LTG_Readings
            Dim dOffset As Double = oData.Position.Max
            For i As Integer = oData.Position.GetUpperBound(0) To 0 Step -1
                oFlipped.AddPoint(oData.Thickness(i),
                                  oData.Distance(i),
                                  oData.Intensity(i),
                                  dOffset - oData.Position(i),
                                  oData.Distance2(i))
            Next
            Return oFlipped

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Return oData
        End Try
    End Function

    ''' <summary>
    ''' Bin Sheet Data
    ''' </summary>
    ''' <param name="oData">Sheet Data</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BinData(ByRef oData As clsData_Sheet) As enumError

        Try
            Dim oSheet As clsData_LTG_Readings = oData.LTG.Sheet
            Dim oBinned As New clsData_LTG_Readings

            Dim dBinningDistance As Double = gConfig.LTGSpecBinningDistance
            'Step through sheet data
            Dim iSheetIndex As Integer = 0
            For dTarget As Double = 0 To oSheet.EndPointX + dBinningDistance Step dBinningDistance
                Dim dThickness As Double = 0
                Dim dIntensity As Double = 0
                Dim dDistance As Double = 0
                Dim iCount As Integer = 0

                'Get Lower and Upper Positions for Window
                Dim dLower As Double = dTarget - dBinningDistance / 2
                Dim dUpper As Double = dTarget + dBinningDistance / 2

                'Step through position array looking for data withing bin
                Dim bGetNextTarget As Boolean = False
                Do While iSheetIndex < oSheet.Position.Count - 1 And Not bGetNextTarget
                    Dim dPos As Double = oSheet.Position(iSheetIndex)

                    'Check Position against bin range
                    If dPos < gDP.LTGTrim Then
                        'Nothing to do, goto next position
                    ElseIf dPos > dLower And dPos <= dUpper Then
                        iCount += 1
                        dThickness += oSheet.Thickness(iSheetIndex)
                        dDistance += oSheet.Distance(iSheetIndex)
                        dIntensity += oSheet.Intensity(iSheetIndex)

                    ElseIf dPos > dUpper Then
                        'ElseIf dPos > (dUpper - gDP.LTGTrim) Then 'removed gDP.LTGTrim, v1.1.12

                        'If any points found for bin, average and add to dataset
                        If iCount > 0 Then
                            'Calculate Averages
                            dThickness = dThickness / iCount
                            dDistance = dDistance / iCount
                            dIntensity = dIntensity / iCount

                            oBinned.AddPoint(dThickness, dDistance, dIntensity, dTarget)

                            gLog.LogDebug(9, String.Format("Thickness Bin: Position={0}, Thickness={1}, Distance={2}, Intensity={3}",
                                                           dTarget, dThickness.ToString("0." & StrDup(gConfig.DecimalPlaces, "0"c)), dDistance, dIntensity))
                        End If

                        'Get Next Target
                        bGetNextTarget = True
                    End If

                    'Get Next Sheet Point
                    If Not bGetNextTarget Then iSheetIndex += 1
                Loop
            Next

            'Save Binned Data Arrays back to Sheet Data
            oData.LTG.Sheet = oBinned
            'oSheet.PointCnt = oBinned.PointCnt
            'oSheet.Position = oBinned.Position
            'oSheet.Thickness = oBinned.Thickness
            'oSheet.Distance = oBinned.Distance
            'oSheet.Intensity = oBinned.Intensity

            Return enumError.errSuccess

        Catch ex As Exception
            gLog.LogErr("mdlSpecs", "BinData", ex)
            Return enumError.errFailure
        End Try

    End Function
End Class