Imports OPCAutomation

Friend Class clsInterface_PLC
    '***************************************************************
    '
    'Class:    clsInterface_PLC
    '
    'Description:   This class is used for communicating to the Conveyor PLC.
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
    '2009-05-14 fjm         Created
    '
    '***************************************************************

    '************************** Events *****************************
    Event NextSheetArrival(ByVal NextSheetTimeStamp As Date, ByVal NextSheetHeight As Single)

    '************************** Constants **************************
    Const cUrlPrefix As String = "opc:/"

    '************************** Publics ****************************
    Public OPCServerName As String = ""
    Public OPCPollTime As Single = "1000"

    Public OPCItem_ToGauge_BornDateYear As String = ""
    Public OPCItem_ToGauge_BornDateMonth As String = ""
    Public OPCItem_ToGauge_BornDateDay As String = ""
    Public OPCItem_ToGauge_BornTimeHour As String = ""
    Public OPCItem_ToGauge_BornTimeMinute As String = ""
    Public OPCItem_ToGauge_BornTimeSecond As String = ""

    Public OPCItem_ToGauge_UID As String = ""
    Public OPCItem_FromGauge_UID As String = ""
    Public OPCItem_FromGauge_DataReceived As String = ""
    Public OPCItem_FromGauge_Defects1 As String = ""
    Public OPCItem_FromGauge_InspectionValid As String = ""

    Public OPCItem_FromGauge_SensorIdxRef As String = ""
    Public OPCItem_FromGauge_MeasuredWidth As String = ""

    'Post measurment OPC Items
    Public PostMeasurementOPCActive As Boolean = False
    Public OPCItem_FromGauge_Max As String = ""
    Public OPCItem_FromGauge_Min As String = ""
    Public OPCItem_FromGauge_Average As String = ""
    Public OPCItem_FromGauge_75mmMWR As String = ""


    Public OPCItem_WriteHeartbeat As String = ""
    Public WriteHeartbeatPeriod As Integer = 5

    Public BornDateYearVal As Integer = DateTime.MinValue.Year
    Public BornDateMonthVal As Integer = DateTime.MinValue.Month
    Public BornDateDayVal As Integer = DateTime.MinValue.Day
    Public BornTimeHourVal As Integer = DateTime.MinValue.Hour
    Public BornTimeMinuteVal As Integer = DateTime.MinValue.Minute
    Public BornTimeSecondVal As Integer = DateTime.MinValue.Second

    Public UID As Integer = 0
    Public DataReceived As Integer = 0
    Public Defects1 As String = 0
    Public InspectionValid As Integer = 0

    Public blnReadValuesFromPLC = False

    Public BornDT As DateTime
    '************************* Privates ****************************
    Private WithEvents mobjOPCServer As OPCServer
    Private WithEvents mobjOPCGroupRead As OPCGroup
    Private WithEvents mobjOPCGroupWrite As OPCGroup

    Public mobjOPCItem_ToGauge_BornDateYear As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_BornDateMonth As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_BornDateDay As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_BornTimeHour As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_BornTimeMinute As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_BornTimeSecond As OPCItem = Nothing
    Public mobjOPCItem_ToGauge_UID As OPCItem = Nothing

    Public mobjOPCItem_FromGauge_UID As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_DataReceived As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_Defects1 As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_InspectionValid As OPCItem = Nothing

    Public mobjOPCItem_WriteHeartbeat As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_MeasuredWidth As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_PrecitecIOR As OPCItem = Nothing

    Private ScanTimeStamp As New Date(0)


    Public mobjOPCItem_FromGauge_Max As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_Min As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_Average As OPCItem = Nothing
    Public mobjOPCItem_FromGauge_75mmMWR As OPCItem = Nothing

    Public Sub New()
        Try


        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Me.Disconnect()
        Catch ex As Exception

        End Try
        MyBase.Finalize()
    End Sub

    Public Sub Connect()

        Try
            If Me.OPCServerName.Length > 0 Then
                'Disconnect if already defined
                If Not Me.mobjOPCServer Is Nothing Then
                    Me.Disconnect()
                End If

                'Connect to Server
                Me.mobjOPCServer = New OPCServer
                Me.mobjOPCServer.Connect(Me.OPCServerName)

                'Pause 5 seconds to allow OPC server to start
                'Pause(5)

                'Create Read Group
                Me.mobjOPCGroupRead = Me.mobjOPCServer.OPCGroups.Add("CEOLTG_Read")
                With Me.mobjOPCGroupRead
                    .UpdateRate = Me.OPCPollTime
                    .IsActive = True
                    .IsSubscribed = True
                    .DeadBand = 0

                    mobjOPCItem_ToGauge_BornDateYear = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornDateYear, 1)
                    mobjOPCItem_ToGauge_BornDateMonth = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornDateMonth, 2)
                    mobjOPCItem_ToGauge_BornDateDay = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornDateDay, 3)
                    mobjOPCItem_ToGauge_BornTimeHour = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornTimeHour, 4)
                    mobjOPCItem_ToGauge_BornTimeMinute = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornTimeMinute, 5)
                    mobjOPCItem_ToGauge_BornTimeSecond = .OPCItems.AddItem(Me.OPCItem_ToGauge_BornTimeSecond, 6)
                    mobjOPCItem_ToGauge_UID = .OPCItems.AddItem(Me.OPCItem_ToGauge_UID, 7)
                End With

                'Create Write Group
                Me.mobjOPCGroupWrite = Me.mobjOPCServer.OPCGroups.Add("CEOLTG_Write")
                With Me.mobjOPCGroupWrite
                    .IsActive = True
                    .IsSubscribed = True

                    mobjOPCItem_FromGauge_UID = .OPCItems.AddItem(Me.OPCItem_FromGauge_UID, 1)
                    mobjOPCItem_FromGauge_DataReceived = .OPCItems.AddItem(Me.OPCItem_FromGauge_DataReceived, 2)
                    mobjOPCItem_FromGauge_Defects1 = .OPCItems.AddItem(Me.OPCItem_FromGauge_Defects1, 3)
                    mobjOPCItem_FromGauge_InspectionValid = .OPCItems.AddItem(Me.OPCItem_FromGauge_InspectionValid, 4)
                    mobjOPCItem_WriteHeartbeat = .OPCItems.AddItem(Me.OPCItem_WriteHeartbeat, 5)
                    Dim iNextItem As Integer = 6

                    If (OPCSheetWidthEnabled) Then
                        mobjOPCItem_FromGauge_MeasuredWidth = .OPCItems.AddItem(Me.OPCItem_FromGauge_MeasuredWidth, iNextItem)
                        iNextItem += 1
                    End If

                    If (OPCSensorIdxRefEnabled) Then
                        mobjOPCItem_FromGauge_PrecitecIOR = .OPCItems.AddItem(Me.OPCItem_FromGauge_SensorIdxRef, iNextItem)
                        iNextItem += 1
                    End If


                    If (PostMeasurementOPCActive) Then
                        mobjOPCItem_FromGauge_Max = .OPCItems.AddItem(Me.OPCItem_FromGauge_Max, iNextItem)
                        iNextItem += 1
                        mobjOPCItem_FromGauge_Min = .OPCItems.AddItem(Me.OPCItem_FromGauge_Min, iNextItem)
                        iNextItem += 1
                        mobjOPCItem_FromGauge_Average = .OPCItems.AddItem(Me.OPCItem_FromGauge_Average, iNextItem)
                        iNextItem += 1
                        mobjOPCItem_FromGauge_75mmMWR = .OPCItems.AddItem(Me.OPCItem_FromGauge_75mmMWR, iNextItem)
                    End If
                End With
            End If


        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Sub Disconnect()
        Try
            'Disconnect
            If Not Me.mobjOPCServer Is Nothing Then
                For Each objGroup As OPCGroup In Me.mobjOPCServer.OPCGroups
                    objGroup.IsActive = False
                    objGroup.IsSubscribed = False
                Next
                Me.mobjOPCServer.OPCGroups.RemoveAll()
                Me.mobjOPCGroupRead = Nothing
                Me.mobjOPCGroupWrite = Nothing
                Me.mobjOPCServer = Nothing
            End If

        Catch ex As Exception
            If gLog IsNot Nothing Then
                gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
            End If
        End Try
    End Sub
    Private ReadOnly Property OPCSheetWidthEnabled As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(Me.OPCItem_FromGauge_MeasuredWidth)
        End Get
    End Property

    Private ReadOnly Property OPCSensorIdxRefEnabled As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(Me.OPCItem_FromGauge_SensorIdxRef)
        End Get
    End Property


    Private Sub mobjOPCGroupRead_DataChange(ByVal TransactionID As Integer,
                                            ByVal NumItems As Integer,
                                            ByRef ClientHandles As System.Array,
                                            ByRef ItemValues As System.Array,
                                            ByRef Qualities As System.Array,
                                            ByRef TimeStamps As System.Array) Handles mobjOPCGroupRead.DataChange
        Try
            Dim bNewDate As Boolean = False

            For intIndex As Integer = 1 To NumItems
                Dim Q As Integer = Qualities.GetValue(intIndex)
                Dim V As Object = ItemValues.GetValue(intIndex)
                Select Case Qualities(intIndex)
                    Case OPCQuality.OPCQualityGood
                        Select Case ClientHandles(intIndex)
                            Case 1
                                Me.BornDateYearVal = V
                                bNewDate = True
                            Case 2
                                Me.BornDateMonthVal = V
                                bNewDate = True
                            Case 3
                                Me.BornDateDayVal = V
                                bNewDate = True
                            Case 4
                                Me.BornTimeHourVal = V
                                bNewDate = True
                            Case 5
                                Me.BornTimeMinuteVal = V
                                bNewDate = True
                            Case 6
                                Me.BornTimeSecondVal = V
                                bNewDate = True
                            Case 7
                                Me.UID = V
                        End Select
                    Case OPCQuality.OPCQualityBad
                        gLog.LogErr("Item " & ClientHandles(intIndex).ToString & " error reading data from the server (quality bad).")
                    Case OPCQuality.OPCQualityUncertain
                        gLog.LogErr("Item " & ClientHandles(intIndex).ToString & " error reading data from the server (quality uncertain).")
                    Case Else
                        gLog.LogErr("Item " & ClientHandles(intIndex).ToString & " error reading data from the server (" & CType(Q, OPCQualityStatus).ToString & ").")
                End Select
            Next intIndex

            If bNewDate Then
                Try
                    BornDT = New DateTime(BornDateYearVal, BornDateMonthVal, BornDateDayVal, BornTimeHourVal, BornTimeMinuteVal, BornTimeSecondVal)
                    gLog.LogDebug(9, "NewDate:" & BornDT.ToString())
                Catch ex As Exception
                    gLog.LogErr(String.Format("{0}.{1}(), Error Converting Date, Year={2}, Month={3}, Day={4}, Hour={5}, Minute={6}, Second={7}",
                                              Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, BornDateYearVal, BornDateMonthVal,
                                              BornDateDayVal, BornTimeHourVal, BornTimeMinuteVal, BornTimeSecondVal))
                End Try
            End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub mobjOPCServer_ServerShutDown(ByVal Reason As String) Handles mobjOPCServer.ServerShutDown
        Try
            gLog.LogErr("OPCServer Shutdown, Trying to Reconnect...")
            Me.Connect()

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Sub SendResultsToPLC(ByVal oInfo As clsData_Info, oLTG As clsData_LTG)
        Try
            'Dim intNumItems As Integer = 4
            'Dim intServerHandles(intNumItems) As Integer
            'Dim intErrors(intNumItems) As Integer
            'Dim objValues(intNumItems) As Object
            'Dim intTransactionID As Integer = 1
            'Dim intCancelID As Integer = 0

            If Me.OPCServerName.Length > 0 Then
                'Set Server Handle and value
                'intServerHandles(1) = Me.mobjOPCItem_FromGauge_UID.ServerHandle
                'objValues(1) = oInfo.UID
                SetSingleOPCValue(Me.mobjOPCItem_FromGauge_UID, oInfo.UID)

                'intServerHandles(2) = Me.mobjOPCItem_FromGauge_DataReceived.ServerHandle
                'objValues(2) = True
                SetSingleOPCValue(Me.mobjOPCItem_FromGauge_DataReceived, 1)

                'intServerHandles(3) = Me.mobjOPCItem_FromGauge_Defects1.ServerHandle
                'If Defect Results is 0 = OK, else NG
                'objValues(3) = If(oInfo.Reason = 0, False, True)
                'SetSingleOPCValue(Me.mobjOPCItem_FromGauge_Defects1, If(oInfo.Reason = 0, 0, 1)) 'v1.1.25, dont drop if DropIfReject is FALSE
                SetSingleOPCValue(Me.mobjOPCItem_FromGauge_Defects1, If(oInfo.Reason = 0 OrElse gConfig.DropIfReject = False, 0, 1))

                'intServerHandles(4) = Me.mobjOPCItem_FromGauge_InspectionValid.ServerHandle
                'Inspection valid if Bad Points SP not exceeded
                'objValues(4) = If(oLTG.Passed, True, False)
                SetSingleOPCValue(Me.mobjOPCItem_FromGauge_InspectionValid, If(oLTG.Passed, 1, 0))


                If (OPCSheetWidthEnabled) Then
                    SetSingleOPCValue(Me.mobjOPCItem_FromGauge_MeasuredWidth, oLTG.SizeWidth_Measured)

                End If

                If (OPCSensorIdxRefEnabled) Then
                    SetSingleOPCValue(Me.mobjOPCItem_FromGauge_PrecitecIOR, oLTG.SensorIdxRef)
                End If

                If (PostMeasurementOPCActive) Then
                    SetSingleOPCValue(Me.mobjOPCItem_FromGauge_Max, oLTG.QAThicknessMax)
                    SetSingleOPCValue(Me.mobjOPCItem_FromGauge_Min, oLTG.QAThicknessMin)
                    SetSingleOPCValue(Me.mobjOPCItem_FromGauge_Average, oLTG.QAThicknessAvg)
                    For Each oMWR As clsSpec_MWR In oLTG.QAMWR
                        If oMWR.WindowSize = 75 Then
                            SetSingleOPCValue(Me.mobjOPCItem_FromGauge_75mmMWR, oMWR.CalcMWR * 1000)
                            Exit For
                        End If
                    Next
                End If

                'send Write command
                gLog.LogDebug(9, String.Format("Send Results To PLC:  UID={0}, DataReceived={1}, Defects={2}, InspectionValid={3}", oInfo.UID, 1, oInfo.Reason, oLTG.Passed))
                    'Me.mobjOPCGroupWrite.AsyncWrite(intNumItems, intServerHandles, objValues, intErrors, intTransactionID, intCancelID)
                End If

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name & "SendResultsToPLC" & ex.Message)
            'gLog.LogMsg(Me.GetType.Name & "SendResultsToPLC" & ex.Message)
        End Try

    End Sub

    Private _blnHeartBeatValue As Boolean = False

    Public Sub ToggleOPCHeartBeat()
        Try
            _blnHeartBeatValue = Not _blnHeartBeatValue
            If Not IsNothing(Me.mobjOPCItem_WriteHeartbeat) And Me.OPCItem_WriteHeartbeat.Length > 0 Then
                'gLog.LogDebug(9, "Heartbeat written, value=" & _blnHeartBeatValue.ToString())
                SetSingleOPCValue(Me.mobjOPCItem_WriteHeartbeat, CBool(_blnHeartBeatValue))
            Else
                'gLog.LogDebug(9, "Heartbeat NOT written, OPCItem_WriteHeartbeat=" & Me.OPCItem_WriteHeartbeat)
            End If
        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "ToggleOPCHeartBeat", ex)
        End Try

    End Sub


    Private _iTransactionID As Integer = 0
    Private Sub SetSingleOPCValue(ByVal writeOPCItem As OPCItem, ByVal value As Object)
        Try
            Dim intNumItems As Integer = 1
            Dim intServerHandles(intNumItems) As Integer
            Dim intErrors(intNumItems) As Integer
            Dim objValues(intNumItems) As Object
            Dim intCancelID As Integer = 0

            ReDim intServerHandles(intNumItems)
            ReDim objValues(intNumItems)
            ReDim intErrors(intNumItems)

            'Increment Transaction ID
            Me._iTransactionID += 1
            If Me._iTransactionID > 32767 Then Me._iTransactionID = 1

            'Set Server Handle and value
            intServerHandles(1) = writeOPCItem.ServerHandle
            objValues(1) = value

            'send Write command
            Dim arrServerHandles As System.Array = intServerHandles
            Dim arrErrors As System.Array = intErrors
            Dim arrValues As System.Array = objValues
            Me.mobjOPCGroupWrite.AsyncWrite(intNumItems, arrServerHandles, arrValues, arrErrors, Me._iTransactionID, intCancelID)

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name, "SetSingleOPCValue", ex)
        End Try
    End Sub
End Class
