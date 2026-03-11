Imports System.IO
Imports System.IO.Pipes
Imports System.Text.RegularExpressions
Imports System.Threading

Friend Class clsInterface_LTG_Precitec
    Inherits clsInterface_LTG

    Public Shared PipeName As String = "CHRPipeClient"
    Private _pipeClient As NamedPipeClientStream = Nothing
    Private _buffer As String = ""
    Private _lastRefIdxLookup As DateTime = DateTime.MinValue
    Private _sr As StreamReader = Nothing
    Private _sw As StreamWriter = Nothing

    Private _ReadValues_Thread As Threading.Thread = Nothing
    Private _ThreadExit As Boolean = False
    Private _DataCollectionThreadRunning As Boolean


    Public Overrides Sub Connect()
        Try
            'Create PipeClient
            gLog.LogDebug(9, Me.GetType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "(), Create Pipe")
            Me._pipeClient = New NamedPipeClientStream(".", clsInterface_LTG_Precitec.PipeName, PipeDirection.InOut, PipeOptions.Asynchronous)
            gLog.LogDebug(9, Me.GetType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "(), Pipe Connect")
            Me._pipeClient.Connect(5000)
            If Not IsNothing(_pipeClient) AndAlso Me._pipeClient.IsConnected Then
                gLog.LogDebug(9, Me.GetType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "(), Create StreamReader")
                _sr = New StreamReader(_pipeClient)
                _sw = New StreamWriter(_pipeClient)
                'Create Thread for reading values
                Me._ThreadExit = False
                gLog.LogDebug(9, Me.GetType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "(), Create ReadValues Thread")
                Me._ReadValues_Thread = New Threading.Thread(AddressOf ReadValues_CHRocodile_Thread)
                gLog.LogDebug(9, Me.GetType.Name & "." & System.Reflection.MethodInfo.GetCurrentMethod.Name & "(), Start ReadValues Thread")
                Me._ReadValues_Thread.Start()

                Me.SensorStatus = "Connected to PipeName = " & clsInterface_LTG_Precitec.PipeName.ToString
            Else
                Me.SensorStatus = "Unable to connect to PipeName = " & clsInterface_LTG_Precitec.PipeName.ToString
                gLog.LogErr(Me.GetType.Name & ".Connect(), " & Me.SensorStatus)
            End If
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            Me.SensorStatus = ex.Message
        End Try
    End Sub


    Public Overrides Sub Disconnect()
        Try
            If Not IsNothing(_pipeClient) AndAlso Me._pipeClient.IsConnected Then
                'Set Thread Exit Flag
                Me._ThreadExit = True
                Me._LaserMode = enumLaserMode.lsrNone

                Dim dtStart As Date = Now
                While Now.Subtract(dtStart).TotalSeconds < 3 And Me._DataCollectionThreadRunning
                    Thread.Sleep(100)
                End While



                _sr.Close()
                _sr.Dispose()
                _sr = Nothing
                _pipeClient.Close()
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Overrides Function GoodPoint(dblThickness As Double, dblDistance1 As Double, dblDistance2 As Double, dblIntensity As Double) As Boolean
        Return dblThickness >= Me.MinThickness And dblIntensity >= Me.MinIntensity
    End Function

    Private Sub ReadValues_CHRocodile_Thread()
        Try
            gLog.LogDebug(1, "ReadValues_CHRocodile_Thread: Starting, _ThreadExit=" & Me._ThreadExit.ToString)
            _DataCollectionThreadRunning = True
            While Not Me._ThreadExit
                Try
                    If Not IsNothing(Me._sr) Then
                        'gLog.LogDebug(9, "ReadValues_CHRocodile_Thread: Read Stream")

                        'Get Data from StreamReader
                        Dim cBlock(1000) As Char
                        Dim sBlock As String = ""
                        Dim iCnt As Integer = Me._sr.Read(cBlock, 0, cBlock.Length)
                        'gLog.LogDebug(9, "ReadValues_CHRocodile_Thread: Stream Read, Cnt=" & iCnt.ToString)
                        If iCnt > 0 Then
                            For i As Integer = 0 To iCnt - 1
                                Me._buffer += cBlock(i)
                                sBlock += cBlock(i)
                            Next

                            'gLog.LogDebug(9, sBlock)
                        End If

                        'Process Buffer until no more data to process
                        Dim bSuccess As Boolean = False
                        Do
                            'gLog.LogDebug(9, "ReadValues_CHRocodile_Thread: Process Buffer, Length=" & _buffer.Length.ToString)
                            bSuccess = ProcessPacket()
                        Loop While bSuccess And Not Me._ThreadExit

                        If (_sw IsNot Nothing AndAlso _pipeClient IsNot Nothing AndAlso
                            _pipeClient.IsConnected) AndAlso
                            gConfig.IdxRefLookupIntervalSecs > 0 AndAlso
                            DateTime.Now.Subtract(Me._lastRefIdxLookup).TotalSeconds >= gConfig.IdxRefLookupIntervalSecs Then
                            Me._lastRefIdxLookup = DateTime.Now
                            _sw.WriteLine("$SRI ?")
                            _sw.Flush()
                        End If
                    End If

                Catch ex As Exception
                    If Me.SensorStatus <> ex.Message Then
                        Me.SensorStatus = ex.Message
                        gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name & ".WhileLoop", ex)
                    End If
                End Try
            End While

            gLog.LogMsg("ReadValues_CHRocodile_Thread Exiting")
        Catch ex As Exception
        End Try
        _DataCollectionThreadRunning = False
    End Sub

    Private Function ProcessPacket() As Boolean
        Dim bSuccess As Boolean = False
        Dim iColon1 As Integer = _buffer.IndexOf(":")
        Dim iCommand1 As Integer = _buffer.IndexOf("$")

        Dim sPacket As String = ""

        If iCommand1 > -1 Then
            '$SRI? 1.51999998092651
            ' vbCrLf & "$SRI? 1.51999998092651" & vbCrLf
            Dim pattern As String = "^\$SRI\? (?<IOR>\d+\.\d+)\r\n"
            Dim matches As MatchCollection = Regex.Matches(_buffer, pattern, RegexOptions.Multiline)
            Dim ior As String = ""
            If matches.Count > 0 Then
                _buffer = Regex.Replace(_buffer, pattern, "", RegexOptions.Multiline)
                For Each match As Match In matches
                    ior = match.Groups.Item("IOR")?.Value
                Next
                If (Not String.IsNullOrWhiteSpace(ior)) Then
                    Double.TryParse(ior, Me.LastSensorIdxRef)
                End If
            End If
        Else
            If iColon1 > -1 Then
                Dim iCR As Integer = _buffer.IndexOf(vbCr, iColon1 + 1)
                Dim iColon2 As Integer = _buffer.IndexOf(":", iColon1 + 1)
                If iCR > -1 And (iColon2 = -1 Or iCR < iColon2) Then
                    sPacket = _buffer.Substring(0, iCR)
                    _buffer = _buffer.Substring(iCR)
                ElseIf iColon2 > iColon1 + 10 Then
                    sPacket = _buffer.Substring(0, iColon2 - 2)
                    _buffer = _buffer.Substring(iColon2 - 1)
                    bSuccess = True
                ElseIf iColon2 > -1 And iColon1 + 1 = iColon2 Then
                    _buffer = _buffer.Substring(iColon2)
                    bSuccess = True
                ElseIf iColon2 > -1 Then
                    _buffer = _buffer.Substring(iColon2 - 1)
                    bSuccess = True
                End If
            End If

            Dim cArray() As Char = {";", ":"}
            Dim sValues() As String = sPacket.Split(cArray)

            If sValues.Count = 5 AndAlso Val(sValues(0)) = 1 Then
                'Get Data
                Dim dblDistance As Double = Val(sValues(1)) / 1000
                Dim dblIntensity As Double = Val(sValues(2))
                Dim dblThickness As Double = Val(sValues(3)) / 1000
                Dim dblEncoder As Double = Val(sValues(4)) * Me.EncoderResolution

                'Add Point
                Me.AddPoint(dblThickness, dblDistance, dblIntensity, dblEncoder)
                bSuccess = True
            End If
        End If

        Return bSuccess

    End Function

End Class
