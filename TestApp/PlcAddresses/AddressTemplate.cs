// ReSharper disable All
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
namespace GeneratedAddress
{
    using TwinCatAdsCommunication.Address;

    public static class MC
    {
        public static BoolAddressUnconnected bDone { get; } = new BoolAddressUnconnected(8, "MC.bDone");

        public static BoolAddressUnconnected bError { get; } = new BoolAddressUnconnected(8, "MC.bError");

        public static FloatAddressUnconnected lrActPosToHmi { get; } = new FloatAddressUnconnected(32, "MC.lrActPosToHmi");

        public static UintAddressUnconnected iErrorId { get; } = new UintAddressUnconnected(32, "MC.iErrorId");

        public static BoolAddressUnconnected bBusyToHmi { get; } = new BoolAddressUnconnected(8, "MC.bBusyToHmi");

        public static BoolAddressUnconnected startPulse { get; } = new BoolAddressUnconnected(8, "MC.startPulse");

        public static BoolAddressUnconnected bResetServo { get; } = new BoolAddressUnconnected(8, "MC.bResetServo");

        public static DoubleAddressUnconnected lrActPos { get; } = new DoubleAddressUnconnected(64, "MC.lrActPos");

        public static DoubleAddressUnconnected lrVelocity { get; } = new DoubleAddressUnconnected(64, "MC.lrVelocity");

        public static DoubleAddressUnconnected rAcceleration { get; } = new DoubleAddressUnconnected(64, "MC.rAcceleration");

        public static DoubleAddressUnconnected lrAcceleration { get; } = new DoubleAddressUnconnected(64, "MC.lrAcceleration");

        public static DoubleAddressUnconnected lrDeceleration { get; } = new DoubleAddressUnconnected(64, "MC.lrDeceleration");

        public static ShortAddressUnconnected i { get; } = new ShortAddressUnconnected(16, "MC.i");

        public static DoubleArrayAddress2DUnconnected lrLong2DSampleArray { get; } = new DoubleArrayAddress2DUnconnected(1024, "MC.lrLong2DSampleArray");

        public static DoubleArrayAddress1DUnconnected lrLongSampleArray { get; } = new DoubleArrayAddress1DUnconnected(512, "MC.lrLongSampleArray");

        public static FloatArrayAddress1DUnconnected lrSampleArray { get; } = new FloatArrayAddress1DUnconnected(256, "MC.lrSampleArray");

        public static class AxisRef
        {
        }
    }

    public static class MC_2
    {
        public static BoolAddressUnconnected bDone { get; } = new BoolAddressUnconnected(8, "MC_2.bDone");

        public static BoolAddressUnconnected bError { get; } = new BoolAddressUnconnected(8, "MC_2.bError");

        public static BoolAddressUnconnected bBusyToHmi { get; } = new BoolAddressUnconnected(8, "MC_2.bBusyToHmi");

        public static FloatAddressUnconnected lrActPos { get; } = new FloatAddressUnconnected(32, "MC_2.lrActPos");

        public static UintAddressUnconnected iErrorId { get; } = new UintAddressUnconnected(32, "MC_2.iErrorId");

        public static BoolAddressUnconnected startPulse { get; } = new BoolAddressUnconnected(8, "MC_2.startPulse");

        public static BoolAddressUnconnected bResetServo { get; } = new BoolAddressUnconnected(8, "MC_2.bResetServo");

        public static DoubleAddressUnconnected lrVelocity { get; } = new DoubleAddressUnconnected(64, "MC_2.lrVelocity");

        public static DoubleAddressUnconnected rAcceleration { get; } = new DoubleAddressUnconnected(64, "MC_2.rAcceleration");

        public static DoubleAddressUnconnected lrAcceleration { get; } = new DoubleAddressUnconnected(64, "MC_2.lrAcceleration");

        public static DoubleAddressUnconnected lrDeceleration { get; } = new DoubleAddressUnconnected(64, "MC_2.lrDeceleration");

        public static class AxisRef
        {
        }
    }

    public static class Global_Variables
    {
        public static UshortAddressUnconnected AMSPORT_LOGGER { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_LOGGER");

        public static UshortAddressUnconnected AMSPORT_EVENTLOG { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_EVENTLOG");

        public static UshortAddressUnconnected AMSPORT_R0_RTIME { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_RTIME");

        public static UshortAddressUnconnected AMSPORT_R0_IO { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_IO");

        public static UshortAddressUnconnected AMSPORT_R0_NC { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_NC");

        public static UshortAddressUnconnected AMSPORT_R0_NCSAF { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_NCSAF");

        public static UshortAddressUnconnected AMSPORT_R0_NCSVB { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_NCSVB");

        public static UshortAddressUnconnected AMSPORT_R0_ISG { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_ISG");

        public static UshortAddressUnconnected AMSPORT_R0_CNC { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_CNC");

        public static UshortAddressUnconnected AMSPORT_R0_LINE { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_LINE");

        public static UshortAddressUnconnected AMSPORT_R0_PLC { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_PLC");

        public static UshortAddressUnconnected AMSPORT_R0_PLC_RTS1 { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_PLC_RTS1");

        public static UshortAddressUnconnected AMSPORT_R0_PLC_RTS2 { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_PLC_RTS2");

        public static UshortAddressUnconnected AMSPORT_R0_PLC_RTS3 { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_PLC_RTS3");

        public static UshortAddressUnconnected AMSPORT_R0_PLC_RTS4 { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_PLC_RTS4");

        public static UshortAddressUnconnected AMSPORT_R0_CAM { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_CAM");

        public static UshortAddressUnconnected AMSPORT_R0_CAMTOOL { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R0_CAMTOOL");

        public static UshortAddressUnconnected AMSPORT_R3_SYSSERV { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R3_SYSSERV");

        public static UshortAddressUnconnected AMSPORT_R3_SCOPESERVER { get; } = new UshortAddressUnconnected(16, "Global_Variables.AMSPORT_R3_SCOPESERVER");

        public static UshortAddressUnconnected ADSSTATE_INVALID { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_INVALID");

        public static UshortAddressUnconnected ADSSTATE_IDLE { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_IDLE");

        public static UshortAddressUnconnected ADSSTATE_RESET { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_RESET");

        public static UshortAddressUnconnected ADSSTATE_INIT { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_INIT");

        public static UshortAddressUnconnected ADSSTATE_START { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_START");

        public static UshortAddressUnconnected ADSSTATE_RUN { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_RUN");

        public static UshortAddressUnconnected ADSSTATE_STOP { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_STOP");

        public static UshortAddressUnconnected ADSSTATE_SAVECFG { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_SAVECFG");

        public static UshortAddressUnconnected ADSSTATE_LOADCFG { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_LOADCFG");

        public static UshortAddressUnconnected ADSSTATE_POWERFAILURE { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_POWERFAILURE");

        public static UshortAddressUnconnected ADSSTATE_POWERGOOD { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_POWERGOOD");

        public static UshortAddressUnconnected ADSSTATE_ERROR { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_ERROR");

        public static UshortAddressUnconnected ADSSTATE_SHUTDOWN { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_SHUTDOWN");

        public static UshortAddressUnconnected ADSSTATE_SUSPEND { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_SUSPEND");

        public static UshortAddressUnconnected ADSSTATE_RESUME { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_RESUME");

        public static UshortAddressUnconnected ADSSTATE_CONFIG { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_CONFIG");

        public static UshortAddressUnconnected ADSSTATE_RECONFIG { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_RECONFIG");

        public static UshortAddressUnconnected ADSSTATE_STOPPING { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_STOPPING");

        public static UshortAddressUnconnected ADSSTATE_INCOMPATIBLE { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_INCOMPATIBLE");

        public static UshortAddressUnconnected ADSSTATE_EXCEPTION { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_EXCEPTION");

        public static UshortAddressUnconnected ADSSTATE_MAXSTATES { get; } = new UshortAddressUnconnected(16, "Global_Variables.ADSSTATE_MAXSTATES");

        public static UintAddressUnconnected ADSIGRP_SYMTAB { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYMTAB");

        public static UintAddressUnconnected ADSIGRP_SYMNAME { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYMNAME");

        public static UintAddressUnconnected ADSIGRP_SYMVAL { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYMVAL");

        public static UintAddressUnconnected ADSIGRP_SYM_HNDBYNAME { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_HNDBYNAME");

        public static UintAddressUnconnected ADSIGRP_SYM_VALBYNAME { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_VALBYNAME");

        public static UintAddressUnconnected ADSIGRP_SYM_VALBYHND { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_VALBYHND");

        public static UintAddressUnconnected ADSIGRP_SYM_RELEASEHND { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_RELEASEHND");

        public static UintAddressUnconnected ADSIGRP_SYM_INFOBYNAME { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAME");

        public static UintAddressUnconnected ADSIGRP_SYM_VERSION { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_VERSION");

        public static UintAddressUnconnected ADSIGRP_SYM_INFOBYNAMEEX { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAMEEX");

        public static UintAddressUnconnected ADSIGRP_SYM_DOWNLOAD { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_DOWNLOAD");

        public static UintAddressUnconnected ADSIGRP_SYM_UPLOAD { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_UPLOAD");

        public static UintAddressUnconnected ADSIGRP_SYM_UPLOADINFO { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYM_UPLOADINFO");

        public static UintAddressUnconnected ADSIGRP_SYMNOTE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_SYMNOTE");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RWIB { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIB");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RWIX { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIX");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RISIZE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RISIZE");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RWOB { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOB");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RWOX { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOX");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_ROSIZE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_ROSIZE");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_CLEARI { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARI");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_CLEARO { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARO");

        public static UintAddressUnconnected ADSIGRP_IOIMAGE_RWIOB { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIOB");

        public static UintAddressUnconnected ADSIGRP_DEVICE_DATA { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIGRP_DEVICE_DATA");

        public static UintAddressUnconnected ADSIOFFS_DEVDATA_ADSSTATE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIOFFS_DEVDATA_ADSSTATE");

        public static UintAddressUnconnected ADSIOFFS_DEVDATA_DEVSTATE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSIOFFS_DEVDATA_DEVSTATE");

        public static UintAddressUnconnected SYSTEMSERVICE_OPENCREATE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_OPENCREATE");

        public static UintAddressUnconnected SYSTEMSERVICE_OPENREAD { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_OPENREAD");

        public static UintAddressUnconnected SYSTEMSERVICE_OPENWRITE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_OPENWRITE");

        public static UintAddressUnconnected SYSTEMSERVICE_CREATEFILE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_CREATEFILE");

        public static UintAddressUnconnected SYSTEMSERVICE_CLOSEHANDLE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_CLOSEHANDLE");

        public static UintAddressUnconnected SYSTEMSERVICE_FOPEN { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FOPEN");

        public static UintAddressUnconnected SYSTEMSERVICE_FCLOSE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FCLOSE");

        public static UintAddressUnconnected SYSTEMSERVICE_FREAD { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FREAD");

        public static UintAddressUnconnected SYSTEMSERVICE_FWRITE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FWRITE");

        public static UintAddressUnconnected SYSTEMSERVICE_FSEEK { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FSEEK");

        public static UintAddressUnconnected SYSTEMSERVICE_FTELL { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FTELL");

        public static UintAddressUnconnected SYSTEMSERVICE_FGETS { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FGETS");

        public static UintAddressUnconnected SYSTEMSERVICE_FPUTS { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FPUTS");

        public static UintAddressUnconnected SYSTEMSERVICE_FSCANF { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FSCANF");

        public static UintAddressUnconnected SYSTEMSERVICE_FPRINTF { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FPRINTF");

        public static UintAddressUnconnected SYSTEMSERVICE_FEOF { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FEOF");

        public static UintAddressUnconnected SYSTEMSERVICE_FDELETE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FDELETE");

        public static UintAddressUnconnected SYSTEMSERVICE_FRENAME { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_FRENAME");

        public static UintAddressUnconnected SYSTEMSERVICE_MKDIR { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_MKDIR");

        public static UintAddressUnconnected SYSTEMSERVICE_RMDIR { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_RMDIR");

        public static UintAddressUnconnected SYSTEMSERVICE_REG_HKEYLOCALMACHINE { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_REG_HKEYLOCALMACHINE");

        public static UintAddressUnconnected SYSTEMSERVICE_SENDEMAIL { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_SENDEMAIL");

        public static UintAddressUnconnected SYSTEMSERVICE_TIMESERVICES { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_TIMESERVICES");

        public static UintAddressUnconnected SYSTEMSERVICE_STARTPROCESS { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_STARTPROCESS");

        public static UintAddressUnconnected SYSTEMSERVICE_CHANGENETID { get; } = new UintAddressUnconnected(32, "Global_Variables.SYSTEMSERVICE_CHANGENETID");

        public static UintAddressUnconnected TIMESERVICE_DATEANDTIME { get; } = new UintAddressUnconnected(32, "Global_Variables.TIMESERVICE_DATEANDTIME");

        public static UintAddressUnconnected TIMESERVICE_SYSTEMTIMES { get; } = new UintAddressUnconnected(32, "Global_Variables.TIMESERVICE_SYSTEMTIMES");

        public static UintAddressUnconnected TIMESERVICE_RTCTIMEDIFF { get; } = new UintAddressUnconnected(32, "Global_Variables.TIMESERVICE_RTCTIMEDIFF");

        public static UintAddressUnconnected TIMESERVICE_ADJUSTTIMETORTC { get; } = new UintAddressUnconnected(32, "Global_Variables.TIMESERVICE_ADJUSTTIMETORTC");

        public static UintAddressUnconnected TIMESERVICE_TIMEZONINFORMATION { get; } = new UintAddressUnconnected(32, "Global_Variables.TIMESERVICE_TIMEZONINFORMATION");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_HINT { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_HINT");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_WARN { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_WARN");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_ERROR { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_ERROR");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_LOG { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_LOG");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_MSGBOX { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_MSGBOX");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_RESOURCE { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_RESOURCE");

        public static UintAddressUnconnected ADSLOG_MSGTYPE_STRING { get; } = new UintAddressUnconnected(32, "Global_Variables.ADSLOG_MSGTYPE_STRING");

        public static ByteAddressUnconnected BOOTDATAFLAGS_RETAIN_LOADED { get; } = new ByteAddressUnconnected(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_LOADED");

        public static ByteAddressUnconnected BOOTDATAFLAGS_RETAIN_INVALID { get; } = new ByteAddressUnconnected(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_INVALID");

        public static ByteAddressUnconnected BOOTDATAFLAGS_RETAIN_REQUESTED { get; } = new ByteAddressUnconnected(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_REQUESTED");

        public static ByteAddressUnconnected BOOTDATAFLAGS_PERSISTENT_LOADED { get; } = new ByteAddressUnconnected(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_LOADED");

        public static ByteAddressUnconnected BOOTDATAFLAGS_PERSISTENT_INVALID { get; } = new ByteAddressUnconnected(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_INVALID");

        public static ByteAddressUnconnected SYSTEMSTATEFLAGS_BSOD { get; } = new ByteAddressUnconnected(8, "Global_Variables.SYSTEMSTATEFLAGS_BSOD");

        public static ByteAddressUnconnected SYSTEMSTATEFLAGS_RTVIOLATION { get; } = new ByteAddressUnconnected(8, "Global_Variables.SYSTEMSTATEFLAGS_RTVIOLATION");

        public static ByteAddressUnconnected nWatchdogTime { get; } = new ByteAddressUnconnected(8, "Global_Variables.nWatchdogTime");

        public static UintAddressUnconnected FOPEN_MODEREAD { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODEREAD");

        public static UintAddressUnconnected FOPEN_MODEWRITE { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODEWRITE");

        public static UintAddressUnconnected FOPEN_MODEAPPEND { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODEAPPEND");

        public static UintAddressUnconnected FOPEN_MODEPLUS { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODEPLUS");

        public static UintAddressUnconnected FOPEN_MODEBINARY { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODEBINARY");

        public static UintAddressUnconnected FOPEN_MODETEXT { get; } = new UintAddressUnconnected(32, "Global_Variables.FOPEN_MODETEXT");

        public static ShortAddressUnconnected TCEVENTFLAG_PRIOCLASS { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_PRIOCLASS");

        public static ShortAddressUnconnected TCEVENTFLAG_FMTSELF { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_FMTSELF");

        public static ShortAddressUnconnected TCEVENTFLAG_LOG { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_LOG");

        public static ShortAddressUnconnected TCEVENTFLAG_MSGBOX { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_MSGBOX");

        public static ShortAddressUnconnected TCEVENTFLAG_SRCID { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_SRCID");

        public static ShortAddressUnconnected TCEVENTFLAG_AUTOFMTALL { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTFLAG_AUTOFMTALL");

        public static ShortAddressUnconnected TCEVENTSTATE_INVALID { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTSTATE_INVALID");

        public static ShortAddressUnconnected TCEVENTSTATE_SIGNALED { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTSTATE_SIGNALED");

        public static ShortAddressUnconnected TCEVENTSTATE_RESET { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTSTATE_RESET");

        public static ShortAddressUnconnected TCEVENTSTATE_CONFIRMED { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTSTATE_CONFIRMED");

        public static ShortAddressUnconnected TCEVENTSTATE_RESETCON { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENTSTATE_RESETCON");

        public static ShortAddressUnconnected TCEVENT_SRCNAMESIZE { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENT_SRCNAMESIZE");

        public static ShortAddressUnconnected TCEVENT_FMTPRGSIZE { get; } = new ShortAddressUnconnected(16, "Global_Variables.TCEVENT_FMTPRGSIZE");

        public static DoubleAddressUnconnected PI { get; } = new DoubleAddressUnconnected(64, "Global_Variables.PI");

        public static UintAddressUnconnected MAX_STRING_LENGTH { get; } = new UintAddressUnconnected(32, "Global_Variables.MAX_STRING_LENGTH");

        public static DoubleAddressUnconnected DEFAULT_HOME_POSITION { get; } = new DoubleAddressUnconnected(64, "Global_Variables.DEFAULT_HOME_POSITION");

        public static DoubleAddressUnconnected DEFAULT_BACKLASHVALUE { get; } = new DoubleAddressUnconnected(64, "Global_Variables.DEFAULT_BACKLASHVALUE");
    }

    public static class MAIN
    {
        public static BoolAddressUnconnected bBuildingBoxConnected { get; } = new BoolAddressUnconnected(8, "MAIN.bBuildingBoxConnected");

        public static BoolAddressUnconnected bDairyBox1Connected { get; } = new BoolAddressUnconnected(8, "MAIN.bDairyBox1Connected");

        public static BoolAddressUnconnected bDairyrBox2Connected { get; } = new BoolAddressUnconnected(8, "MAIN.bDairyrBox2Connected");

        public static BoolAddressUnconnected bRedLight { get; } = new BoolAddressUnconnected(8, "MAIN.bRedLight");

        public static BoolAddressUnconnected bProtectionCoverClosed { get; } = new BoolAddressUnconnected(8, "MAIN.bProtectionCoverClosed");

        public static IntAddressUnconnected iDairyHeightBuildBox { get; } = new IntAddressUnconnected(32, "MAIN.iDairyHeightBuildBox");

        public static IntAddressUnconnected iDairyHeightPowderBox1 { get; } = new IntAddressUnconnected(32, "MAIN.iDairyHeightPowderBox1");

        public static IntAddressUnconnected iDairyHeightPowderBox2 { get; } = new IntAddressUnconnected(32, "MAIN.iDairyHeightPowderBox2");

        public static FloatAddressUnconnected rWaterLevel { get; } = new FloatAddressUnconnected(32, "MAIN.rWaterLevel");

        public static BoolAddressUnconnected bPower { get; } = new BoolAddressUnconnected(8, "MAIN.bPower");

        public static BoolAddressUnconnected bGreen { get; } = new BoolAddressUnconnected(8, "MAIN.bGreen");

        public static BoolAddressUnconnected bYellow { get; } = new BoolAddressUnconnected(8, "MAIN.bYellow");

        public static BoolAddressUnconnected bRed { get; } = new BoolAddressUnconnected(8, "MAIN.bRed");

        public static StringAddressUnconnected sFileName { get; } = new StringAddressUnconnected(648, "MAIN.sFileName");

        public static BoolAddressUnconnected bOpenFile { get; } = new BoolAddressUnconnected(8, "MAIN.bOpenFile");

        public static BoolAddressUnconnected bStepForward { get; } = new BoolAddressUnconnected(8, "MAIN.bStepForward");

        public static BoolAddressUnconnected bRun { get; } = new BoolAddressUnconnected(8, "MAIN.bRun");

        public static ShortAddressUnconnected rWaterLevel2 { get; } = new ShortAddressUnconnected(16, "MAIN.rWaterLevel2");

        public static FloatAddressUnconnected rPosition { get; } = new FloatAddressUnconnected(32, "MAIN.rPosition");

        public static BoolAddressUnconnected TestBoolIn { get; } = new BoolAddressUnconnected(8, "MAIN.TestBoolIn");

        public static BoolAddressUnconnected TestBoolOut { get; } = new BoolAddressUnconnected(8, "MAIN.TestBoolOut");

        public static BoolAddressUnconnected LightOn { get; } = new BoolAddressUnconnected(8, "MAIN.LightOn");

        public static BoolAddressUnconnected IsLightOn { get; } = new BoolAddressUnconnected(8, "MAIN.IsLightOn");

        public static IntAddressUnconnected TestIntIn { get; } = new IntAddressUnconnected(32, "MAIN.TestIntIn");

        public static IntAddressUnconnected TestIntOut { get; } = new IntAddressUnconnected(32, "MAIN.TestIntOut");

        public static StringAddressUnconnected TestStringIn { get; } = new StringAddressUnconnected(648, "MAIN.TestStringIn");

        public static StringAddressUnconnected TestStringOut { get; } = new StringAddressUnconnected(648, "MAIN.TestStringOut");

        public static BoolAddressUnconnected TrigSequenceRequest { get; } = new BoolAddressUnconnected(8, "MAIN.TrigSequenceRequest");

        public static BoolAddressUnconnected SequenceRequest { get; } = new BoolAddressUnconnected(8, "MAIN.SequenceRequest");

        public static BoolAddressUnconnected SequenceDone { get; } = new BoolAddressUnconnected(8, "MAIN.SequenceDone");

        public static BoolAddressUnconnected lXAxisEnable { get; } = new BoolAddressUnconnected(8, "MAIN.lXAxisEnable");

        public static BoolAddressUnconnected bBoolToMove1m { get; } = new BoolAddressUnconnected(8, "MAIN.bBoolToMove1m");

        public static BoolAddressUnconnected bBoolToMove1 { get; } = new BoolAddressUnconnected(8, "MAIN.bBoolToMove1");

        public static IntAddressUnconnected SequenceError { get; } = new IntAddressUnconnected(32, "MAIN.SequenceError");

        public static BoolAddressUnconnected bMovedBool1 { get; } = new BoolAddressUnconnected(8, "MAIN.bMovedBool1");

        public static BoolAddressUnconnected bMovedBool2 { get; } = new BoolAddressUnconnected(8, "MAIN.bMovedBool2");

    }

    public static class Position_Control
    {
        public static BoolAddressUnconnected bPositioningDone2 { get; } = new BoolAddressUnconnected(8, "Position_Control.bPositioningDone2");

        public static BoolAddressUnconnected bPositioningDone1 { get; } = new BoolAddressUnconnected(8, "Position_Control.bPositioningDone1");

        public static DoubleAddressUnconnected lrServo1CurrentPos { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo1CurrentPos");

        public static DoubleAddressUnconnected lrServo2CurrentPos { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo2CurrentPos");

        public static DoubleAddressUnconnected lrServo1Position1 { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo1Position1");

        public static DoubleAddressUnconnected lrServo2Position1 { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo2Position1");

        public static DoubleAddressUnconnected lrServo1Position2 { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo1Position2");

        public static DoubleAddressUnconnected lrServo2Position2 { get; } = new DoubleAddressUnconnected(64, "Position_Control.lrServo2Position2");

    }

    public static class BackForthSequence
    {
        public static BoolAddressUnconnected start_ui { get; } = new BoolAddressUnconnected(8, "BackForthSequence.start_ui");
    }

    public static class Constants
    {
        public static BoolAddressUnconnected bLittleEndian { get; } = new BoolAddressUnconnected(8, "Constants.bLittleEndian");

        public static BoolAddressUnconnected bSimulationMode { get; } = new BoolAddressUnconnected(8, "Constants.bSimulationMode");

        public static ShortAddressUnconnected nRegisterSize { get; } = new ShortAddressUnconnected(16, "Constants.nRegisterSize");

        public static UshortAddressUnconnected nPackMode { get; } = new UshortAddressUnconnected(16, "Constants.nPackMode");

        public static BoolAddressUnconnected bFPUSupport { get; } = new BoolAddressUnconnected(8, "Constants.bFPUSupport");

        public static UintAddressUnconnected RuntimeVersionNumeric { get; } = new UintAddressUnconnected(32, "Constants.RuntimeVersionNumeric");

        public static UintAddressUnconnected CompilerVersionNumeric { get; } = new UintAddressUnconnected(32, "Constants.CompilerVersionNumeric");
    }

    public static class TwinCAT_SystemInfoVarList
    {
    }

}
#pragma warning restore SA1300 // Element must begin with upper-case letter
#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single class

// ReSharper restore All

