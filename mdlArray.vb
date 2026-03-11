Option Strict Off
Option Explicit On

Imports NationalInstruments.Analysis.Math

Module mdlArray
    '***************************************************************
    '
    'Module:    mdlArray.bas
    '
    'Description:   This module contains common functions for Arrays, that
    '               were not available in NI CW Array Package.
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
    '03/09/03   fjm         Created
    '
    '***************************************************************
    '******************* User Defined Types ************************

    '************************ Enuermations *************************

    '************************** Constants **************************

    '************************** Globals ****************************

    '***************************************************************
    'This subroutine replaces part of an Array with a subset.
    Public Function ArrayReplace(ByVal dblArray As Double(), _
                                ByVal dblSub As Double(), _
                                ByRef intStart As Integer) As Double()
        Dim errReturn As enumError
        Dim intSubLen As Integer
        Dim dblOutput() As Double = {}
        Dim dblArraySub1() As Double = {}
        Dim dblArraySub2() As Double = {}
        Dim intArrayLen As Integer
        Dim StartIndex As Integer = 0
        Dim ArrayLength As Integer = 0
        Dim upperBound As Integer = 0
        Dim iTempIndex As Integer = 0

        'Initialize dbliables
        errReturn = enumError.errNone
        intArrayLen = UBound(dblArray) + 1

        'Make sure Start is valid
        If intStart <= intArrayLen - 1 And intStart >= 0 Then
            'Check length of subarray
            intSubLen = UBound(dblSub) + 1
            If intStart + intSubLen > intArrayLen Then
                intSubLen = intArrayLen - intStart
                dblSub = SubsetArray(dblSub, 0, intSubLen)
            End If

            'Get ArraySub1 if needed
            If intStart > 0 Then
                dblArraySub1 = SubsetArray(dblArray, 0, intStart)
            End If

            'Get ArraySub2 if needed
            If intStart + intSubLen + 1 < intArrayLen Then
                dblArraySub2 = SubsetArray(dblArray, intStart + intSubLen, _
                                        intArrayLen - (intStart + intSubLen))
            End If

            'Build New Array
            dblOutput = ArrayOperation.Concatenate(dblArraySub1, dblSub)
            dblOutput = ArrayOperation.Concatenate(dblOutput, dblArraySub2)

            'Return Success
            errReturn = enumError.errSuccess
        Else
            'Return Failure
            errReturn = enumError.errFailure
        End If

        'Return Status
        Return dblOutput
    End Function

    '***************************************************************
    'This subroutine removes one point from within the array.
    Public Function DeleteFromArray(ByVal dblArray As Double(), ByRef dblIndex As Short) As Double()
        Dim dblSub1 As Double() = {}
        Dim dblSub2 As Double() = {}
        Dim dblOutput As Double() = {}
        Dim upperBound As Integer = 0
        Dim StartIndex As Integer = 0
        Dim iTempIndex As Integer = 0
        Dim ArrayLength As Integer = 0
        Dim i As Integer = 0

        'Intialize dbliables
        dblOutput = dblArray.Clone

        If dblIndex >= 0 And dblIndex <= UBound(dblArray) Then
            'Get Left Subarray
            If dblIndex > 0 Then
                dblSub1 = SubsetArray(dblArray, 0, dblIndex)

            End If
            'Get Right Subarray
            If dblIndex < UBound(dblArray) Then
                StartIndex = dblIndex + 1
                ArrayLength = UBound(dblArray) - dblIndex
                dblSub2 = SubsetArray(dblArray, 0, dblIndex)

            End If

            'Build New Array
            dblOutput = ArrayOperation.Concatenate(dblSub1, dblSub2)
        End If

        'Return New Array
        DeleteFromArray = dblOutput
    End Function

    '***************************************************************
    'This subroutine performs the square-root of each array element
    Public Function SqrArray(ByVal dblArray As Double()) As Double()
        Dim dblReturn As Double()
        Dim i As Integer

        'Initialize
        dblReturn = dblArray.Clone

        For i = dblReturn.GetLowerBound(0) To dblReturn.GetUpperBound(0)
            dblReturn(i) = Math.Sqrt(dblReturn(i))
        Next i

        Return dblReturn
    End Function

    '***************************************************************
    'This subroutine Mutliplies the each array element by a value
    Public Function MultArray(ByVal dblArray As Double(), ByVal dblValue As Double, Optional ByRef dblOffset As Double = 0) As Double()
        Dim dblReturn As Double()
        Dim i As Integer

        'Initialize
        dblReturn = dblArray.Clone

        For i = dblReturn.GetLowerBound(0) To dblReturn.GetUpperBound(0)
            dblReturn(i) = dblReturn(i) * dblValue + dblOffset
        Next

        Return dblReturn
    End Function

    '***************************************************************
    'This subroutine Mutliplies each array element by a value
    Public Function AddArray(ByRef dblArray() As Double, ByRef dblValue As Double) As Double()
        Dim dblReturn() As Double
        Dim i As Integer

        'Initialize
        dblReturn = dblArray.Clone

        For i = dblReturn.GetLowerBound(0) To dblReturn.GetUpperBound(0)
            dblReturn(i) += dblValue
        Next

        Return dblReturn
    End Function

    'This subroutine saves the passed array to file
    Public Function ArrayToFile(ByVal strFile As String, ByRef strHeader As String, ByVal ParamArray dblArg()() As Double) As Boolean
        Dim hndFile As Short

        Try
            Dim intArray, intArraysUpper As Integer
            Dim intPoint, intPointsUpper As Integer
            Dim strLine As String = String.Empty
            Dim dblArray As Double()
            Dim intIndex As Short

            'Initialize dbliables
            intArraysUpper = UBound(dblArg)
            intPointsUpper = UBound(dblArg(0))

            'Find largest array
            For intIndex = 0 To intArraysUpper
                If UBound(dblArg(intIndex)) > intPointsUpper Then
                    intPointsUpper = UBound(dblArg(intIndex))
                End If
            Next intIndex

            'Add Path if not found
            If InStr(strFile, ":") = 0 Then
                strFile = gstrCurDir & strFile
            End If

            'Open File
            hndFile = FreeFile()
            FileOpen(hndFile, strFile, OpenMode.Output)

            'Write Header Line
            PrintLine(hndFile, strHeader)

            'Step through Points
            For intPoint = 0 To intPointsUpper
                'Step through points
                For intArray = 0 To intArraysUpper
                    'Get Array from Parameter Array
                    dblArray = dblArg(intArray)

                    'Redim to largest size if necessary
                    If UBound(dblArray) < intPointsUpper Then
                        ReDim Preserve dblArray(intPointsUpper)
                    End If

                    'Create String
                    If intArray = 0 Then
                        strLine = dblArray(intPoint).ToString()
                    Else
                        strLine = strLine & "," & dblArray(intPoint).ToString()
                    End If
                Next intArray

                'Write to File
                PrintLine(hndFile, strLine)
            Next intPoint

            'Close file
            FileClose(hndFile)

            'Success
            Return True

        Catch ex As Exception
            gLog.LogErr("ArrayToFile(..., " & strFile & ") Error: " & Err.Description)
            Return False
        Finally
            FileClose(hndFile)
        End Try
    End Function

    '***************************************************************
    'This function detects the threshold of an array and returns the index.
    'The array can be searched forward or reverse
    Public Function GetThreshold(ByRef dblData As Double(), ByRef dblThreshold As Double, Optional ByRef blnReverse As Boolean = False, Optional ByRef blnLower As Boolean = False) As Integer
        Dim blnFound As Boolean
        Dim intIndex As Integer
        Dim intStart As Integer
        Dim intStop As Integer
        Dim intStep As Integer
        Dim intPosition As Integer

        'Initialize dbliables
        blnFound = False
        intPosition = 0

        'Calculate Start, Stop, and Step based on direction of search
        If blnReverse Then
            intStart = UBound(dblData)
            intStop = 0
            intStep = -1
        Else
            intStart = 0
            intStop = UBound(dblData)
            intStep = 1
        End If

        'Check Lower or Upper Threshold
        'Moved If outside of For-Next loop, fjm, 12/16/08
        If blnLower Then
            'Step through array
            For intIndex = intStart To intStop Step intStep
                If dblThreshold >= dblData(intIndex) Then
                    intPosition = intIndex
                    Exit For
                End If
            Next intIndex
        Else
            'Step through array
            For intIndex = intStart To intStop Step intStep
                If dblThreshold <= dblData(intIndex) Then
                    intPosition = intIndex
                    Exit For
                Else
                    intPosition = intIndex 'Save Index in case Threshold not exceeded
                End If
            Next intIndex
        End If

        'Return Position of threshold
        GetThreshold = intPosition
    End Function
    '***************************************************************************************************
    'SetArrayValue - replaces Measurement Studio SetArray
    Public Function SetArrayValue(ByVal dblArray As Double(), _
                                  ByVal dblValue As Double) As Double()

        Dim i As Integer

        For i = dblArray.GetLowerBound(0) To dblArray.GetUpperBound(0)
            dblArray(i) = dblValue
        Next

        Return dblArray

    End Function
    Public Function GetUnitVector(ByRef dblArray As Double(), _
                                  ByRef dblNorm As Double) As Double()
        Dim dblReturn As Double() = {}
        Dim dblTemp As Double() = {}
        Dim dblSum As Double
        Dim i As Integer = 0

        dblReturn = dblArray.Clone

        'Square each element of the Input Array
        dblTemp = SqArray(dblReturn)

        'get sum of all the elements in tempArray
        dblSum = ArrayOperation.Sum1D(dblTemp)

        'get Norm: square root of Array sum
        dblNorm = Math.Sqrt(dblSum)

        If dblNorm <> 0 Then
            For i = dblReturn.GetLowerBound(0) To dblReturn.GetUpperBound(0)
                'dblReturn(i) = dblArray(i) / dblNorm
                dblReturn(i) /= dblNorm
            Next
        End If

        Return dblReturn
    End Function
    Public Function Mult2Array(ByVal dblArray1() As Double, ByVal dblArray2() As Double) As Double()
        Dim i As Integer
        Dim dblReturn() As Double

        If dblArray1.GetUpperBound(0) < dblArray2.GetUpperBound(0) Then
            dblReturn = dblArray1.Clone
            For i = 0 To dblReturn.GetUpperBound(0)
                dblReturn(i) *= dblArray2(i)
            Next
        Else
            dblReturn = dblArray2.Clone
            For i = 0 To dblReturn.GetUpperBound(0)
                dblReturn(i) *= dblArray1(i)
            Next
        End If

        Return dblReturn

    End Function
    Public Function Sum2Array(ByVal dblArray1() As Double, ByVal dblArray2() As Double) As Double()
        Dim i As Integer
        Dim dblReturn() As Double

        If dblArray1.GetUpperBound(0) < dblArray2.GetUpperBound(0) Then
            dblReturn = dblArray1.Clone
            For i = 0 To dblReturn.GetUpperBound(0)
                dblReturn(i) += dblArray2(i)
            Next
        Else
            dblReturn = dblArray2.Clone
            For i = 0 To dblReturn.GetUpperBound(0)
                dblReturn(i) += dblArray1(i)
            Next
        End If

        Return dblReturn

    End Function
    Public Function Sub2Array(ByVal dblArray1() As Double, ByVal dblArray2() As Double) As Double()
        Dim i As Integer
        Dim dblReturn() As Double
        Dim intUpper As Integer

        intUpper = dblArray1.GetUpperBound(0)
        If dblArray2.GetUpperBound(0) < intUpper Then
            intUpper = dblArray2.GetUpperBound(0)
        End If
        ReDim dblReturn(intUpper)

        For i = 0 To intUpper
            dblReturn(i) = dblArray1(i) - dblArray2(i)
        Next

        Return dblReturn

    End Function
    Public Function Div2Array(ByVal dblArray1() As Double, ByVal dblArray2() As Double) As Double()
        Dim i As Integer
        Dim dblReturn() As Double
        Dim intUpper As Integer

        intUpper = dblArray1.GetUpperBound(0)
        If dblArray2.GetUpperBound(0) < intUpper Then
            intUpper = dblArray2.GetUpperBound(0)
        End If
        ReDim dblReturn(intUpper)

        For i = 0 To intUpper
            If dblArray2(i) <> 0 Then
                dblReturn(i) = dblArray1(i) / dblArray2(i)
            End If
        Next

        Return dblReturn

    End Function

    Public Function SubsetArray(ByVal dblInput() As Double, _
                                ByVal intStart As Integer, _
                                ByVal intLength As Integer) As Double()
        Dim dblReturn() As Double = {}

        ReDim dblReturn(intLength - 1)
        Array.Copy(dblInput, intStart, dblReturn, 0, intLength)

        Return dblReturn

    End Function

    '***************************************************************
    'This function retrieves the ArraySubset for the STFT
    'If number of points is greater than the size of the array, it is padded at
    'both ends.
    Public Function GetCenteredArraySubset(ByRef dblInput As Double(), ByRef intNumPoints As Integer) As Double()
        Dim dblOutput() As Double = {}
        Dim intLength As Integer
        Dim intStart As Integer
        Dim iTempIndex As Integer = 0
        Dim upperBound As Integer = 0
        Dim StartIndex As Integer = 0
        Dim ArrayLength As Integer = 0
        Dim dblTemp() As Double = {}
        Dim dblPad() As Double = {}
        Dim i As Integer = 0

        On Error GoTo ErrorHandler

        'Initialize Variables
        intLength = UBound(dblInput) ' + 1

        'Determine if number of points is larger than array
        If intNumPoints = intLength Then
            'Just copy array
            dblOutput = dblInput
        ElseIf intNumPoints < intLength Then
            'Calculate Start
            intStart = (intLength - intNumPoints) / 2

            'Get Subset
            dblOutput = SubsetArray(dblInput, intStart, intNumPoints)

        Else
            'Create Pad Array
            ReDim dblTemp(((intNumPoints - intLength) / 2) - 1)
            dblPad = dblTemp.Clone

            'Pad Array
            Dim Tempvalue() As Double
            Tempvalue = ArrayOperation.Concatenate(dblPad, dblInput)
            dblOutput = ArrayOperation.Concatenate(dblInput, dblPad)
        End If

        'Return Array
        GetCenteredArraySubset = dblOutput
        Exit Function
ErrorHandler:
        gLog.LogErr("mdlArray.GetCenteredArraySubset(), Error=" & Err.Description)
    End Function

    'This subroutine performs the square of each array element
    Public Function SqArray(ByVal dblArray As Double()) As Double()
        Dim intIndex As Integer
        Dim dblReturn As Double() = {}

        dblReturn = dblArray.Clone

        For intIndex = dblArray.GetLowerBound(0) To dblArray.GetUpperBound(0)
            dblReturn(intIndex) = dblArray(intIndex) ^ 2
        Next intIndex

        Return dblReturn

    End Function

    Public Function ConvertJaggedToSquare(ByVal dblJagged()() As Double) As Double(,)
        Dim dblArray As Double(,) = {}
        Try
            Dim i As Integer
            Dim j As Integer

            ReDim dblArray(dblJagged.GetUpperBound(0), dblJagged(0).GetUpperBound(0))

            For i = 0 To dblJagged.GetUpperBound(0)
                For j = 0 To dblJagged(0).GetUpperBound(0)
                    dblArray(i, j) = dblJagged(i)(j)
                Next
            Next
        Catch ex As Exception
            gLog.LogErr("mdlArray", "ConvertJaggedToSquare", ex)
        End Try

        Return dblArray
    End Function

End Module