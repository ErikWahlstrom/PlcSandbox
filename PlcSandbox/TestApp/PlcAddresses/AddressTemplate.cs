// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
namespace GeneratedAddress
{
    using TwinCatAdsCommunication.Address;

    public static class MC
    {
        public static BoolAddressInitial bDone { get; } = new BoolAddressInitial(8, "MC.bDone");

        public static BoolAddressInitial bError { get; } = new BoolAddressInitial(8, "MC.bError");

        public static BoolAddressInitial bBusyToHmi { get; } = new BoolAddressInitial(8, "MC.bBusyToHmi");

        public static FloatAddressInitial lrActPosToHmi { get; } = new FloatAddressInitial(32, "MC.lrActPosToHmi");

        public static UintAddressInitial iErrorId { get; } = new UintAddressInitial(32, "MC.iErrorId");

        public static DoubleAddressInitial lrActPos { get; } = new DoubleAddressInitial(64, "MC.lrActPos");

        public static BoolAddressInitial startPulse { get; } = new BoolAddressInitial(8, "MC.startPulse");

        public static BoolAddressInitial bResetServo { get; } = new BoolAddressInitial(8, "MC.bResetServo");

        public static DoubleAddressInitial lrVelocity { get; } = new DoubleAddressInitial(64, "MC.lrVelocity");

        public static DoubleAddressInitial rAcceleration { get; } = new DoubleAddressInitial(64, "MC.rAcceleration");

        public static DoubleAddressInitial lrAcceleration { get; } = new DoubleAddressInitial(64, "MC.lrAcceleration");

        public static DoubleAddressInitial lrDeceleration { get; } = new DoubleAddressInitial(64, "MC.lrDeceleration");

        public static class AxisRef
        {
        }
    }

    public static class MC_2
    {
        public static BoolAddressInitial bDone { get; } = new BoolAddressInitial(8, "MC_2.bDone");

        public static BoolAddressInitial bError { get; } = new BoolAddressInitial(8, "MC_2.bError");

        public static FloatAddressInitial lrActPos { get; } = new FloatAddressInitial(32, "MC_2.lrActPos");

        public static UintAddressInitial iErrorId { get; } = new UintAddressInitial(32, "MC_2.iErrorId");

        public static BoolAddressInitial bBusyToHmi { get; } = new BoolAddressInitial(8, "MC_2.bBusyToHmi");

        public static BoolAddressInitial startPulse { get; } = new BoolAddressInitial(8, "MC_2.startPulse");

        public static BoolAddressInitial bResetServo { get; } = new BoolAddressInitial(8, "MC_2.bResetServo");

        public static DoubleAddressInitial lrVelocity { get; } = new DoubleAddressInitial(64, "MC_2.lrVelocity");

        public static DoubleAddressInitial rAcceleration { get; } = new DoubleAddressInitial(64, "MC_2.rAcceleration");

        public static DoubleAddressInitial lrAcceleration { get; } = new DoubleAddressInitial(64, "MC_2.lrAcceleration");

        public static DoubleAddressInitial lrDeceleration { get; } = new DoubleAddressInitial(64, "MC_2.lrDeceleration");

        public static class AxisRef
        {
        }
    }

    public static class Global_Variables
    {
        public static UshortAddressInitial AMSPORT_LOGGER { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_LOGGER");

        public static UshortAddressInitial AMSPORT_EVENTLOG { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_EVENTLOG");

        public static UshortAddressInitial AMSPORT_R0_RTIME { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_RTIME");

        public static UshortAddressInitial AMSPORT_R0_IO { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_IO");

        public static UshortAddressInitial AMSPORT_R0_NC { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_NC");

        public static UshortAddressInitial AMSPORT_R0_NCSAF { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_NCSAF");

        public static UshortAddressInitial AMSPORT_R0_NCSVB { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_NCSVB");

        public static UshortAddressInitial AMSPORT_R0_ISG { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_ISG");

        public static UshortAddressInitial AMSPORT_R0_CNC { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_CNC");

        public static UshortAddressInitial AMSPORT_R0_LINE { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_LINE");

        public static UshortAddressInitial AMSPORT_R0_PLC { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_PLC");

        public static UshortAddressInitial AMSPORT_R0_PLC_RTS1 { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_PLC_RTS1");

        public static UshortAddressInitial AMSPORT_R0_PLC_RTS2 { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_PLC_RTS2");

        public static UshortAddressInitial AMSPORT_R0_PLC_RTS3 { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_PLC_RTS3");

        public static UshortAddressInitial AMSPORT_R0_PLC_RTS4 { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_PLC_RTS4");

        public static UshortAddressInitial AMSPORT_R0_CAM { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_CAM");

        public static UshortAddressInitial AMSPORT_R0_CAMTOOL { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R0_CAMTOOL");

        public static UshortAddressInitial AMSPORT_R3_SYSSERV { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R3_SYSSERV");

        public static UshortAddressInitial AMSPORT_R3_SCOPESERVER { get; } = new UshortAddressInitial(16, "Global_Variables.AMSPORT_R3_SCOPESERVER");

        public static UshortAddressInitial ADSSTATE_INVALID { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_INVALID");

        public static UshortAddressInitial ADSSTATE_IDLE { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_IDLE");

        public static UshortAddressInitial ADSSTATE_RESET { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_RESET");

        public static UshortAddressInitial ADSSTATE_INIT { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_INIT");

        public static UshortAddressInitial ADSSTATE_START { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_START");

        public static UshortAddressInitial ADSSTATE_RUN { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_RUN");

        public static UshortAddressInitial ADSSTATE_STOP { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_STOP");

        public static UshortAddressInitial ADSSTATE_SAVECFG { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_SAVECFG");

        public static UshortAddressInitial ADSSTATE_LOADCFG { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_LOADCFG");

        public static UshortAddressInitial ADSSTATE_POWERFAILURE { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_POWERFAILURE");

        public static UshortAddressInitial ADSSTATE_POWERGOOD { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_POWERGOOD");

        public static UshortAddressInitial ADSSTATE_ERROR { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_ERROR");

        public static UshortAddressInitial ADSSTATE_SHUTDOWN { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_SHUTDOWN");

        public static UshortAddressInitial ADSSTATE_SUSPEND { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_SUSPEND");

        public static UshortAddressInitial ADSSTATE_RESUME { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_RESUME");

        public static UshortAddressInitial ADSSTATE_CONFIG { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_CONFIG");

        public static UshortAddressInitial ADSSTATE_RECONFIG { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_RECONFIG");

        public static UshortAddressInitial ADSSTATE_STOPPING { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_STOPPING");

        public static UshortAddressInitial ADSSTATE_INCOMPATIBLE { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_INCOMPATIBLE");

        public static UshortAddressInitial ADSSTATE_EXCEPTION { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_EXCEPTION");

        public static UshortAddressInitial ADSSTATE_MAXSTATES { get; } = new UshortAddressInitial(16, "Global_Variables.ADSSTATE_MAXSTATES");

        public static UintAddressInitial ADSIGRP_SYMTAB { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYMTAB");

        public static UintAddressInitial ADSIGRP_SYMNAME { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYMNAME");

        public static UintAddressInitial ADSIGRP_SYMVAL { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYMVAL");

        public static UintAddressInitial ADSIGRP_SYM_HNDBYNAME { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_HNDBYNAME");

        public static UintAddressInitial ADSIGRP_SYM_VALBYNAME { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_VALBYNAME");

        public static UintAddressInitial ADSIGRP_SYM_VALBYHND { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_VALBYHND");

        public static UintAddressInitial ADSIGRP_SYM_RELEASEHND { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_RELEASEHND");

        public static UintAddressInitial ADSIGRP_SYM_INFOBYNAME { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAME");

        public static UintAddressInitial ADSIGRP_SYM_VERSION { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_VERSION");

        public static UintAddressInitial ADSIGRP_SYM_INFOBYNAMEEX { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAMEEX");

        public static UintAddressInitial ADSIGRP_SYM_DOWNLOAD { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_DOWNLOAD");

        public static UintAddressInitial ADSIGRP_SYM_UPLOAD { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_UPLOAD");

        public static UintAddressInitial ADSIGRP_SYM_UPLOADINFO { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYM_UPLOADINFO");

        public static UintAddressInitial ADSIGRP_SYMNOTE { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_SYMNOTE");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RWIB { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIB");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RWIX { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIX");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RISIZE { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RISIZE");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RWOB { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOB");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RWOX { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOX");

        public static UintAddressInitial ADSIGRP_IOIMAGE_ROSIZE { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_ROSIZE");

        public static UintAddressInitial ADSIGRP_IOIMAGE_CLEARI { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARI");

        public static UintAddressInitial ADSIGRP_IOIMAGE_CLEARO { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARO");

        public static UintAddressInitial ADSIGRP_IOIMAGE_RWIOB { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIOB");

        public static UintAddressInitial ADSIGRP_DEVICE_DATA { get; } = new UintAddressInitial(32, "Global_Variables.ADSIGRP_DEVICE_DATA");

        public static UintAddressInitial ADSIOFFS_DEVDATA_ADSSTATE { get; } = new UintAddressInitial(32, "Global_Variables.ADSIOFFS_DEVDATA_ADSSTATE");

        public static UintAddressInitial ADSIOFFS_DEVDATA_DEVSTATE { get; } = new UintAddressInitial(32, "Global_Variables.ADSIOFFS_DEVDATA_DEVSTATE");

        public static UintAddressInitial SYSTEMSERVICE_OPENCREATE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_OPENCREATE");

        public static UintAddressInitial SYSTEMSERVICE_OPENREAD { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_OPENREAD");

        public static UintAddressInitial SYSTEMSERVICE_OPENWRITE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_OPENWRITE");

        public static UintAddressInitial SYSTEMSERVICE_CREATEFILE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_CREATEFILE");

        public static UintAddressInitial SYSTEMSERVICE_CLOSEHANDLE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_CLOSEHANDLE");

        public static UintAddressInitial SYSTEMSERVICE_FOPEN { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FOPEN");

        public static UintAddressInitial SYSTEMSERVICE_FCLOSE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FCLOSE");

        public static UintAddressInitial SYSTEMSERVICE_FREAD { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FREAD");

        public static UintAddressInitial SYSTEMSERVICE_FWRITE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FWRITE");

        public static UintAddressInitial SYSTEMSERVICE_FSEEK { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FSEEK");

        public static UintAddressInitial SYSTEMSERVICE_FTELL { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FTELL");

        public static UintAddressInitial SYSTEMSERVICE_FGETS { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FGETS");

        public static UintAddressInitial SYSTEMSERVICE_FPUTS { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FPUTS");

        public static UintAddressInitial SYSTEMSERVICE_FSCANF { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FSCANF");

        public static UintAddressInitial SYSTEMSERVICE_FPRINTF { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FPRINTF");

        public static UintAddressInitial SYSTEMSERVICE_FEOF { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FEOF");

        public static UintAddressInitial SYSTEMSERVICE_FDELETE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FDELETE");

        public static UintAddressInitial SYSTEMSERVICE_FRENAME { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_FRENAME");

        public static UintAddressInitial SYSTEMSERVICE_MKDIR { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_MKDIR");

        public static UintAddressInitial SYSTEMSERVICE_RMDIR { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_RMDIR");

        public static UintAddressInitial SYSTEMSERVICE_REG_HKEYLOCALMACHINE { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_REG_HKEYLOCALMACHINE");

        public static UintAddressInitial SYSTEMSERVICE_SENDEMAIL { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_SENDEMAIL");

        public static UintAddressInitial SYSTEMSERVICE_TIMESERVICES { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_TIMESERVICES");

        public static UintAddressInitial SYSTEMSERVICE_STARTPROCESS { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_STARTPROCESS");

        public static UintAddressInitial SYSTEMSERVICE_CHANGENETID { get; } = new UintAddressInitial(32, "Global_Variables.SYSTEMSERVICE_CHANGENETID");

        public static UintAddressInitial TIMESERVICE_DATEANDTIME { get; } = new UintAddressInitial(32, "Global_Variables.TIMESERVICE_DATEANDTIME");

        public static UintAddressInitial TIMESERVICE_SYSTEMTIMES { get; } = new UintAddressInitial(32, "Global_Variables.TIMESERVICE_SYSTEMTIMES");

        public static UintAddressInitial TIMESERVICE_RTCTIMEDIFF { get; } = new UintAddressInitial(32, "Global_Variables.TIMESERVICE_RTCTIMEDIFF");

        public static UintAddressInitial TIMESERVICE_ADJUSTTIMETORTC { get; } = new UintAddressInitial(32, "Global_Variables.TIMESERVICE_ADJUSTTIMETORTC");

        public static UintAddressInitial TIMESERVICE_TIMEZONINFORMATION { get; } = new UintAddressInitial(32, "Global_Variables.TIMESERVICE_TIMEZONINFORMATION");

        public static UintAddressInitial ADSLOG_MSGTYPE_HINT { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_HINT");

        public static UintAddressInitial ADSLOG_MSGTYPE_WARN { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_WARN");

        public static UintAddressInitial ADSLOG_MSGTYPE_ERROR { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_ERROR");

        public static UintAddressInitial ADSLOG_MSGTYPE_LOG { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_LOG");

        public static UintAddressInitial ADSLOG_MSGTYPE_MSGBOX { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_MSGBOX");

        public static UintAddressInitial ADSLOG_MSGTYPE_RESOURCE { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_RESOURCE");

        public static UintAddressInitial ADSLOG_MSGTYPE_STRING { get; } = new UintAddressInitial(32, "Global_Variables.ADSLOG_MSGTYPE_STRING");

        public static ByteAddressInitial BOOTDATAFLAGS_RETAIN_LOADED { get; } = new ByteAddressInitial(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_LOADED");

        public static ByteAddressInitial BOOTDATAFLAGS_RETAIN_INVALID { get; } = new ByteAddressInitial(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_INVALID");

        public static ByteAddressInitial BOOTDATAFLAGS_RETAIN_REQUESTED { get; } = new ByteAddressInitial(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_REQUESTED");

        public static ByteAddressInitial BOOTDATAFLAGS_PERSISTENT_LOADED { get; } = new ByteAddressInitial(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_LOADED");

        public static ByteAddressInitial BOOTDATAFLAGS_PERSISTENT_INVALID { get; } = new ByteAddressInitial(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_INVALID");

        public static ByteAddressInitial SYSTEMSTATEFLAGS_BSOD { get; } = new ByteAddressInitial(8, "Global_Variables.SYSTEMSTATEFLAGS_BSOD");

        public static ByteAddressInitial SYSTEMSTATEFLAGS_RTVIOLATION { get; } = new ByteAddressInitial(8, "Global_Variables.SYSTEMSTATEFLAGS_RTVIOLATION");

        public static ByteAddressInitial nWatchdogTime { get; } = new ByteAddressInitial(8, "Global_Variables.nWatchdogTime");

        public static UintAddressInitial FOPEN_MODEREAD { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODEREAD");

        public static UintAddressInitial FOPEN_MODEWRITE { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODEWRITE");

        public static UintAddressInitial FOPEN_MODEAPPEND { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODEAPPEND");

        public static UintAddressInitial FOPEN_MODEPLUS { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODEPLUS");

        public static UintAddressInitial FOPEN_MODEBINARY { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODEBINARY");

        public static UintAddressInitial FOPEN_MODETEXT { get; } = new UintAddressInitial(32, "Global_Variables.FOPEN_MODETEXT");

        public static ShortAddressInitial TCEVENTFLAG_PRIOCLASS { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_PRIOCLASS");

        public static ShortAddressInitial TCEVENTFLAG_FMTSELF { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_FMTSELF");

        public static ShortAddressInitial TCEVENTFLAG_LOG { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_LOG");

        public static ShortAddressInitial TCEVENTFLAG_MSGBOX { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_MSGBOX");

        public static ShortAddressInitial TCEVENTFLAG_SRCID { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_SRCID");

        public static ShortAddressInitial TCEVENTFLAG_AUTOFMTALL { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTFLAG_AUTOFMTALL");

        public static ShortAddressInitial TCEVENTSTATE_INVALID { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTSTATE_INVALID");

        public static ShortAddressInitial TCEVENTSTATE_SIGNALED { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTSTATE_SIGNALED");

        public static ShortAddressInitial TCEVENTSTATE_RESET { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTSTATE_RESET");

        public static ShortAddressInitial TCEVENTSTATE_CONFIRMED { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTSTATE_CONFIRMED");

        public static ShortAddressInitial TCEVENTSTATE_RESETCON { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENTSTATE_RESETCON");

        public static ShortAddressInitial TCEVENT_SRCNAMESIZE { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENT_SRCNAMESIZE");

        public static ShortAddressInitial TCEVENT_FMTPRGSIZE { get; } = new ShortAddressInitial(16, "Global_Variables.TCEVENT_FMTPRGSIZE");

        public static DoubleAddressInitial PI { get; } = new DoubleAddressInitial(64, "Global_Variables.PI");

        public static UintAddressInitial MAX_STRING_LENGTH { get; } = new UintAddressInitial(32, "Global_Variables.MAX_STRING_LENGTH");

        public static DoubleAddressInitial DEFAULT_HOME_POSITION { get; } = new DoubleAddressInitial(64, "Global_Variables.DEFAULT_HOME_POSITION");

        public static DoubleAddressInitial DEFAULT_BACKLASHVALUE { get; } = new DoubleAddressInitial(64, "Global_Variables.DEFAULT_BACKLASHVALUE");
    }

    public static class MAIN
    {
        public static BoolAddressInitial bBuildingBoxConnected { get; } = new BoolAddressInitial(8, "MAIN.bBuildingBoxConnected");

        public static BoolAddressInitial bPowderBox1Connected { get; } = new BoolAddressInitial(8, "MAIN.bPowderBox1Connected");

        public static BoolAddressInitial bPowderBox2Connected { get; } = new BoolAddressInitial(8, "MAIN.bPowderBox2Connected");

        public static BoolAddressInitial bRedLight { get; } = new BoolAddressInitial(8, "MAIN.bRedLight");

        public static BoolAddressInitial bProtectionCoverClosed { get; } = new BoolAddressInitial(8, "MAIN.bProtectionCoverClosed");

        public static BoolAddressInitial bPower { get; } = new BoolAddressInitial(8, "MAIN.bPower");

        public static IntAddressInitial iPowderHeightBuildBox { get; } = new IntAddressInitial(32, "MAIN.iPowderHeightBuildBox");

        public static IntAddressInitial iPowderHeightPowderBox1 { get; } = new IntAddressInitial(32, "MAIN.iPowderHeightPowderBox1");

        public static IntAddressInitial iPowderHeightPowderBox2 { get; } = new IntAddressInitial(32, "MAIN.iPowderHeightPowderBox2");

        public static FloatAddressInitial rGlueHeight { get; } = new FloatAddressInitial(32, "MAIN.rGlueHeight");

        public static BoolAddressInitial bGreen { get; } = new BoolAddressInitial(8, "MAIN.bGreen");

        public static BoolAddressInitial bYellow { get; } = new BoolAddressInitial(8, "MAIN.bYellow");

        public static BoolAddressInitial bRed { get; } = new BoolAddressInitial(8, "MAIN.bRed");

        public static StringAddressInitial sFileName { get; } = new StringAddressInitial(648, "MAIN.sFileName");

        public static BoolAddressInitial bOpenFile { get; } = new BoolAddressInitial(8, "MAIN.bOpenFile");

        public static BoolAddressInitial bStepForward { get; } = new BoolAddressInitial(8, "MAIN.bStepForward");

        public static BoolAddressInitial bRun { get; } = new BoolAddressInitial(8, "MAIN.bRun");

        public static BoolAddressInitial TestBoolIn { get; } = new BoolAddressInitial(8, "MAIN.TestBoolIn");

        public static ShortAddressInitial rGlueLevel { get; } = new ShortAddressInitial(16, "MAIN.rGlueLevel");

        public static FloatAddressInitial rPosition { get; } = new FloatAddressInitial(32, "MAIN.rPosition");

        public static BoolAddressInitial TestBoolOut { get; } = new BoolAddressInitial(8, "MAIN.TestBoolOut");

        public static BoolAddressInitial LightOn { get; } = new BoolAddressInitial(8, "MAIN.LightOn");

        public static BoolAddressInitial IsLightOn { get; } = new BoolAddressInitial(8, "MAIN.IsLightOn");

        public static BoolAddressInitial TrigSequenceRequest { get; } = new BoolAddressInitial(8, "MAIN.TrigSequenceRequest");

        public static IntAddressInitial TestIntIn { get; } = new IntAddressInitial(32, "MAIN.TestIntIn");

        public static IntAddressInitial TestIntOut { get; } = new IntAddressInitial(32, "MAIN.TestIntOut");

        public static StringAddressInitial TestStringIn { get; } = new StringAddressInitial(648, "MAIN.TestStringIn");

        public static StringAddressInitial TestStringOut { get; } = new StringAddressInitial(648, "MAIN.TestStringOut");

        public static BoolAddressInitial SequenceRequest { get; } = new BoolAddressInitial(8, "MAIN.SequenceRequest");

        public static BoolAddressInitial SequenceDone { get; } = new BoolAddressInitial(8, "MAIN.SequenceDone");

        public static IntAddressInitial SequenceError { get; } = new IntAddressInitial(32, "MAIN.SequenceError");

        public static BoolAddressInitial lXAxisEnable { get; } = new BoolAddressInitial(8, "MAIN.lXAxisEnable");
    }

    public static class Position_Control
    {
        public static BoolAddressInitial bPositioningDone2 { get; } = new BoolAddressInitial(8, "Position_Control.bPositioningDone2");

        public static BoolAddressInitial bPositioningDone1 { get; } = new BoolAddressInitial(8, "Position_Control.bPositioningDone1");

        public static DoubleAddressInitial lrServo1CurrentPos { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo1CurrentPos");

        public static DoubleAddressInitial lrServo2CurrentPos { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo2CurrentPos");

        public static DoubleAddressInitial lrServo1Position1 { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo1Position1");

        public static DoubleAddressInitial lrServo2Position1 { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo2Position1");

        public static DoubleAddressInitial lrServo1Position2 { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo1Position2");

        public static DoubleAddressInitial lrServo2Position2 { get; } = new DoubleAddressInitial(64, "Position_Control.lrServo2Position2");

    }

    public static class BackForthSequence
    {
        public static BoolAddressInitial start_ui { get; } = new BoolAddressInitial(8, "BackForthSequence.start_ui");
    }

    public static class Constants
    {
        public static BoolAddressInitial bLittleEndian { get; } = new BoolAddressInitial(8, "Constants.bLittleEndian");

        public static BoolAddressInitial bSimulationMode { get; } = new BoolAddressInitial(8, "Constants.bSimulationMode");

        public static BoolAddressInitial bFPUSupport { get; } = new BoolAddressInitial(8, "Constants.bFPUSupport");

        public static ShortAddressInitial nRegisterSize { get; } = new ShortAddressInitial(16, "Constants.nRegisterSize");

        public static UshortAddressInitial nPackMode { get; } = new UshortAddressInitial(16, "Constants.nPackMode");

        public static UintAddressInitial RuntimeVersionNumeric { get; } = new UintAddressInitial(32, "Constants.RuntimeVersionNumeric");

        public static UintAddressInitial CompilerVersionNumeric { get; } = new UintAddressInitial(32, "Constants.CompilerVersionNumeric");
    }

    public static class TwinCAT_SystemInfoVarList
    {
    }

}
#pragma warning restore SA1300 // Element must begin with upper-case letter
#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single class

