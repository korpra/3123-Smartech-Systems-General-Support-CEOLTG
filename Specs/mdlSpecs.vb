Imports System.Collections.Generic

Module mdlSpecs
    '***************************************************************
    '
    'Class:    mdlSpecs
    '
    'Description:   This class replaces calling Corning GaugeJudge to retrieve results.
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
    '2016-12-16 fjm         Created
    '2017-02-28 fjm         Added Binning
    '***************************************************************
#Region "Enumerations"
    
  
#End Region

#Region "Structures"
    Public Structure OKRejectResult
        Dim Reason As Integer  '0 indicates OK
        Dim LineMode As String
        Dim ReasonString As String   'text indicating area of failure
    End Structure
#End Region

    Public Function RunOKRejectLogicAgainstSpec(oData As clsData_Sheet) As OKRejectResult

        Dim oResults As OKRejectResult = Nothing

        Try
            Dim oSheet As clsData_LTG_Readings = oData.LTG.Sheet
            'Moved to clsDP_LTG, v1.1.12
            'If gConfig.LTGSpecBinningEnable Then
            '    oLTG_Readings = BinData(oLTG_Readings)
            'End If

            'Get Moving Window Count
            Dim movingWindowCount As Integer = If(gSpec.Thickness Is Nothing OrElse gSpec.Thickness.Ranges Is Nothing, 0, gSpec.Thickness.Ranges.Count)

            'Loop through window size specs
            Dim savedToXML As Boolean = False

            'Get Data Start and End
            Dim dStartCIRangeX As Double = oSheet.StartPointX
            Dim dEndCIRangeX As Double = oSheet.EndPointX
            'If QA Specs defined then agjust start and end, fjm, 2016-12-15
            'Added QAOffset to the start position, fjm, v1.1.4
            'VBOffset = (Measured - ProductWidth)/2, fjm, v1.1.7
            If gSpec.QualityWidth IsNot Nothing Then
                dStartCIRangeX = oData.Info.QAStart
                dEndCIRangeX = oData.Info.QAEnd

                gLog.LogDebug(9, String.Format("Quality Area for moving window: Start={0}, End={1}", dStartCIRangeX, dEndCIRangeX))
            End If

            'Calculate Thickness metrics
            Dim maxThickness As Double = 0
            Dim minThickness As Double = 9999
            Dim avgThickness As Double = 0
            Dim avgThicknessCnt As Integer = 0
            Dim rangeThickness As Double = 0
            For i As Integer = 0 To oSheet.Thickness.Count - 1
                Dim dPos As Double = oSheet.Position(i)
                Dim dThick As Double = oSheet.Thickness(i)

                'Check for quality area
                If dPos < dStartCIRangeX Then
                    'Nothing to do, not in quality area
                ElseIf dPos <= dEndCIRangeX Then
                    'In quality area, get calculate thickness metrics
                    If dThick > maxThickness Then maxThickness = dThick
                    If dThick < minThickness Then minThickness = dThick
                    avgThickness += dThick
                    avgThicknessCnt += 1
                Else
                    'All done
                    Exit For
                End If
            Next
            'Round Data to 4 decimal places
            maxThickness = Math.Round(maxThickness, gConfig.DecimalPlaces)
            minThickness = Math.Round(minThickness, gConfig.DecimalPlaces)
            If avgThicknessCnt > 0 Then avgThickness = Math.Round(avgThickness / avgThicknessCnt, gConfig.DecimalPlaces)
            rangeThickness = maxThickness - minThickness
            gLog.LogDebug(9, String.Format("Thickness Data: Avg={0}, Min={1}, Max={2}, Range={3}", avgThickness, minThickness, maxThickness, rangeThickness.ToString("0." & StrDup(gConfig.DecimalPlaces, "0"c))))

            'Save Values back to LTG, v1.1.8
            oData.LTG.QAThicknessAvg = avgThickness
            oData.LTG.QAThicknessMin = minThickness
            oData.LTG.QAThicknessMax = maxThickness
            oData.LTG.QAThicknessRng = rangeThickness

            'Step through moving range windows
            For index As Integer = 0 To (movingWindowCount - 1)
                Dim oMWR As New clsSpec_MWR
                oMWR.WindowSize = gSpec.Thickness.Ranges(index).WindowSize
                oMWR.CalcMWR = MovingRangeMax(oSheet, oMWR.WindowSize, dStartCIRangeX, dEndCIRangeX)
                oMWR.SpecMWR = gSpec.Thickness.Ranges(index).MaximumRange.GetValueOrDefault(0).Distance / 1000D

                If oMWR.SpecMWR > 0D AndAlso oMWR.CalcMWR > oMWR.SpecMWR Then
                    oMWR.Reject = True
                End If

                If oMWR.Reject Then
                    oResults.Reason = 16
                    'oResults.ReasonString = "Reject: " & oMWR.WindowSize & "mm THICKNESS"
                    oResults.ReasonString = "Reject: " & oMWR.WindowSize & "mm MWR" 'v1.1.12
                End If

                'Add to Sheet Info MWR List, v1.1.12
                oData.LTG.QAMWR.Add(oMWR)
            Next index

            'Check general thickness specs
            If (gSpec IsNot Nothing) AndAlso (gSpec.Thickness IsNot Nothing) Then
                'Updated from QAThicknessMin to QAThicknessMinimum, fjm , 3/16/2025
                If (gSpec.Thickness.QAThicknessMinimum.HasValue) AndAlso (gSpec.Thickness.QAThicknessMinimum.Value.Distance > 0D) AndAlso (minThickness < gSpec.Thickness.QAThicknessMinimum.Value.Distance) Then
                    oResults.Reason = 16
                    oResults.ReasonString = "Reject Min THICKNESS"
                End If

                'Updated from QAThicknessMax to QAThicknessMaximum, fjm , 3/16/2025
                If (gSpec.Thickness.QAThicknessMaximum.HasValue) AndAlso (gSpec.Thickness.QAThicknessMaximum.Value.Distance > 0D) AndAlso (maxThickness > gSpec.Thickness.QAThicknessMaximum.Value.Distance) Then
                    oResults.Reason = 16
                    oResults.ReasonString = "Reject Max THICKNESS"
                End If

                'Updated from QAThicknessRangeMax to QAThicknessRangeMaximum, fjm , 3/16/2025
                If (gSpec.Thickness.QAThicknessRangeMaximum.HasValue) AndAlso (gSpec.Thickness.QAThicknessRangeMaximum.Value.Distance > 0D) AndAlso (rangeThickness > (gSpec.Thickness.QAThicknessRangeMaximum.Value.Distance / 1000D)) Then
                    oResults.Reason = 16
                    oResults.ReasonString = "Reject: RANGE Thickness"
                End If

                'Updated from QAThicknessMaxAverage to QAThicknessMaximumAverage, fjm , 3/16/2025
                If (gSpec.Thickness.QAThicknessMaximumAverage.HasValue) AndAlso (gSpec.Thickness.QAThicknessMaximumAverage.Value.Distance > 0D) AndAlso (avgThickness > gSpec.Thickness.QAThicknessMaximumAverage.Value.Distance) Then
                    oResults.Reason = 16
                    oResults.ReasonString = "Reject: Positive_Avg_Tolerance Thickness"
                End If

                'Updated from QAThicknessMinAverage to QAThicknessMinimumAverage, fjm , 3/16/2025
                If (gSpec.Thickness.QAThicknessMinimumAverage.HasValue) AndAlso (gSpec.Thickness.QAThicknessMinimumAverage.Value.Distance > 0D) AndAlso (avgThickness < gSpec.Thickness.QAThicknessMinimumAverage.Value.Distance) Then
                    oResults.Reason = 16
                    oResults.ReasonString = "Reject: Negative_Avg_Tolerance Thickness"
                End If
            End If

            'Set reason text
            Select Case oResults.Reason
                Case 0
                    oResults.LineMode = "OK"
                    oResults.ReasonString = ""
                Case 64
                    oResults.LineMode = "DOWNGRADE"
                Case Else
                    oResults.LineMode = "REJECT"
            End Select
        Catch ex As Exception
            gLog.LogErr("mdlSpecs", System.Reflection.MethodInfo.GetCurrentMethod.Name, ex, "Error in RunOKReject logic.")
        End Try

        gLog.LogDebug(1, String.Format("OKRejectResults: LineMode= " & oResults.LineMode & ", Reason=" & oResults.ReasonString))
        Return oResults
    End Function

    Private Function MovingRangeMax(oLTGData As clsData_LTG_Readings, windowSize As Integer, dStartCIRangeX As Double, dEndCIRangeX As Double) As Double
        Dim dMaxRange As Double = 0

        Try
            ' only bother proceeding if the range is at least as large as the window
            If (dEndCIRangeX - dStartCIRangeX) >= windowSize Then
                ' get the decimal version of the xy data
                ' the ThicknessSampleCalculation has already truncated the xydata to be between the starting and ending CI X ranges
                ' cast back to arrays for performance reasons, as seems the IList interface is sometimes slow pre-.NET4.0 for arrays
                Dim xLocations() As Double = oLTGData.Position.Clone 'DirectCast(mySampleCalculation.XLocations(FDMSide.FDMSide.CI), Decimal())
                Dim yThicknesses() As Double = oLTGData.Thickness.Clone 'DirectCast(mySampleCalculation.YThicknesses(FDMSide.FDMSide.CI), Decimal())

                ' number of points (local copy for performance)
                Dim pointCount As Integer = xLocations.Length

                ' The farthest valid moving window starting point.  Value depends on which way we are moving through the points.
                Dim cutoffCIForMWRStartX = dEndCIRangeX - windowSize

                ' each iteration is the starting point for looking at a window of values
                For iMWRStart As Integer = 0 To pointCount - 1
                    ' thickness value for this starting point
                    Dim dY As Double = yThicknesses(iMWRStart)

                    ' skip this window if the starting point is invalid (the single to decimal conversion may have converted NaN or Infinity to zero)
                    If dY <> 0D Then
                        ' x location of the starting point
                        Dim dX As Double = xLocations(iMWRStart)

                        If (dX > cutoffCIForMWRStartX) Then
                            ' moved too close to the end of the entire range
                            Exit For
                        ElseIf (dX < dStartCIRangeX) Then
                            'nothing to do, move to next start position, v1.1.13
                        Else
                            ' and we can default the min and max to this first value, which simplifies logic later, as we don't have to support a null or anything
                            Dim maxThickness As Double = dY
                            Dim minThickness As Double = dY

                            ' determines the farthest valid distance before this window is out of range and before the whole range is out of range, depends on the direction through the points we are moving
                            Dim cutoffCIForMWREndX = Math.Min(dX + windowSize, dEndCIRangeX)

                            ' this for loop is for within this window, moving forward or backward
                            For iMWRCurrent As Integer = iMWRStart To pointCount - 1
                                If (xLocations(iMWRCurrent) > cutoffCIForMWREndX) Then
                                    ' moved past our boundary
                                    Exit For
                                Else
                                    ' thickness value for this position within the window
                                    Dim currentY = yThicknesses(iMWRCurrent)

                                    If currentY = 0D Then
                                        ' invalid, so skip
                                    ElseIf currentY < minThickness Then
                                        ' it is more min
                                        minThickness = currentY
                                    ElseIf currentY > maxThickness Then
                                        ' it is more max
                                        maxThickness = currentY
                                    End If
                                End If
                            Next

                            ' the range between min and max thickness (local copy for performance)
                            Dim currentRange = maxThickness - minThickness

                            'gLog.LogDebug(9, String.Format("MovingRangeMax(), WindwosSize={0}, Range={1}, LocationX={2}", windowSize, currentRange, dX))


                            ' determine if it is the max range so far
                            If currentRange > dMaxRange Then
                                dMaxRange = currentRange
                            End If
                        End If
                    End If
                Next
            End If

            gLog.LogDebug(1, String.Format("MovingRangeMax(), WindwosSize={0}, MaxRange={1}", windowSize, dMaxRange.ToString("0." & StrDup(gConfig.DecimalPlaces, "0"c))))

        Catch ex As Exception
            gLog.LogErr("mdlSpecs", System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

        Return dMaxRange
    End Function


End Module
