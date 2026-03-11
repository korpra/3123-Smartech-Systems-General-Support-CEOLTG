Imports System.Collections.Generic
Imports NationalInstruments.Analysis

''' <summary>
'''This class is part of the Data Processing.  It is used to filter the thickness data.
'''
'''Created by:    Smartech Systems, Inc.
'''               500 East Brighton Ave
'''               Syracuse, NY 13210
'''               www.s2ieng.com
'''               Phone:  315-701-2316
'''               Fax:    315-701-2317
'''
'''
'''
'''Modifications:
'''Date         Initials    Description
'''2019-02-21   fjm         Created
''' </summary>
Class clsDP_Filtering


    ''' <summary>
    ''' Calculate Moving Window Average for defined Window Size
    ''' </summary>
    ''' <param name="dData"></param>
    ''' <param name="iWindowSize"></param>
    ''' <returns></returns>
    Public Function MovingAverage(dData As Double(), iWindowSize As Integer) As Double()
        Dim dReturn As Double() = {}

        Try
            'Get Upper Bound
            Dim iUpper As Integer = dData.GetUpperBound(0)

            'Resize Return Data Array
            ReDim dReturn(dData.GetUpperBound(0))

            'Step thru Array
            For i As Integer = 0 To iUpper
                Dim dSum As Double = 0
                Dim iCount As Integer = 0

                'Step thru values to average
                For j As Integer = i To i + iWindowSize - 1
                    If j <= iUpper Then
                        dSum += dData(j)
                        iCount += 1
                    End If
                Next

                'Calculate Average
                If iCount > 0 Then
                    dReturn(i) = dSum / iCount
                Else
                    dReturn(i) = 0
                End If
            Next
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

        Return dReturn
    End Function

    ''' <summary>
    ''' Calculate Moving Window Median for defined Window Size.  Window size represents position in mm.
    ''' </summary>
    ''' <param name="oRaw"></param>
    ''' <param name="dStartPosition"></param>
    ''' <param name="dEndPosition"></param>
    ''' <param name="dWindowSize"></param>
    ''' <returns></returns>
    Public Function MovingMedian(oRaw As clsData_LTG_Readings, dStartPosition As Double, dEndPosition As Double, dWindowSize As Double) As Double()
        Dim dReturn As Double() = {}

        Try
            'Get Upper Bound
            Dim iLower As Integer = oRaw.Thickness.GetLowerBound(0)
            Dim iUpper As Integer = oRaw.Thickness.GetUpperBound(0)

            'Resize Return Data Array
            ReDim dReturn(iUpper)

            'Step thru Array
            For i As Integer = iLower To iUpper
                Dim lstWindow As New List(Of Double)

                'Define upper and lower position limits based on Window Size
                Dim dLowerLimit As Double = oRaw.Position(i) - dWindowSize / 2
                Dim dUpperLimit As Double = oRaw.Position(i) + dWindowSize / 2

                'Limit Window Size if extends outside of Glass
                If dLowerLimit < dStartPosition Then dLowerLimit = dStartPosition
                If dUpperLimit > dEndPosition Then dUpperLimit = dEndPosition

                'Add Current Position to List
                lstWindow.Add(oRaw.Thickness(i))

                'Grab values in positive and negative direction until one direction is outside of the valid range
                Dim j As Integer = 1
                Do While (i - j) >= iLower And (i + j) <= iUpper
                    If oRaw.Position(i - j) >= dLowerLimit And oRaw.Position(i + j) <= dUpperLimit Then
                        'Add both values to list
                        lstWindow.Add(oRaw.Thickness(i - j))
                        lstWindow.Add(oRaw.Thickness(i + j))
                    Else
                        'Done
                        Exit Do
                    End If

                    'Increment index
                    j += 1
                Loop

                'Sort Window
                lstWindow.Sort()

                'Calculate Median
                If lstWindow.Count = 0 Then
                    dReturn(i) = 0
                ElseIf lstWindow.Count Mod 2 = 0 Then
                    dReturn(i) = (lstWindow(lstWindow.Count \ 2 - 1) + lstWindow(lstWindow.Count \ 2)) / 2
                Else
                    dReturn(i) = lstWindow(lstWindow.Count \ 2)
                End If
            Next
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

        Return dReturn
    End Function

    ''' <summary>
    ''' Preform SavitzkyGolay Filter
    ''' </summary>
    ''' <param name="dData"></param>
    ''' <param name="iPolyOrder"></param>
    ''' <param name="iSidePoints"></param>
    ''' <returns></returns>
    Public Function SavitzkyGolayFilter(dData As Double(), iPolyOrder As Integer, iSidePoints As Integer) As Double()
        Dim dReturn As Double() = {}

        Try
            'Savitzky-Golay Filter
            dReturn = Dsp.Filters.SavitzkyGolay.Filter(dData, iPolyOrder, iSidePoints)
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

        Return dReturn
    End Function
    Public Function SGFilterData(ByRef objRaw As clsData_LTG_Readings, Optional filterWindowSize As Integer = 9) As clsData_LTG_Readings
        Dim filterOrder As Integer = 3
        Dim filterSidePoints As Integer = (filterWindowSize - 1) / 2
        Dim objFiltered As New clsData_LTG_Readings

        Dim thickness As New List(Of Double)(objRaw.Thickness)
        Dim distance As New List(Of Double)(objRaw.Distance)
        Dim intensity1 As New List(Of Double)(objRaw.Intensity)
        Dim position As New List(Of Double)(objRaw.Position)

        'add inverted points so the filtered edges are treated correctly
        ' By adding the inversion of the first And last set of points to our data array following data binning (5mm buckets)
        'The Number Of points To invert would depend On the window size;
        'If window size Is n, the number of points to invert would be equal to ((n-1)/2)
        If (thickness.Count) >= filterSidePoints Then
            thickness.InsertRange(0, thickness.GetRange(1, filterSidePoints).ToArray.Reverse)
            thickness.AddRange(thickness.GetRange(thickness.Count - filterSidePoints - 1, filterSidePoints).ToArray.Reverse)

            distance.InsertRange(0, distance.GetRange(1, filterSidePoints).ToArray.Reverse)
            distance.AddRange(distance.GetRange(distance.Count - filterSidePoints - 1, filterSidePoints).ToArray.Reverse)

            intensity1.InsertRange(0, intensity1.GetRange(1, filterSidePoints).ToArray.Reverse)
            intensity1.AddRange(intensity1.GetRange(intensity1.Count - filterSidePoints - 1, filterSidePoints).ToArray.Reverse)

            position.InsertRange(0, position.GetRange(0, filterSidePoints).ToArray.Reverse)
            position.AddRange(position.GetRange(position.Count - filterSidePoints - 1, filterSidePoints).ToArray.Reverse)

            'Apply the savinsky golay filter
            thickness = SavitzkyGolay.Filter(thickness.ToArray, filterOrder, filterSidePoints).ToList
            distance = SavitzkyGolay.Filter(distance.ToArray, filterOrder, filterSidePoints).ToList
            intensity1 = SavitzkyGolay.Filter(intensity1.ToArray, filterOrder, filterSidePoints).ToList

            'step through the points from the filter
            For i As Integer = filterSidePoints To thickness.Count - filterSidePoints - 1
                objFiltered.AddPoint(thickness(i),
                     distance(i),
                     intensity1(i),
                     position(i))
            Next
        End If

        Return objFiltered

    End Function

    ''' <summary>
    ''' Preform Gaussian Fit
    ''' </summary>
    ''' <param name="dDataX"></param>
    ''' <param name="dDataY"></param>
    ''' <returns></returns>
    Public Function GaussianFit(dDataX As Double(), dDataY As Double()) As Double()
        Dim dReturn As Double() = {}

        Try
            'GaussianFit
            dReturn = Analysis.Math.CurveFit.GaussianFit(dDataX, dDataY)
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

        Return dReturn
    End Function
End Class
