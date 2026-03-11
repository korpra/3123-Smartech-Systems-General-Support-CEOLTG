Imports System.Runtime.InteropServices

Module mdlKeyence_CL3000

    Public NotInheritable Class PinnedObject
        Implements IDisposable
        Private _Handle As GCHandle

        Public ReadOnly Property Pointer() As IntPtr
            Get
                Return _Handle.AddrOfPinnedObject()
            End Get
        End Property

        Public Sub New(target As Object)
            _Handle = GCHandle.Alloc(target, GCHandleType.Pinned)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            _Handle.Free()
            _Handle = New GCHandle()
        End Sub
    End Class

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_VERSION_INFO
        Public majorNumber As Integer
        Public minorNumber As Integer
        Public revisionNumber As Integer
        Public buildNumber As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_ETHERNET_SETTING
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=4)>
        Public ipAddress As Byte()
        Public portNo As UShort
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)>
        Public reserved As Byte()
    End Structure

    Public Enum CL3IF_DEVICETYPE
        CL3IF_DEVICETYPE_INVALID = &H0
        CL3IF_DEVICETYPE_CONTROLLER = &H1
        CL3IF_DEVICETYPE_OPTICALUNIT1 = &H11
        CL3IF_DEVICETYPE_OPTICALUNIT2 = &H12
        CL3IF_DEVICETYPE_OPTICALUNIT3 = &H13
        CL3IF_DEVICETYPE_OPTICALUNIT4 = &H14
        CL3IF_DEVICETYPE_OPTICALUNIT5 = &H15
        CL3IF_DEVICETYPE_OPTICALUNIT6 = &H16
        CL3IF_DEVICETYPE_EXUNIT1 = &H41
        ' Extensional Unit 1
        CL3IF_DEVICETYPE_EXUNIT2 = &H42
        ' Extensional Unit 2
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_ADD_INFO
        Public triggerCount As UInteger
        Public pulseCount As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_OUTMEASUREMENT_DATA
        Public measurementValue As Integer
        Public valueInfo As Byte
        Public judgeResult As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)>
        Public reserved As Byte()

    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_MEASUREMENT_DATA
        Public addInfo As CL3IF_ADD_INFO
        Public outMeasurementData As CL3IF_OUTMEASUREMENT_DATA()
    End Structure

    Public Enum CL3IF_VALUE_INFO
        CL3IF_VALUE_INFO_VALID
        CL3IF_VALUE_INFO_JUDGMENTSTANDBY
        CL3IF_VALUE_INFO_INVALID
        CL3IF_VALUE_INFO_OVERDISPRANGE_P
        CL3IF_VALUE_INFO_OVERDISPRANGE_N
    End Enum

    <Flags>
    Public Enum CL3IF_JUDGE_RESULT
        CL3IF_JUDGE_RESULT_HI = &H1
        CL3IF_JUDGE_RESULT_GO = &H2
        CL3IF_JUDGE_RESULT_LO = &H4
    End Enum

    <Flags>
    Public Enum CL3IF_OUTNO
        CL3IF_OUTNO_01 = &H1
        ' OUT1
        CL3IF_OUTNO_02 = &H2
        ' OUT2
        CL3IF_OUTNO_03 = &H4
        ' OUT3
        CL3IF_OUTNO_04 = &H8
        ' OUT4
        CL3IF_OUTNO_05 = &H10
        ' OUT5
        CL3IF_OUTNO_06 = &H20
        ' OUT6
        CL3IF_OUTNO_07 = &H40
        ' OUT7
        CL3IF_OUTNO_08 = &H80
        ' OUT8
        CL3IF_OUTNO_ALL = &HFF
        ' ALL
    End Enum

    Public Enum CL3IF_SELECTED_INDEX
        CL3IF_SELECTED_INDEX_OLDEST
        CL3IF_SELECTED_INDEX_NEWEST
    End Enum

    <Flags>
    Public Enum CL3IF_ZERO_GROUP
        CL3IF_ZERO_GROUP_01 = &H1
        ' Group01
        CL3IF_ZERO_GROUP_02 = &H2
        ' Group02
    End Enum

    <Flags>
    Public Enum CL3IF_TIMING_GROUP
        CL3IF_TIMING_GROUP_01 = &H1
        ' Group01
        CL3IF_TIMING_GROUP_02 = &H2
        ' Group02
    End Enum

    <Flags>
    Public Enum CL3IF_RESET_GROUP
        CL3IF_RESET_GROUP_01 = &H1
        ' Group01
        CL3IF_RESET_GROUP_02 = &H2
        ' Group02
    End Enum

    <Flags>
    Public Enum CL3IF_PEAKNO
        CL3IF_PEAKNO_01 = &H1
        CL3IF_PEAKNO_02 = &H2
        CL3IF_PEAKNO_03 = &H4
        CL3IF_PEAKNO_04 = &H8
    End Enum

    Public Enum CL3IF_SAMPLINGCYCLE
        CL3IF_SAMPLINGCYCLE_100USEC
        CL3IF_SAMPLINGCYCLE_200USEC
        CL3IF_SAMPLINGCYCLE_500USEC
        CL3IF_SAMPLINGCYCLE_1000USEC
    End Enum

    Public Enum CL3IF_MEDIANFILTER
        CL3IF_MEDIANFILTER_OFF
        ' OFF
        CL3IF_MEDIANFILTER_7
        ' 7
        CL3IF_MEDIANFILTER_15
        ' 15
        CL3IF_MEDIANFILTER_31
        ' 31
    End Enum

    Public Enum CL3IF_MODE
        CL3IF_MODE_AUTO
        'AUTO
        CL3IF_MODE_MANUAL
        'MANUAL
    End Enum

    Public Enum CL3IF_INTENSITY
        CL3IF_INTENSITY_1
        ' 1
        CL3IF_INTENSITY_2
        ' 2
        CL3IF_INTENSITY_3
        ' 3
        CL3IF_INTENSITY_4
        ' 4
        CL3IF_INTENSITY_5
        ' 5
    End Enum

    Public Enum CL3IF_INTEGRATION_NUMBER
        CL3IF_INTEGRATION_NUMBER_OFF
        ' OFF
        CL3IF_INTEGRATION_NUMBER_4
        ' 4
        CL3IF_INTEGRATION_NUMBER_16
        ' 16
        CL3IF_INTEGRATION_NUMBER_64
        ' 64
        CL3IF_INTEGRATION_NUMBER_256
        ' 256
    End Enum

    Public Enum CL3IF_QUADPROCESSING
        CL3IF_QUADPROCESSING_AVERAGE
        CL3IF_QUADPROCESSING_MULTIPLE
    End Enum

    Public Enum CL3IF_MATERIAL
        CL3IF_MATERIAL_VACUUM
        CL3IF_MATERIAL_QUARTZ
        CL3IF_MATERIAL_OPTICAL_GLASS
        CL3IF_MATERIAL_ACRYLIC
        CL3IF_MATERIAL_PMMA
        CL3IF_MATERIAL_PMMI
        CL3IF_MATERIAL_PS
        CL3IF_MATERIAL_PC
        CL3IF_MATERIAL_WHITE_FLAT_GLASS
        CL3IF_MATERIAL_RESERVED1
        CL3IF_MATERIAL_RESERVED2
        CL3IF_MATERIAL_RESERVED3
        CL3IF_MATERIAL_RESERVED4
        CL3IF_MATERIAL_RESERVED5
        CL3IF_MATERIAL_RESERVED6
        CL3IF_MATERIAL_RESERVED7
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL1
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL2
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL3
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL4
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL5
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL6
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL7
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL8
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL9
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL10
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL11
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL12
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL13
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL14
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL15
        CL3IF_MATERIAL_ADDITIONAL_MATERIAL16
    End Enum

    Public Enum CL3IF_MEASUREMENTMETHOD
        CL3IF_MEASUREMENTMETHOD_DISPLACEMENT
        CL3IF_MEASUREMENTMETHOD_DISPLACEMENT_FOR_TRANSPARENT
        CL3IF_MEASUREMENTMETHOD_THICKNESS_FOR_TRANSPARENT
        CL3IF_MEASUREMENTMETHOD_THICKNESS_2HEADS
        CL3IF_MEASUREMENTMETHOD_HEIGHTDIFFERENCE_2HEADS
        CL3IF_MEASUREMENTMETHOD_FORMULA
        CL3IF_MEASUREMENTMETHOD_AVERAGE
        CL3IF_MEASUREMENTMETHOD_PEAK_TO_PEAK
        CL3IF_MEASUREMENTMETHOD_MAX
        CL3IF_MEASUREMENTMETHOD_MIN
        CL3IF_MEASUREMENTMETHOD_NO_CALCULATION
    End Enum

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_DISPLACEMENT
        <FieldOffset(0)>
        Public headNo As Byte
        <FieldOffset(1)>
        Public reserved_1 As Byte
        <FieldOffset(2)>
        Public reserved_2 As Byte
        <FieldOffset(3)>
        Public reserved_3 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_DISPLACEMENT_FOR_TRANSPARENT
        <FieldOffset(0)>
        Public headNo As Byte
        <FieldOffset(1)>
        Public reserved1 As Byte
        <FieldOffset(2)>
        Public peak As Byte
        <FieldOffset(3)>
        Public reserved2 As Byte
    End Structure

    Public Enum CL3IF_TRANSPARENTPEAK
        CL3IF_TRANSPARENTPEAK_PLUS1
        ' +1
        CL3IF_TRANSPARENTPEAK_PLUS2
        ' +2
        CL3IF_TRANSPARENTPEAK_PLUS3
        ' +3
        CL3IF_TRANSPARENTPEAK_PLUS4
        ' +4
        CL3IF_TRANSPARENTPEAK_MINUS1
        ' -1
        CL3IF_TRANSPARENTPEAK_MINUS2
        ' -2
        CL3IF_TRANSPARENTPEAK_MINUS3
        ' -3
        CL3IF_TRANSPARENTPEAK_MINUS4
        ' -4
    End Enum

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_THICKNESS_FOR_TRANSPARENT
        <FieldOffset(0)>
        Public headNo As Byte
        <FieldOffset(1)>
        Public reserved As Byte
        <FieldOffset(2)>
        Public peak1 As Byte
        <FieldOffset(3)>
        Public peak2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_THICKNESS_2HEADS
        <FieldOffset(0)>
        Public headNo1 As Byte
        <FieldOffset(1)>
        Public headNo2 As Byte
        <FieldOffset(2)>
        Public reserved_1 As Byte
        <FieldOffset(3)>
        Public reserved_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_HEIGHTDIFFERENCE_2HEADS
        <FieldOffset(0)>
        Public headNo1 As Byte
        <FieldOffset(1)>
        Public headNo2 As Byte
        <FieldOffset(2)>
        Public reserved_1 As Byte
        <FieldOffset(3)>
        Public reserved_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_FORMULA
        <FieldOffset(0)>
        Public factorA As Integer
        <FieldOffset(4)>
        Public factorB As Integer
        <FieldOffset(8)>
        Public factorC As Integer
        <FieldOffset(12)>
        Public targetOutX As Byte
        <FieldOffset(13)>
        Public targetOutY As Byte
        <FieldOffset(14)>
        Public reserved_1 As Byte
        <FieldOffset(15)>
        Public reserved_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_OUT_OPERATION
        <FieldOffset(0)>
        Public targetOut As UShort
        <FieldOffset(2)>
        Public reserved_1 As Byte
        <FieldOffset(3)>
        Public reserved_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM_NO_CALCULATION
        <FieldOffset(0)>
        Public reserved_1 As Byte
        <FieldOffset(1)>
        Public reserved_2 As Byte
        <FieldOffset(2)>
        Public reserved_3 As Byte
        <FieldOffset(3)>
        Public reserved_4 As Byte
    End Structure


    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_MEASUREMENTMETHOD_PARAM
        <FieldOffset(0)>
        Public paramDisplacement As CL3IF_MEASUREMENTMETHOD_PARAM_DISPLACEMENT
        <FieldOffset(0)>
        Public paramDisplacementForTransparent As CL3IF_MEASUREMENTMETHOD_PARAM_DISPLACEMENT_FOR_TRANSPARENT
        <FieldOffset(0)>
        Public paramThicknessForTransparent As CL3IF_MEASUREMENTMETHOD_PARAM_THICKNESS_FOR_TRANSPARENT
        <FieldOffset(0)>
        Public paramThickness2Heads As CL3IF_MEASUREMENTMETHOD_PARAM_THICKNESS_2HEADS
        <FieldOffset(0)>
        Public paramHeightDifference2Heads As CL3IF_MEASUREMENTMETHOD_PARAM_HEIGHTDIFFERENCE_2HEADS
        <FieldOffset(0)>
        Public paramFormula As CL3IF_MEASUREMENTMETHOD_PARAM_FORMULA
        <FieldOffset(0)>
        Public paramOutOperation As CL3IF_MEASUREMENTMETHOD_PARAM_OUT_OPERATION
        <FieldOffset(0)>
        Public paramNoCalculation As CL3IF_MEASUREMENTMETHOD_PARAM_NO_CALCULATION
    End Structure

    Public Enum CL3IF_FILTERMODE
        CL3IF_FILTERMODE_MOVING_AVERAGE
        ' Moving average
        CL3IF_FILTERMODE_LOWPASS
        ' Low pass filter
        CL3IF_FILTERMODE_HIGHPASS
        ' High pass filter
    End Enum

    Public Enum CL3IF_FILTERPARAM_AVERAGE
        CL3IF_FILTERPARAM_AVERAGE_1
        ' 1 time
        CL3IF_FILTERPARAM_AVERAGE_2
        CL3IF_FILTERPARAM_AVERAGE_4
        CL3IF_FILTERPARAM_AVERAGE_8
        CL3IF_FILTERPARAM_AVERAGE_16
        CL3IF_FILTERPARAM_AVERAGE_32
        CL3IF_FILTERPARAM_AVERAGE_64
        CL3IF_FILTERPARAM_AVERAGE_256
        CL3IF_FILTERPARAM_AVERAGE_1024
        CL3IF_FILTERPARAM_AVERAGE_4096
        CL3IF_FILTERPARAM_AVERAGE_16384
        CL3IF_FILTERPARAM_AVERAGE_65536
        CL3IF_FILTERPARAM_AVERAGE_262144
        ' 262144 times
    End Enum

    Public Enum CL3IF_FILTERPARAM_CUTOFF
        CL3IF_FILTERPARAM_CUTOFF_1000
        ' 1000Hz
        CL3IF_FILTERPARAM_CUTOFF_300
        CL3IF_FILTERPARAM_CUTOFF_100
        CL3IF_FILTERPARAM_CUTOFF_30
        CL3IF_FILTERPARAM_CUTOFF_10
        CL3IF_FILTERPARAM_CUTOFF_3
        CL3IF_FILTERPARAM_CUTOFF_1
        CL3IF_FILTERPARAM_CUTOFF_0_3
        CL3IF_FILTERPARAM_CUTOFF_0_1
        ' 0.1Hz
    End Enum

    Public Enum CL3IF_HOLDMODE
        CL3IF_HOLDMODE_NORMAL
        ' Normal
        CL3IF_HOLDMODE_PEAK
        ' Peak hold
        CL3IF_HOLDMODE_BOTTOM
        ' Bottom hold
        CL3IF_HOLDMODE_PEAK_TO_PEAK
        ' Peak to peak hold
        CL3IF_HOLDMODE_SAMPLE
        ' Sample hold
        CL3IF_HOLDMODE_AVERAGE
        ' Average hold
        CL3IF_HOLDMODE_AUTOPEAK
        ' Auto Peak hold
        CL3IF_HOLDMODE_AUTOBOTTOM
        ' Auto bottom hold
    End Enum

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_HOLDMODE_PARAM_NORMAL
        <FieldOffset(0)>
        Public reserved_1 As Byte
        <FieldOffset(1)>
        Public reserved_2 As Byte
        <FieldOffset(2)>
        Public reserved_3 As Byte
        <FieldOffset(3)>
        Public reserved_4 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_HOLDMODE_PARAM_HOLD
        <FieldOffset(0)>
        Public updateCondition As Byte
        <FieldOffset(1)>
        Public reserved As Byte
        <FieldOffset(2)>
        Public numberOfSamplings As UShort
    End Structure

    Public Enum CL3IF_UPDATECONDITION
        CL3IF_UPDATECONDITION_EXTERNAL1
        ' External trigger 1
        CL3IF_UPDATECONDITION_EXTERNAL2
        ' External trigger 2
        CL3IF_UPDATECONDITION_INTERNAL
        ' Internal trigger
    End Enum

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_HOLDMODE_PARAM_AUTOHOLD
        <FieldOffset(0)>
        Public level As Integer
        <FieldOffset(4)>
        Public hysteresis As Integer
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_HOLDMODE_PARAM
        <FieldOffset(0)>
        Public paramNormal As CL3IF_HOLDMODE_PARAM_NORMAL
        <FieldOffset(0)>
        Public paramHold As CL3IF_HOLDMODE_PARAM_HOLD
        <FieldOffset(0)>
        Public paramAutoHold As CL3IF_HOLDMODE_PARAM_AUTOHOLD
    End Structure

    Public Enum CL3IF_DISPLAYUNIT
        CL3IF_DISPLAYUNIT_0_01MM
        ' 0.01mm
        CL3IF_DISPLAYUNIT_0_001MM
        ' 0.001mm
        CL3IF_DISPLAYUNIT_0_0001MM
        ' 0.0001mm
        CL3IF_DISPLAYUNIT_0_00001MM
        ' 0.00001mm
        CL3IF_DISPLAYUNIT_0_1UM
        ' 0.1um
        CL3IF_DISPLAYUNIT_0_01UM
        ' 0.01um
        CL3IF_DISPLAYUNIT_0_001UM
        ' 0.001um
    End Enum

    Public Enum CL3IF_TIMINGRESET
        CL3IF_TIMINGRESET_NONE
        ' None
        CL3IF_TIMINGRESET_1
        ' Timing1/Reset1
        CL3IF_TIMINGRESET_2
        ' Timing2/Reset2
    End Enum

    Public Enum CL3IF_ZERO
        CL3IF_ZERO_NONE
        CL3IF_ZERO_1
        CL3IF_ZERO_2
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CL3IF_JUDGMENT_OUTPUT
        Public logic As Byte
        Public strobe As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)>
        Public reserved1 As Byte()
        Public hi As UShort
        Public go As UShort
        Public lo As UShort
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)>
        Public reserved2 As Byte()
    End Structure

    Public Enum CL3IF_LOGIC
        CL3IF_LOGIC_AND
        CL3IF_LOGIC_OR
    End Enum

    Public Enum CL3IF_STROBE
        CL3IF_STROBE_NO
        CL3IF_STROBE_STROBE1
        CL3IF_STROBE_STROBE2
    End Enum

    Public Enum CL3IF_STORAGETIMING
        CL3IF_STORAGETIMING_MEASUREMENT
        CL3IF_STORAGETIMING_JUDGMENT
    End Enum

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_STORAGETIMING_PARAM_MEASUREMENT
        <FieldOffset(0)>
        Public storageCycle As UShort
        <FieldOffset(2)>
        Public reserved_1 As Byte
        <FieldOffset(3)>
        Public reserved_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_STORAGETIMING_PARAM_JUDGMENT
        <FieldOffset(0)>
        Public logic As Byte
        <FieldOffset(1)>
        Public reserved1_1 As Byte
        <FieldOffset(2)>
        Public reserved1_2 As Byte
        <FieldOffset(3)>
        Public reserved1_3 As Byte
        <FieldOffset(4)>
        Public hi As UShort
        <FieldOffset(6)>
        Public go As UShort
        <FieldOffset(8)>
        Public lo As UShort
        <FieldOffset(10)>
        Public reserved2_1 As Byte
        <FieldOffset(11)>
        Public reserved2_2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure CL3IF_STORAGETIMING_PARAM
        <FieldOffset(0)>
        Public paramMeasurement As CL3IF_STORAGETIMING_PARAM_MEASUREMENT
        <FieldOffset(0)>
        Public paramJudgment As CL3IF_STORAGETIMING_PARAM_JUDGMENT
    End Structure

    Public Class CL3IF
        Public Const CL3IF_RC_OK As Integer = 0
        Public Const CL3IF_RC_ERR_INITIALIZE As Integer = 100
        Public Const CL3IF_RC_ERR_NOT_PARAM As Integer = 101
        Public Const CL3IF_RC_ERR_USB As Integer = 102
        Public Const CL3IF_RC_ERR_ETHERNET As Integer = 103
        Public Const CL3IF_RC_ERR_CONNECT As Integer = 105
        Public Const CL3IF_RC_ERR_TIMEOUT As Integer = 106
        Public Const CL3IF_RC_ERR_CHECKSUM As Integer = 110
        Public Const CL3IF_RC_ERR_LIMIT_CONTROL_ERROR As Integer = 120
        Public Const CL3IF_RC_ERR_UNKNOWN As Integer = 127

        Public Const CL3IF_RC_ERR_STATE_ERROR As Integer = 81
        Public Const CL3IF_RC_ERR_PARAMETER_NUMBER_ERROR As Integer = 82
        Public Const CL3IF_RC_ERR_PARAMETER_RANGE_ERROR As Integer = 83
        Public Const CL3IF_RC_ERR_UNIQUE_ERROR1 As Integer = 84
        Public Const CL3IF_RC_ERR_UNIQUE_ERROR2 As Integer = 85
        Public Const CL3IF_RC_ERR_UNIQUE_ERROR3 As Integer = 86

        Public Const CL3IF_MAX_OUT_COUNT As Integer = 8
        Public Const CL3IF_MAX_HEAD_COUNT As Integer = 6
        Public Const CL3IF_MAX_DEVICE_COUNT As Integer = 3
        Public Const CL3IF_ALL_SETTINGS_DATA_LENGTH As Integer = 16612
        Public Const CL3IF_PROGRAM_SETTINGS_DATA_LENGTH As Integer = 1724
        Public Const CL3IF_LIGHT_WAVE_DATA_LENGTH As Integer = 512
        Public Const CL3IF_MAX_LIGHT_WAVE_COUNT As Integer = 4

        Private Const DllName As String = "CL3_IF.dll"

        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetVersion() As CL3IF_VERSION_INFO
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_OpenUsbCommunication(deviceId As Integer, timeout As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_OpenEthernetCommunication(deviceId As Integer, ByRef ethernetSetting As CL3IF_ETHERNET_SETTING, timeout As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_CloseCommunication(deviceId As Integer) As Integer
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetSystemConfiguration(deviceId As Integer, ByRef deviceCount As Byte, deviceTypeList As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ReturnToFactoryDefaultSetting(deviceId As Integer) As Integer
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMeasurementData(deviceId As Integer, measurementData As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetTrendIndex(deviceId As Integer, ByRef index As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetTrendData(deviceId As Integer, index As UInteger, requestDataCount As UInteger, ByRef nextIndex As UInteger, ByRef obtainedDataCount As UInteger, ByRef outTarget As CL3IF_OUTNO,
        measurementData As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetStorageIndex(deviceId As Integer, selectedIndex As CL3IF_SELECTED_INDEX, ByRef index As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetStorageData(deviceId As Integer, index As UInteger, requestDataCount As UInteger, ByRef nextIndex As UInteger, ByRef obtainedDataCount As UInteger, ByRef outTarget As CL3IF_OUTNO,
        measurementData As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_AutoZeroSingle(deviceId As Integer, outNo As Byte, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_AutoZeroMulti(deviceId As Integer, outNo As CL3IF_OUTNO, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_AutoZeroGroup(deviceId As Integer, group As CL3IF_ZERO_GROUP, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_TimingSingle(deviceId As Integer, outNo As Byte, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_TimingMulti(deviceId As Integer, outNo As CL3IF_OUTNO, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_TimingGroup(deviceId As Integer, group As CL3IF_TIMING_GROUP, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ResetSingle(deviceId As Integer, outNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ResetMulti(deviceId As Integer, outNo As CL3IF_OUTNO) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ResetGroup(deviceId As Integer, group As CL3IF_RESET_GROUP) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_LightControl(deviceId As Integer, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_MeasurementControl(deviceId As Integer, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SwitchProgram(deviceId As Integer, programNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetProgramNo(deviceId As Integer, ByRef programNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_LockPanel(deviceId As Integer, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StartStorage(deviceId As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StopStorage(deviceId As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ClearStorageData(deviceId As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetTerminalStatus(deviceId As Integer, ByRef inputTerminalStatus As UShort, ByRef outputTerminalStatus As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetPulseCount(deviceId As Integer, ByRef pulseCount As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_ResetPulseCount(deviceId As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetLightWaveform(deviceId As Integer, headNo As Byte, peakNo As CL3IF_PEAKNO, waveData As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StartLightIntensityTuning(deviceId As Integer, headNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StopLightIntensityTuning(deviceId As Integer, headNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_CancelLightIntensityTuning(deviceId As Integer, headNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StartCalibration(deviceId As Integer, headNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_StopCalibration(deviceId As Integer, headNo As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_CancelCalibration(deviceId As Integer, headNo As Byte) As Integer
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetSettings(deviceId As Integer, settings As Byte()) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetProgram(deviceId As Integer, programNo As Byte, program As Byte()) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetSamplingCycle(deviceId As Integer, programNo As Byte, samplingCycle As CL3IF_SAMPLINGCYCLE) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMutualInterferencePrevention(deviceId As Integer, programNo As Byte, onOff As Boolean, group As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetAmbientLightFilter(deviceId As Integer, programNo As Byte, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMedianFilter(deviceId As Integer, programNo As Byte, headNo As Byte, medianFilter As CL3IF_MEDIANFILTER) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetThreshold(deviceId As Integer, programNo As Byte, headNo As Byte, mode As CL3IF_MODE, value As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMask(deviceId As Integer, programNo As Byte, headNo As Byte, onOff As Boolean, position1 As Integer, position2 As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetLightIntensityControl(deviceId As Integer, programNo As Byte, headNo As Byte, mode As CL3IF_MODE, upperLimit As Byte, lowerLimit As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetPeakShapeFilter(deviceId As Integer, programNo As Byte, headNo As Byte, onOff As Boolean, intensity As CL3IF_INTENSITY) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetLightIntensityIntegration(deviceId As Integer, programNo As Byte, headNo As Byte, integrationNumber As CL3IF_INTEGRATION_NUMBER) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetQuadProcessing(deviceId As Integer, programNo As Byte, headNo As Byte, processing As CL3IF_QUADPROCESSING, quadValidPoint As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMeasurementPeaks(deviceId As Integer, programNo As Byte, headNo As Byte, peaks As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetCheckingNumberOfPeaks(deviceId As Integer, programNo As Byte, headNo As Byte, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMultiLightIntensityControl(deviceId As Integer, programNo As Byte, headNo As Byte, onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetRefractiveIndexCorrection(deviceId As Integer, programNo As Byte, headNo As Byte, onOff As Boolean, layer1 As CL3IF_MATERIAL, layer2 As CL3IF_MATERIAL,
        layer3 As CL3IF_MATERIAL) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetMeasurementMethod(deviceId As Integer, programNo As Byte, outNo As Byte, method As CL3IF_MEASUREMENTMETHOD, param As CL3IF_MEASUREMENTMETHOD_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetScaling(deviceId As Integer, programNo As Byte, outNo As Byte, inputValue1 As Integer, outputValue1 As Integer, inputValue2 As Integer,
        outputValue2 As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetOffset(deviceId As Integer, programNo As Byte, outNo As Byte, offset As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetTolerance(deviceId As Integer, programNo As Byte, outNo As Byte, upperLimit As Integer, lowerLimit As Integer, hysteresis As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetFilter(deviceId As Integer, programNo As Byte, outNo As Byte, filterMode As CL3IF_FILTERMODE, filterParam As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetHold(deviceId As Integer, programNo As Byte, outNo As Byte, holdMode As CL3IF_HOLDMODE, param As CL3IF_HOLDMODE_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetInvalidDataProcessing(deviceId As Integer, programNo As Byte, outNo As Byte, invalidationNumber As UShort, recoveryNumber As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetDisplayUnit(deviceId As Integer, programNo As Byte, outNo As Byte, displayUnit As CL3IF_DISPLAYUNIT) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetTerminalAllocation(deviceId As Integer, programNo As Byte, outNo As Byte, timingReset As CL3IF_TIMINGRESET, zero As CL3IF_ZERO) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetJudgmentOutput(deviceId As Integer, programNo As Byte, judgmentOutput As CL3IF_JUDGMENT_OUTPUT()) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetStorageNumber(deviceId As Integer, programNo As Byte, overwrite As Byte, storageNumber As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetStorageTiming(deviceId As Integer, programNo As Byte, storageTiming As Byte, param As CL3IF_STORAGETIMING_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_SetStorageTarget(deviceId As Integer, programNo As Byte, outNo As CL3IF_OUTNO) As Integer
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetSettings(deviceId As Integer, settings As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetProgram(deviceId As Integer, programNo As Byte, program As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetSamplingCycle(deviceId As Integer, programNo As Byte, ByRef samplingCycle As CL3IF_SAMPLINGCYCLE) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMutualInterferencePrevention(deviceId As Integer, programNo As Byte, ByRef onOff As Boolean, ByRef group As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetAmbientLightFilter(deviceId As Integer, programNo As Byte, ByRef onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMedianFilter(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef medianFilter As CL3IF_MEDIANFILTER) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetThreshold(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef mode As CL3IF_MODE, ByRef value As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMask(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef onOff As Boolean, ByRef position1 As Integer, ByRef position2 As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetLightIntensityControl(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef mode As CL3IF_MODE, ByRef upperLimit As Byte, ByRef lowerLimit As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetPeakShapeFilter(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef onOff As Boolean, ByRef intensity As CL3IF_INTENSITY) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetLightIntensityIntegration(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef integrationNumber As CL3IF_INTEGRATION_NUMBER) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetQuadProcessing(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef processing As CL3IF_QUADPROCESSING, ByRef quadValidPoint As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMeasurementPeaks(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef peaks As Byte) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetCheckingNumberOfPeaks(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMultiLightIntensityControl(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef onOff As Boolean) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetRefractiveIndexCorrection(deviceId As Integer, programNo As Byte, headNo As Byte, ByRef onOff As Boolean, ByRef layer1 As CL3IF_MATERIAL, ByRef layer2 As CL3IF_MATERIAL,
        ByRef layer3 As CL3IF_MATERIAL) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetMeasurementMethod(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef method As CL3IF_MEASUREMENTMETHOD, ByRef param As CL3IF_MEASUREMENTMETHOD_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetScaling(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef inputValue1 As Integer, ByRef outputValue1 As Integer, ByRef inputValue2 As Integer,
        ByRef outputValue2 As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetOffset(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef offset As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetTolerance(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef upperLimit As Integer, ByRef lowerLimit As Integer, ByRef hysteresis As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetFilter(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef filterMode As CL3IF_FILTERMODE, ByRef filterParam As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetHold(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef holdMode As CL3IF_HOLDMODE, ByRef param As CL3IF_HOLDMODE_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetInvalidDataProcessing(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef invalidationNumber As UShort, ByRef recoveryNumber As UShort) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetDisplayUnit(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef displayUnit As CL3IF_DISPLAYUNIT) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetTerminalAllocation(deviceId As Integer, programNo As Byte, outNo As Byte, ByRef timingReset As CL3IF_TIMINGRESET, ByRef zero As CL3IF_ZERO) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetJudgmentOutput(deviceId As Integer, programNo As Byte, judgmentOutput As IntPtr) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetStorageNumber(deviceId As Integer, programNo As Byte, ByRef overwrite As Byte, ByRef storageNumber As UInteger) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetStorageTiming(deviceId As Integer, programNo As Byte, ByRef storageTiming As Byte, ByRef param As CL3IF_STORAGETIMING_PARAM) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_GetStorageTarget(deviceId As Integer, programNo As Byte, ByRef outNo As CL3IF_OUTNO) As Integer
        End Function

        <DllImport(DllName)>
        Friend Shared Function CL3IF_TransitToMeasurementMode(deviceId As Integer) As Integer
        End Function
        <DllImport(DllName)>
        Friend Shared Function CL3IF_TransitToSettingMode(deviceId As Integer) As Integer
        End Function
    End Class

End Module
