Option Strict Off
Option Explicit On

Imports System.IO
Friend Class clsLogger
	'***************************************************************
	'
	'Class:         clsLogger
	'
	'Description:   This class performs the standard logging funcitons.
	'               It can be used for either operator information or
	'               debugging purposes.
	'
	'               Status contains the last LogMsg. This can be used
	'               on operator displays.
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
    '11/19/02   fjm         Created
    '2009-05-27 fjm         Added Debug Levels
    '2009-09-30 fjm         Added ShowLastLogFile
    '2010-02-25 fjm         Added ability to handle multiple threads
    '2010-04-07 fjm         Use separate thread to write collection to file
    '
	'***************************************************************
	
	'********************** Constants ******************************
	Private Const cFileExtension As String = ".txt"
	Private Const cFilePrefix As String = "Log_"
	
    '************************** Publics ****************************
    Public DebugLevel As Integer = 0
    Public LastLogFile As String = ""
    Public ThreadExit As Boolean = False

    '************************** Locals *****************************
    Private mvarPath As String = ""
    Private mvarStatus As String = ""
    Private mvarLogDuration As Integer = 30
    Private mvarLastPurge As New Date(0)
    Private mcolEntries As New Collection

    Private mWriteToLogFile_Thread As Threading.Thread = Nothing

    'Object used as a lock for locking the mcolEntries collection
    Private logCollLock As Object = New Object()
    '***************************************************************
    Public Sub New()
        MyBase.New()
        Try
            'Initialize Properties
            mvarLogDuration = 30 'Days

            'Define(Path)
            If InStr(UCase(Microsoft.VisualBasic.Command()), "DEBUG") Then
                mvarPath = cDebugPath
            Else
                mvarPath = My.Application.Info.DirectoryPath
            End If
            mvarPath = FormatPath(mvarPath) & cPathLog

            'Create Directory
            CreateDirectory(mvarPath)

            'Create Log File Thread
            Me.mWriteToLogFile_Thread = New Threading.Thread(AddressOf WriteToLogFile_Thread)
            Me.mWriteToLogFile_Thread.Start()
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            'Wait for Thread to exit
            ThreadExit = True
            mWriteToLogFile_Thread.Join()

            'One Lsat Flush before exiting
            Me.FlushBufferToLog()
        Catch ex As Exception
        End Try

        MyBase.Finalize()
    End Sub

    Public Sub ShowLastLogFile()
        Try
            Shell("Notepad " & Me.LastLogFile, AppWinStyle.MaximizedFocus)
        Catch ex As Exception

        End Try
    End Sub

    '***************************************************************
    Public Sub LogMsg(ByVal strMessage As String)
        Try
            'Save Message for Status
            Me.Status = strMessage
            'Lock when adding entries
            SyncLock (logCollLock)
                'Add to Collection
                Me.mcolEntries.Add(Now.ToString("MM/dd/yy HH:mm:ss.fff") & " " & strMessage)
            End SyncLock

        Catch ex As Exception
        End Try
    End Sub

    Private Sub WriteToLogFile_Thread()
        Try
            gLog.LogDebug(10, "WriteToLogFile_Thread() Started")

            'While Not Exit Run
            While Not Me.ThreadExit
                Try
                    Me.FlushBufferToLog()
                Catch ex As Exception
                    gLog.LogDebug(10, "WriteToLogFile_Thread(), Error: " & ex.Message.ToString)
                End Try

                'Sleep
                Threading.Thread.Sleep(100)
            End While
            If gLog IsNot Nothing Then
                gLog.LogDebug(10, "WriteToLogFile_Thread() Ending")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub FlushBufferToLog()
        Try
            'Write entries when gauge is idle, fjm, 2010-08-27
            If Me.mcolEntries.Count > 0 Then 'And gState = enumGaugeState.gsIdle Then
                'Define Filename
                Me.LastLogFile = mvarPath & cFilePrefix & Now.ToString("yyyyMMdd") & cFileExtension

                'Write to File
                Using w As StreamWriter = File.AppendText(Me.LastLogFile)
                    'Step through collection
                    While Me.mcolEntries.Count > 0
                        Dim strMessage As String = Me.mcolEntries(1)

                        'Write Line
                        w.WriteLine(strMessage)
                        'lock when removing entries
                        SyncLock (logCollLock)
                            'Remove Item from Collection
                            Me.mcolEntries.Remove(1)
                        End SyncLock
                    End While

                    'Flush and Close File
                    w.Flush()
                    w.Close()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

	'***************************************************************
	'This subroutine purges the old log files
    Public Sub Purge()
        Try
            Dim strFile As String
            Dim dtFile As Date

            'Only Purge once every 24 hours
            If Now.Subtract(Me.LastPurge).TotalHours >= 24 Then
                Me.LastPurge = Today 'Only save the date

                'Step through log files, purging old
                strFile = Dir(mvarPath & cFilePrefix & "*" & cFileExtension)
                While strFile <> ""
                    'Get file date
                    dtFile = FileDateTime(mvarPath & strFile)

                    'if file is old then LogDuration, then delete
                    If Now.Subtract(dtFile) > New TimeSpan(Me.LogDuration, 0, 0, 0) Then
                        Kill(mvarPath & strFile)
                    End If

                    'Get next file
                    strFile = Dir()
                End While
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LogAlarm(ByVal strMsg As String)
        Try
            Me.LogMsg("ALARM: " & strMsg)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LogDebug(ByVal intLevel As Integer, ByVal strMsg As String)
        Try
            If intLevel <= Me.DebugLevel Then
                Me.LogMsg("DEBUG" & intLevel.ToString & ": " & strMsg)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LogErr(ByVal strMsg As String)
        Try
            Me.LogMsg("ERROR: " & strMsg)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LogErr(ByVal strModule As String, ByVal strFunction As String, ByVal exException As Exception, ByVal ParamArray Parameters() As String)
        Dim strMsg As String
        Dim intIndex As Integer

        Try
            strMsg = strModule & "." & strFunction & "("

            For intIndex = 0 To Parameters.GetUpperBound(0)
                If intIndex > 0 Then strMsg &= ", "

                strMsg &= Parameters(intIndex).ToString
            Next

            strMsg &= "), ERROR: " & exException.ToString


            Me.LogErr(strMsg)
        Catch ex As Exception
        End Try
    End Sub

    '***************************************************************
    Public Property Status() As String
        Get
            Status = mvarStatus
        End Get
        Set(ByVal Value As String)
            mvarStatus = Value
        End Set
    End Property

    '***************************************************************
    Public Property LogDuration() As Integer
        Get
            LogDuration = mvarLogDuration
        End Get
        Set(ByVal Value As Integer)
            mvarLogDuration = Value
        End Set
    End Property

    '***************************************************************
    Public Property LastPurge() As Date
        Get
            LastPurge = mvarLastPurge
        End Get
        Set(ByVal Value As Date)
            mvarLastPurge = Value
        End Set
    End Property

End Class