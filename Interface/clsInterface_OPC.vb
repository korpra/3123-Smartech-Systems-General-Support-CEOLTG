Imports System.Data.SqlClient
Imports OPCAutomation

Public Class clsInterface_OPC
    '***************************************************************
    '
    'Class:         clsInterface_PLC....  was originally called clsRSLinx
    '
    'Description:   This class contains the generic Interface for OPC.
    '
    'Created by:    Smartech Systems, Inc.
    '               112 Fairgrounds Drive
    '               Manlius, NY 13104
    '               www.smartechsys.com
    '               Phone:  315-682-0004
    '               Fax:    315-682-0005
    '
    '
    '
    'Modifications:
    'Date       Initials    Description
    '03/26/07   dfs         Created
    '2011-07-15 mjc         Converted from original clsRSLinx to the generic clsInterface_OPC
    '                       Commented out unused code
    '***************************************************************

    '*************************** Constancts ************************
    'Const cMaxRSItemCount As Integer = 6    'Number of defined RSLinx items
    'Const cRSTimeout As Long = 5000         'Timeout in milliseconds
    'Const cOPC_DS_DEVICE As Long = 2


    '*************************** Publics ***************************
    Public IsConnected As Boolean = False

    '*************************** Privates ***************************
    Private WithEvents mobjOPCServer As OPCServer
    Private WithEvents mobjOPCGroupWrite As OPCGroup
    Private WithEvents mobjOPCGroupRead As OPCGroup
    '2011-07-15 
    'OPC server name...  defaults to the original hard coded value
    'take from config
    Public OPCServerName As String = ""
    Public PollTime As Integer


    '***************************************************************
    Friend Sub Initialize(ByVal opcGroups As OPCAutomation.OPCGroups)
        'Create Read Group
        Me.mobjOPCGroupRead = opcGroups.Add(String.Format("SOLTG_Read"))
        With Me.mobjOPCGroupRead
            'add in config
            .UpdateRate = gConfig.PollTime
            .IsActive = True
            .IsSubscribed = True
            .DeadBand = 0

            'create config items - to add - itemids
            .OPCItems.AddItem(, 1)
            .OPCItems.AddItem(OPCItem_HopWt, 2)
            .OPCItems.AddItem(OPCItem_HopperLotNumber, 3)
            .OPCItems.AddItem(OPCItem_HopperStockNumber, 4)
            .OPCItems.AddItem(OPCItem_OpenLotNumber, 5)
            .OPCItems.AddItem(OPCItem_OpenStockNumber, 6)
        End With

        'Create Write Group
        Me.mobjOPCGroupWrite = opcGroups.Add(String.Format("CC{0}_Cullet_Write", Me.Index))
        With Me.mobjOPCGroupWrite
            .IsActive = False
            .IsSubscribed = True

            Me.mobjOPCItem_HopperDone = .OPCItems.AddItem(OPCItem_HopperDone, 1)
            Me.mobjOPCItem_HopperStockNumber = .OPCItems.AddItem(OPCItem_HopperStockNumber, 2)
            Me.mobjOPCItem_HopperLotNumber = .OPCItems.AddItem(OPCItem_HopperLotNumber, 3)
            Me.mobjOPCItem_HopperWeight = .OPCItems.AddItem(OPCItem_HopWt, 4)
        End With
    End Sub
    Public Sub New()

        Try

        Catch ex As Exception

        End Try
    End Sub

    '*************************************************************************************
    Protected Overrides Sub Finalize()

        Try
            Me.Disconnect()
        Catch ex As Exception

        End Try
        MyBase.Finalize()

    End Sub


    Public Sub ConnectServer()

        Try
            If Me.OPCServerName.Length > 0 Then
                'Disconnect if already defined
                If Not Me.mobjOPCServer Is Nothing Then
                    Me.Disconnect()
                End If

                'Connect to Server
                Me.mobjOPCServer = New OPCServer
                Me.mobjOPCServer.Connect(Me.OPCServerName)

                'Create Write Group
                Me.mobjOPCGroupWrite = Me.mobjOPCServer.OPCGroups.Add("MaryBandFetcherUtil")
                With Me.mobjOPCGroupWrite
                    .IsActive = False
                    .IsSubscribed = True

                End With
            End If

            Me.IsConnected = True
            gLog.LogMsg("OPC Initialization Successful!")

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name & ".Connect, Error: " + Err.Description)
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
                Me.mobjOPCGroupWrite = Nothing
                Me.mobjOPCServer = Nothing
            End If

        Catch ex As Exception
            gLog.LogErr(String.Format("{0}.Disconnect, Error: {1}", Me.GetType.Name, ex))
        End Try
    End Sub


    Public Function ToolWrite(ByVal drDataRow As DataRow) As Boolean
        Dim blnReturn As Boolean = False

        Try
            'First Add OPC Item to Group
            Dim objOPCItem As OPCItem = Me.AddOPCItem()
            If Not objOPCItem Is Nothing Then
                'Write Value
                If gblnDebug Then
                    If Me.WriteOPCItem(objOPCItem, Now.Second.ToString) Then
                        blnReturn = True
                    End If
                ElseIf Me.WriteOPCItem(objOPCItem, drDataRow("PerfBandInteger").ToString) Then
                    blnReturn = True
                    gLog.LogMsg("Write PLC: PerfBandInteger=" & drDataRow("PerfBandInteger").ToString)
                End If
            Else
                gLog.LogErr(Me.GetType.Name & ".ToolWrite(), Unable to create OPC Item: " & drDataRow("PerfBandInteger").ToString)
            End If
            'RSLinxOPCItem

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name & ".ToolWrite(), Error: " + Err.Description)
        End Try

        'Return Status
        Return blnReturn
    End Function


    Private Function AddOPCItem() As OPCItem
        'This function builds up an array of items to be added to the OPCGroup. Each item is
        'assigned a unique client handle for tracking purposes.
        Dim arItemID As String = String.Empty
        Dim arClientHandle As Integer
        Dim objOPCItem As OPCItem = Nothing
        Dim blnFound As Boolean = False

        Try

            'First Check to see if it is already defined
            For Each objOPCItem In Me.mobjOPCGroupWrite.OPCItems
                If objOPCItem.ItemID = Me.OPCItem Then
                    blnFound = True
                    Exit For
                End If
            Next

            'Check if OPC Item already found
            If Not blnFound Then
                'Build up ItemID definitions 
                arItemID = Me.OPCItem.ToString
                arClientHandle = Me.mobjOPCGroupWrite.OPCItems.Count + 1
                gLog.LogMsg("AddOPCItem: arItemID=" & arItemID)

                'Add item to OPCGroup
                objOPCItem = Nothing

                objOPCItem = Me.mobjOPCGroupWrite.OPCItems.AddItem(arItemID, arClientHandle)

            End If

        Catch ex As Exception
            gLog.LogMsg(Me.GetType.Name & ".AddOPCItem()," & arItemID)
            gLog.LogErr(Me.GetType.Name & ".AddOPCItem(), Error: " + ex.Message)
        End Try

        'Return Status
        Return objOPCItem
    End Function

    Private Function WriteOPCItem(ByVal objOPCItem As OPCItem, ByVal strData As String) As Boolean
        Dim blnReturn As Boolean = False

        Try
            
            'Write Data
            objOPCItem.Write(strData)

            'Success
            blnReturn = True

        Catch ex As Exception
            gLog.LogErr(Me.GetType.Name & ".WriteOPCItem(PerfBandInteger=" & strData & "), Error: " + ex.Message)
        End Try

        'Return Status
        Return blnReturn
    End Function

    'Private Function WriteOPCItem(ByVal objOPCItem As OPCItem, ByVal strData As String) As Boolean
    '    Dim blnReturn As Boolean = False
    '    Dim intNumItems As Integer
    '    Dim intServerHandles() As Integer
    '    Dim intErrors() As Integer
    '    Dim objValues() As Object

    '    intNumItems = 1
    '    ReDim intServerHandles(intNumItems)
    '    ReDim objValues(intNumItems)
    '    ReDim intServerHandles(intNumItems)
    '    ReDim intErrors(intNumItems)

    '    intServerHandles(1) = objOPCItem.ServerHandle
    '    objValues(1) = Integer.Parse(strData)


    '    Dim intTransactionID As Integer = 1
    '    Dim intCancelID As Integer = 0

    '    'Dim err As System.Array = System.Array.CreateInstance(GetType(Integer), 1)
    '    'err(0) = 0
    '    'Dim h As System.Array = System.Array.CreateInstance(GetType(Object), 1)
    '    'h(0) = objOPCItem.ServerHandle

    '    'Dim values As System.Array = System.Array.CreateInstance(GetType(Object), 1)
    '    'values(0) = strData 'Integer.Parse(strData)

    '    Try

    '        Me.mobjOPCGroupWrite.AsyncWrite(intNumItems, DirectCast(intServerHandles, Array), DirectCast(objValues, Array), DirectCast(intErrors, Array), intTransactionID, intCancelID)

    '        ' objOPCItem.Parent.SyncWrite(intNumItems, DirectCast(intServerHandles, Array), DirectCast(objValues, Array), DirectCast(intErrors, Array))
    '        ' objOPCItem.Parent.SyncRead(2, 1, h, values, err)

    '        'Write Data
    '        'objOPCItem.Write(strData)

    '        'Success
    '        blnReturn = True

    '    Catch ex As Exception
    '        gLog.LogErr(Me.GetType.Name & ".WriteOPCItem(PerfBandInteger=" & strData & "), Error: " + ex.Message)
    '    End Try

    '    'Return Status
    '    Return blnReturn
    'End Function

    'Private Sub DisplayErrorString(ByVal lError As Long)
    '    Dim sText As String

    '    Try
    '        sText = Me.mobjOPCServer.GetErrorString(lError)
    '        If InStr(sText, vbCrLf) Then
    '            'strip off crlf at end of string
    '            sText = Left$(sText, Len(sText) - 2)
    '        End If
    '        gLog.LogErr(Me.GetType.Name & ", OPC Error: " & sText)

    '    Catch ex As Exception
    '        gLog.LogErr(Me.GetType.Name & ".DisplayErrorString(), Error: " + Err.Description)
    '    End Try
    'End Sub

End Class

