Imports System.Collections.Generic
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading

Friend Class clsInterface_LTG_KeyenceCL3000
    Inherits clsInterface_LTG

    Public Shared IpAddress As String = "192.168.0.1"
    Public Shared IpPort As String = "24685"
    Private _bIsConnected As Boolean = False
    Private mReadValues_Thread As Threading.Thread = Nothing
    Private mblnThreadExit As Boolean = False
    Public LastError As Short = 0
    Private bResetDataStorage As Boolean = False


    Public Overrides Sub Connect()
        Try
            'Determine Sensor Type
            gLog.LogDebug(5, $"clsInterface_LTG(), Connecting to Keyence CL3000")
            'Dim tmp As UInt16 = UInt16.Parse(clsInterface_LTG_KeyenceCL3000.IpPort)
            'Dim ip As System.Net.IPAddress = Nothing
            'Dim result As Boolean = Net.IPAddress.TryParse("192.168.0.1", ip)


            ' Dim returnCode As Integer = CL3IF.CL3IF_OpenUsbCommunication(0, 5000)
            Dim ethernetSetting As New CL3IF_ETHERNET_SETTING() With {
                .ipAddress = Net.IPAddress.Parse(clsInterface_LTG_KeyenceCL3000.IpAddress).GetAddressBytes(),
                .portNo = UInt16.Parse(clsInterface_LTG_KeyenceCL3000.IpPort)
            }

            Dim returnCode As Integer = CL3IF.CL3IF_OpenEthernetCommunication(0, ethernetSetting, 5000) ' .CL3IF_OpenUsbCommunication(0, 5000)
            If returnCode = CL3IF.CL3IF_RC_OK Then
                gLog.LogMsg("Keyence CL3000 Connection Successful.")
                _bIsConnected = True

                Me.mblnThreadExit = False

                returnCode = CL3IF.CL3IF_StopStorage(0)
                If returnCode <> CL3IF.CL3IF_RC_OK Then
                    gLog.LogErr("Keyence CL3000 CL3IF_StopStorage(), Error=" + returnCode.ToString)
                End If

                returnCode = CL3IF.CL3IF_ClearStorageData(0)
                If returnCode <> CL3IF.CL3IF_RC_OK Then
                    gLog.LogErr("Keyence CL3000 CL3IF_ClearStorageData(), Error=" + returnCode.ToString)
                End If

                returnCode = CL3IF.CL3IF_StartStorage(0)
                'Added ERR_INITIALIZE IS OK, v4.2.1
                If returnCode <> CL3IF.CL3IF_RC_OK Then
                    gLog.LogErr("Keyence CL3000 CL3IF_StartStorage(), Error=" + returnCode.ToString)
                    'Return False
                End If

                Me.mReadValues_Thread = New Threading.Thread(AddressOf ReadValues_KeyenceCL3000_Thread)
                gLog.LogDebug(10, "clsInterface_LTG.StartLTG(), ReadValues_KeyenceCL3000_Thread")
                Me.mReadValues_Thread.Start()

            Else
                gLog.LogErr("Keyence CL3000 Connection Failed, Error=" + returnCode.ToString)
            End If


        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "Connect", ex)
            Me.LastError = ex.Message
        End Try
    End Sub

    Public Overrides Sub Disconnect()
        Try
            Dim err As Integer

            gLog.LogDebug(10, "clsInterface_LTG.Disconnect()")

            Me.mblnThreadExit = True
            'Added a flagged to help speed up data thread exit dectection
            Dim dtStart As Date = Now
            While Now.Subtract(dtStart).TotalSeconds < 3 And Me.CL3000_DataCollectionThreadRunning
                Thread.Sleep(100)
            End While

            Dim returnCode As Integer = CL3IF.CL3IF_StopStorage(0)
            If returnCode <> CL3IF.CL3IF_RC_OK Then
                gLog.LogErr("Keyence CL3000 CL3IF_StopStorage(), Error=" + returnCode.ToString)
            End If



            returnCode = CL3IF.CL3IF_CloseCommunication(0)
            If returnCode <> CL3IF.CL3IF_RC_OK Then
                gLog.LogErr("Close Keyence CL3000 Disconnect Connection Failed, Error=" + returnCode.ToString)
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "Disconnect", ex)
        Finally
            _bIsConnected = False
        End Try
    End Sub

    Public Overrides Function GoodPoint(dblThickness As Double, dblDistance1 As Double, dblDistance2 As Double, dblIntensity As Double) As Boolean
        Return dblThickness >= Me.MinThickness AndAlso
            dblDistance1 >= Me.MinDistance AndAlso
            dblDistance1 <= Me.MaxDistance AndAlso
            dblDistance2 >= Me.MinDistance AndAlso
            dblDistance2 <= Me.MaxDistance
    End Function

#Region "Keyence CL3000"
    Private Const CurrentDeviceId As Integer = 0

    Private Const MaxRequestDataLength As Integer = 512000

    ' Maximum number of acquired data per time
    Private Const MaxMeasurementDataCountPerTime As Integer = 8000

    Private _sequenceStorageIndex As UInteger
    Private CL3000_DataCollectionThreadRunning As Boolean


    Private Sub ReadValues_KeyenceCL3000_Thread()
        Try
            Dim buffer As Byte() = New Byte(MaxRequestDataLength - 1) {}
            ' Get storage index
            Dim index As UInteger = 0
            Dim selectedIndex As CL3IF_SELECTED_INDEX = CL3IF_SELECTED_INDEX.CL3IF_SELECTED_INDEX_NEWEST
            Dim returnCodeStorageIndex As Integer = CL3IF.CL3IF_GetStorageIndex(CurrentDeviceId, selectedIndex, index)

            If returnCodeStorageIndex <> CL3IF.CL3IF_RC_OK Then
                gLog.LogErr("Keyence CL3000 CL3IF_GetStorageIndex(), Error=" + returnCodeStorageIndex.ToString)
            End If

            Dim indexGet As UInteger = index
            _sequenceStorageIndex = indexGet

            ' Get storage data continuously
            Me.CL3000_DataCollectionThreadRunning = True
            While Not Me.mblnThreadExit

                Dim nextIndex As UInteger = 0
                Dim obtainedDataCount As UInteger = 0
                Dim returnCodeStorageData As Integer = 0
                Dim outTarget As CL3IF_OUTNO = 0
                Using pin As New PinnedObject(buffer)
                    'Dim nIndex As UInteger = 0
                    'Dim ret As Integer = CL3IF.CL3IF_GetStorageIndex(CurrentDeviceId, CL3IF_SELECTED_INDEX.CL3IF_SELECTED_INDEX_NEWEST, nIndex)
                    returnCodeStorageData = CL3IF.CL3IF_GetStorageData(CurrentDeviceId, indexGet, MaxMeasurementDataCountPerTime, nextIndex, obtainedDataCount, outTarget,
                    pin.Pointer)

                    'If nextIndex = 0 OrElse returnCodeStorageData <> CL3IF.CL3IF_RC_OK Then, v4.2.1
                    'CL3IF.CL3IF_RC_ERR_UNIQUE_ERROR2 is returned when there is no new data.  This is a possibility when triggering from the encoder
                    If returnCodeStorageData <> CL3IF.CL3IF_RC_OK AndAlso returnCodeStorageData <> CL3IF.CL3IF_RC_ERR_UNIQUE_ERROR2 Then
                        gLog.LogErr($"Keyence CL3000 CL3IF_GetStorageData(), Index={nextIndex}  Error={returnCodeStorageData}")
                        If returnCodeStorageData <> CL3IF.CL3IF_RC_ERR_INITIALIZE Then
                            Me.mblnThreadExit = True
                            Exit While
                        End If
                    End If

                    If nextIndex = 0 Then
                        gLog.LogDebug(9, $"Keyence CL3000 CL3IF_GetStorageData(), Index={nextIndex}")
                    Else
                        gLog.LogDebug(9, $"Keyence CL3000 CL3IF_GetStorageData(), Index={nextIndex}, ObtainedDataCount={obtainedDataCount}")

                        ''Get Position, get once and calculate distance between points
                        ''Dim dCounter2_Position As Double = gDAQ.Counter2_Position
                        ''Dim dPointStartPosition As Double = dCounter2_Position - dPointSpacing * (obtainedDataCount - 1)

                        indexGet = nextIndex
                        Dim outTargetList As List(Of Integer) = Keyence_ConvertOutTargetList(outTarget)
                        Dim readPosition As Integer = 0
                        For i As Integer = 0 To CInt(obtainedDataCount - 1)
                            Dim dThick As Double = 0
                            Dim dDist1 As Double = 0
                            Dim dDist2 As Double = 0
                            Dim dPosition As Double = 0 ' dPointStartPosition + dPointSpacing * i

                            Dim addInfo As CL3IF_ADD_INFO = CType(Marshal.PtrToStructure(pin.Pointer + readPosition, GetType(CL3IF_ADD_INFO)), CL3IF_ADD_INFO)
                            dPosition = addInfo.pulseCount * Me.EncoderResolution

                            readPosition += Marshal.SizeOf(GetType(CL3IF_ADD_INFO))

                            For j As Integer = 0 To outTargetList.Count - 1
                                Dim oData As CL3IF_OUTMEASUREMENT_DATA = CType(Marshal.PtrToStructure(pin.Pointer + readPosition, GetType(CL3IF_OUTMEASUREMENT_DATA)), CL3IF_OUTMEASUREMENT_DATA)

                                Select Case j
                                    Case 0 : dDist1 = oData.measurementValue / 10000
                                    Case 1 : dDist2 = oData.measurementValue / 10000
                                    Case 2 : dThick = oData.measurementValue / 10000

                                End Select

                                readPosition += Marshal.SizeOf(GetType(CL3IF_OUTMEASUREMENT_DATA))
                            Next

                            Me.AddPoint(dThick, dDist1, 0, dPosition, dDist2)

                        Next
                    End If

                End Using

                If Me.bResetDataStorage OrElse index >= 99000 Then ' reset data storage
                    bResetDataStorage = False
                    Dim returnCode As Integer = CL3IF.CL3IF_StopStorage(CurrentDeviceId)
                    If returnCode <> CL3IF.CL3IF_RC_OK Then
                        gLog.LogErr("Keyence CL3000 CL3IF_StopStorage(), Error=" + returnCode.ToString)
                    End If

                    returnCode = CL3IF.CL3IF_ResetPulseCount(CurrentDeviceId)

                    If returnCode <> CL3IF.CL3IF_RC_OK Then
                        gLog.LogErr("Keyence CL3000 CL3IF_ResetPulseCount(), Error=" + returnCode.ToString)
                    End If


                    returnCode = CL3IF.CL3IF_ClearStorageData(CurrentDeviceId)
                    If returnCode <> CL3IF.CL3IF_RC_OK Then
                        gLog.LogErr("Keyence CL3000 CL3IF_ClearStorageData(), Error=" + returnCode.ToString)
                    End If

                    returnCode = CL3IF.CL3IF_StartStorage(CurrentDeviceId)
                    'Added ERR_INITIALIZE IS OK, v4.2.1
                    If returnCode <> CL3IF.CL3IF_RC_OK Then
                        gLog.LogErr("Keyence CL3000 CL3IF_StartStorage(), Error=" + returnCode.ToString)
                        'Return False
                    End If

                    returnCodeStorageIndex = CL3IF.CL3IF_GetStorageIndex(CurrentDeviceId, selectedIndex, index)

                    If returnCodeStorageIndex <> CL3IF.CL3IF_RC_OK Then
                        gLog.LogErr("Keyence CL3000 CL3IF_GetStorageIndex(), Error=" + returnCodeStorageIndex.ToString)
                    End If

                    indexGet = index
                    _sequenceStorageIndex = indexGet

                End If

                System.Threading.Thread.Sleep(50)
            End While

            gLog.LogDebug(10, "Exit ReadValues_KeyenceCL3000_Thread")
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "ReadValues_KeyenceCL3000_Thread", ex)
        Finally
            Me.CL3000_DataCollectionThreadRunning = False

        End Try

    End Sub
    Public Overrides Sub SetMode(ByRef laserMode As enumLaserMode)
        If laserMode = enumLaserMode.lsrMonitor Then
            bResetDataStorage = True
        End If
        MyBase.SetMode(laserMode)
    End Sub
    Private Function Keyence_ConvertOutTargetList(outTarget As CL3IF_OUTNO) As List(Of Integer)
        Dim mask As Byte = 1
        Dim outList As New List(Of Integer)()
        For i As Integer = 0 To CL3IF.CL3IF_MAX_OUT_COUNT - 1
            If (CUShort(outTarget) And mask) <> 0 Then
                outList.Add(i + 1)
            End If
            mask = CByte(mask << 1)
        Next
        Return outList
    End Function
#End Region

End Class
