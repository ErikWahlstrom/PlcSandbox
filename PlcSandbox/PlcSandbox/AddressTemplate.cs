namespace GeneratedAddress
{
	using TwinCatAdsCommunication.Address;
	public static class MC
	{
		public static BoolAddress bDone { get; } = new BoolAddress(8, "MC.bDone", 4117832);
		public static BoolAddress bError { get; } = new BoolAddress(8, "MC.bError", 4117840);
		public static BoolAddress bBusyToHmi { get; } = new BoolAddress(8, "MC.bBusyToHmi", 4117848);
		public static FloatAddress lrActPosToHmi { get; } = new FloatAddress(32, "MC.lrActPosToHmi", 4117856);
		public static UintAddress iErrorId { get; } = new UintAddress(32, "MC.iErrorId", 4140832);
		public static DoubleAddress lrActPos { get; } = new DoubleAddress(64, "MC.lrActPos", 4142784);
		public static BoolAddress startPulse { get; } = new BoolAddress(8, "MC.startPulse", 4142848);
		public static BoolAddress bResetServo { get; } = new BoolAddress(8, "MC.bResetServo", 4142856);
		public static DoubleAddress lrVelocity { get; } = new DoubleAddress(64, "MC.lrVelocity", 4142912);
		public static DoubleAddress rAcceleration { get; } = new DoubleAddress(64, "MC.rAcceleration", 4142976);
		public static DoubleAddress lrAcceleration { get; } = new DoubleAddress(64, "MC.lrAcceleration", 4143040);
		public static DoubleAddress lrDeceleration { get; } = new DoubleAddress(64, "MC.lrDeceleration", 4143104);

		public static class AxisRef
		{
		}
	}
	public static class MC_2
	{
		public static BoolAddress bDone { get; } = new BoolAddress(8, "MC_2.bDone", 4142864);
		public static BoolAddress bError { get; } = new BoolAddress(8, "MC_2.bError", 4142872);
		public static FloatAddress lrActPos { get; } = new FloatAddress(32, "MC_2.lrActPos", 4142880);
		public static UintAddress iErrorId { get; } = new UintAddress(32, "MC_2.iErrorId", 4143264);
		public static BoolAddress bBusyToHmi { get; } = new BoolAddress(8, "MC_2.bBusyToHmi", 4161312);
		public static BoolAddress startPulse { get; } = new BoolAddress(8, "MC_2.startPulse", 4161320);
		public static BoolAddress bResetServo { get; } = new BoolAddress(8, "MC_2.bResetServo", 4161328);
		public static DoubleAddress lrVelocity { get; } = new DoubleAddress(64, "MC_2.lrVelocity", 4163264);
		public static DoubleAddress rAcceleration { get; } = new DoubleAddress(64, "MC_2.rAcceleration", 4163328);
		public static DoubleAddress lrAcceleration { get; } = new DoubleAddress(64, "MC_2.lrAcceleration", 4163392);
		public static DoubleAddress lrDeceleration { get; } = new DoubleAddress(64, "MC_2.lrDeceleration", 4163456);

		public static class AxisRef
		{
		}
	}
	public static class Global_Variables
	{
		public static UshortAddress AMSPORT_LOGGER { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_LOGGER", 4096224);
		public static UshortAddress AMSPORT_EVENTLOG { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_EVENTLOG", 4096240);
		public static UshortAddress AMSPORT_R0_RTIME { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_RTIME", 4096256);
		public static UshortAddress AMSPORT_R0_IO { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_IO", 4096272);
		public static UshortAddress AMSPORT_R0_NC { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_NC", 4096288);
		public static UshortAddress AMSPORT_R0_NCSAF { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_NCSAF", 4096304);
		public static UshortAddress AMSPORT_R0_NCSVB { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_NCSVB", 4096320);
		public static UshortAddress AMSPORT_R0_ISG { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_ISG", 4096336);
		public static UshortAddress AMSPORT_R0_CNC { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_CNC", 4096352);
		public static UshortAddress AMSPORT_R0_LINE { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_LINE", 4096368);
		public static UshortAddress AMSPORT_R0_PLC { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_PLC", 4096384);
		public static UshortAddress AMSPORT_R0_PLC_RTS1 { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_PLC_RTS1", 4096400);
		public static UshortAddress AMSPORT_R0_PLC_RTS2 { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_PLC_RTS2", 4096416);
		public static UshortAddress AMSPORT_R0_PLC_RTS3 { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_PLC_RTS3", 4096432);
		public static UshortAddress AMSPORT_R0_PLC_RTS4 { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_PLC_RTS4", 4096448);
		public static UshortAddress AMSPORT_R0_CAM { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_CAM", 4096464);
		public static UshortAddress AMSPORT_R0_CAMTOOL { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R0_CAMTOOL", 4096480);
		public static UshortAddress AMSPORT_R3_SYSSERV { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R3_SYSSERV", 4096496);
		public static UshortAddress AMSPORT_R3_SCOPESERVER { get; } = new UshortAddress(16, "Global_Variables.AMSPORT_R3_SCOPESERVER", 4096512);
		public static UshortAddress ADSSTATE_INVALID { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_INVALID", 4096528);
		public static UshortAddress ADSSTATE_IDLE { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_IDLE", 4096544);
		public static UshortAddress ADSSTATE_RESET { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_RESET", 4096560);
		public static UshortAddress ADSSTATE_INIT { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_INIT", 4096576);
		public static UshortAddress ADSSTATE_START { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_START", 4096592);
		public static UshortAddress ADSSTATE_RUN { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_RUN", 4096608);
		public static UshortAddress ADSSTATE_STOP { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_STOP", 4096624);
		public static UshortAddress ADSSTATE_SAVECFG { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_SAVECFG", 4096640);
		public static UshortAddress ADSSTATE_LOADCFG { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_LOADCFG", 4096656);
		public static UshortAddress ADSSTATE_POWERFAILURE { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_POWERFAILURE", 4096672);
		public static UshortAddress ADSSTATE_POWERGOOD { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_POWERGOOD", 4096688);
		public static UshortAddress ADSSTATE_ERROR { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_ERROR", 4096704);
		public static UshortAddress ADSSTATE_SHUTDOWN { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_SHUTDOWN", 4096720);
		public static UshortAddress ADSSTATE_SUSPEND { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_SUSPEND", 4096736);
		public static UshortAddress ADSSTATE_RESUME { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_RESUME", 4096752);
		public static UshortAddress ADSSTATE_CONFIG { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_CONFIG", 4096768);
		public static UshortAddress ADSSTATE_RECONFIG { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_RECONFIG", 4096784);
		public static UshortAddress ADSSTATE_STOPPING { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_STOPPING", 4096800);
		public static UshortAddress ADSSTATE_INCOMPATIBLE { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_INCOMPATIBLE", 4096816);
		public static UshortAddress ADSSTATE_EXCEPTION { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_EXCEPTION", 4096832);
		public static UshortAddress ADSSTATE_MAXSTATES { get; } = new UshortAddress(16, "Global_Variables.ADSSTATE_MAXSTATES", 4096848);
		public static UintAddress ADSIGRP_SYMTAB { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYMTAB", 4096864);
		public static UintAddress ADSIGRP_SYMNAME { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYMNAME", 4096896);
		public static UintAddress ADSIGRP_SYMVAL { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYMVAL", 4096928);
		public static UintAddress ADSIGRP_SYM_HNDBYNAME { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_HNDBYNAME", 4096960);
		public static UintAddress ADSIGRP_SYM_VALBYNAME { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_VALBYNAME", 4096992);
		public static UintAddress ADSIGRP_SYM_VALBYHND { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_VALBYHND", 4097024);
		public static UintAddress ADSIGRP_SYM_RELEASEHND { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_RELEASEHND", 4097056);
		public static UintAddress ADSIGRP_SYM_INFOBYNAME { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAME", 4097088);
		public static UintAddress ADSIGRP_SYM_VERSION { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_VERSION", 4097120);
		public static UintAddress ADSIGRP_SYM_INFOBYNAMEEX { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_INFOBYNAMEEX", 4097152);
		public static UintAddress ADSIGRP_SYM_DOWNLOAD { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_DOWNLOAD", 4097184);
		public static UintAddress ADSIGRP_SYM_UPLOAD { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_UPLOAD", 4097216);
		public static UintAddress ADSIGRP_SYM_UPLOADINFO { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYM_UPLOADINFO", 4097248);
		public static UintAddress ADSIGRP_SYMNOTE { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_SYMNOTE", 4097280);
		public static UintAddress ADSIGRP_IOIMAGE_RWIB { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIB", 4097312);
		public static UintAddress ADSIGRP_IOIMAGE_RWIX { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIX", 4097344);
		public static UintAddress ADSIGRP_IOIMAGE_RISIZE { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RISIZE", 4097376);
		public static UintAddress ADSIGRP_IOIMAGE_RWOB { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOB", 4097408);
		public static UintAddress ADSIGRP_IOIMAGE_RWOX { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RWOX", 4097440);
		public static UintAddress ADSIGRP_IOIMAGE_ROSIZE { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_ROSIZE", 4097472);
		public static UintAddress ADSIGRP_IOIMAGE_CLEARI { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARI", 4097504);
		public static UintAddress ADSIGRP_IOIMAGE_CLEARO { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_CLEARO", 4097536);
		public static UintAddress ADSIGRP_IOIMAGE_RWIOB { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_IOIMAGE_RWIOB", 4097568);
		public static UintAddress ADSIGRP_DEVICE_DATA { get; } = new UintAddress(32, "Global_Variables.ADSIGRP_DEVICE_DATA", 4097600);
		public static UintAddress ADSIOFFS_DEVDATA_ADSSTATE { get; } = new UintAddress(32, "Global_Variables.ADSIOFFS_DEVDATA_ADSSTATE", 4097632);
		public static UintAddress ADSIOFFS_DEVDATA_DEVSTATE { get; } = new UintAddress(32, "Global_Variables.ADSIOFFS_DEVDATA_DEVSTATE", 4097664);
		public static UintAddress SYSTEMSERVICE_OPENCREATE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_OPENCREATE", 4097696);
		public static UintAddress SYSTEMSERVICE_OPENREAD { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_OPENREAD", 4097728);
		public static UintAddress SYSTEMSERVICE_OPENWRITE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_OPENWRITE", 4097760);
		public static UintAddress SYSTEMSERVICE_CREATEFILE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_CREATEFILE", 4097792);
		public static UintAddress SYSTEMSERVICE_CLOSEHANDLE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_CLOSEHANDLE", 4097824);
		public static UintAddress SYSTEMSERVICE_FOPEN { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FOPEN", 4097856);
		public static UintAddress SYSTEMSERVICE_FCLOSE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FCLOSE", 4097888);
		public static UintAddress SYSTEMSERVICE_FREAD { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FREAD", 4097920);
		public static UintAddress SYSTEMSERVICE_FWRITE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FWRITE", 4097952);
		public static UintAddress SYSTEMSERVICE_FSEEK { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FSEEK", 4097984);
		public static UintAddress SYSTEMSERVICE_FTELL { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FTELL", 4098016);
		public static UintAddress SYSTEMSERVICE_FGETS { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FGETS", 4098048);
		public static UintAddress SYSTEMSERVICE_FPUTS { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FPUTS", 4098080);
		public static UintAddress SYSTEMSERVICE_FSCANF { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FSCANF", 4098112);
		public static UintAddress SYSTEMSERVICE_FPRINTF { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FPRINTF", 4098144);
		public static UintAddress SYSTEMSERVICE_FEOF { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FEOF", 4098176);
		public static UintAddress SYSTEMSERVICE_FDELETE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FDELETE", 4098208);
		public static UintAddress SYSTEMSERVICE_FRENAME { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_FRENAME", 4098240);
		public static UintAddress SYSTEMSERVICE_MKDIR { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_MKDIR", 4098272);
		public static UintAddress SYSTEMSERVICE_RMDIR { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_RMDIR", 4098304);
		public static UintAddress SYSTEMSERVICE_REG_HKEYLOCALMACHINE { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_REG_HKEYLOCALMACHINE", 4098336);
		public static UintAddress SYSTEMSERVICE_SENDEMAIL { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_SENDEMAIL", 4098368);
		public static UintAddress SYSTEMSERVICE_TIMESERVICES { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_TIMESERVICES", 4098400);
		public static UintAddress SYSTEMSERVICE_STARTPROCESS { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_STARTPROCESS", 4098432);
		public static UintAddress SYSTEMSERVICE_CHANGENETID { get; } = new UintAddress(32, "Global_Variables.SYSTEMSERVICE_CHANGENETID", 4098464);
		public static UintAddress TIMESERVICE_DATEANDTIME { get; } = new UintAddress(32, "Global_Variables.TIMESERVICE_DATEANDTIME", 4098496);
		public static UintAddress TIMESERVICE_SYSTEMTIMES { get; } = new UintAddress(32, "Global_Variables.TIMESERVICE_SYSTEMTIMES", 4098528);
		public static UintAddress TIMESERVICE_RTCTIMEDIFF { get; } = new UintAddress(32, "Global_Variables.TIMESERVICE_RTCTIMEDIFF", 4098560);
		public static UintAddress TIMESERVICE_ADJUSTTIMETORTC { get; } = new UintAddress(32, "Global_Variables.TIMESERVICE_ADJUSTTIMETORTC", 4098592);
		public static UintAddress TIMESERVICE_TIMEZONINFORMATION { get; } = new UintAddress(32, "Global_Variables.TIMESERVICE_TIMEZONINFORMATION", 4098624);
		public static UintAddress ADSLOG_MSGTYPE_HINT { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_HINT", 4098656);
		public static UintAddress ADSLOG_MSGTYPE_WARN { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_WARN", 4098688);
		public static UintAddress ADSLOG_MSGTYPE_ERROR { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_ERROR", 4098720);
		public static UintAddress ADSLOG_MSGTYPE_LOG { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_LOG", 4098752);
		public static UintAddress ADSLOG_MSGTYPE_MSGBOX { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_MSGBOX", 4098784);
		public static UintAddress ADSLOG_MSGTYPE_RESOURCE { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_RESOURCE", 4098816);
		public static UintAddress ADSLOG_MSGTYPE_STRING { get; } = new UintAddress(32, "Global_Variables.ADSLOG_MSGTYPE_STRING", 4098848);
		public static ByteAddress BOOTDATAFLAGS_RETAIN_LOADED { get; } = new ByteAddress(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_LOADED", 4098880);
		public static ByteAddress BOOTDATAFLAGS_RETAIN_INVALID { get; } = new ByteAddress(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_INVALID", 4098888);
		public static ByteAddress BOOTDATAFLAGS_RETAIN_REQUESTED { get; } = new ByteAddress(8, "Global_Variables.BOOTDATAFLAGS_RETAIN_REQUESTED", 4098896);
		public static ByteAddress BOOTDATAFLAGS_PERSISTENT_LOADED { get; } = new ByteAddress(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_LOADED", 4098904);
		public static ByteAddress BOOTDATAFLAGS_PERSISTENT_INVALID { get; } = new ByteAddress(8, "Global_Variables.BOOTDATAFLAGS_PERSISTENT_INVALID", 4098912);
		public static ByteAddress SYSTEMSTATEFLAGS_BSOD { get; } = new ByteAddress(8, "Global_Variables.SYSTEMSTATEFLAGS_BSOD", 4098920);
		public static ByteAddress SYSTEMSTATEFLAGS_RTVIOLATION { get; } = new ByteAddress(8, "Global_Variables.SYSTEMSTATEFLAGS_RTVIOLATION", 4098928);
		public static ByteAddress nWatchdogTime { get; } = new ByteAddress(8, "Global_Variables.nWatchdogTime", 4098936);
		public static UintAddress FOPEN_MODEREAD { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODEREAD", 4098944);
		public static UintAddress FOPEN_MODEWRITE { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODEWRITE", 4098976);
		public static UintAddress FOPEN_MODEAPPEND { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODEAPPEND", 4099008);
		public static UintAddress FOPEN_MODEPLUS { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODEPLUS", 4099040);
		public static UintAddress FOPEN_MODEBINARY { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODEBINARY", 4099072);
		public static UintAddress FOPEN_MODETEXT { get; } = new UintAddress(32, "Global_Variables.FOPEN_MODETEXT", 4099104);
		public static ShortAddress TCEVENTFLAG_PRIOCLASS { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_PRIOCLASS", 4099360);
		public static ShortAddress TCEVENTFLAG_FMTSELF { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_FMTSELF", 4099376);
		public static ShortAddress TCEVENTFLAG_LOG { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_LOG", 4099392);
		public static ShortAddress TCEVENTFLAG_MSGBOX { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_MSGBOX", 4099408);
		public static ShortAddress TCEVENTFLAG_SRCID { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_SRCID", 4099424);
		public static ShortAddress TCEVENTFLAG_AUTOFMTALL { get; } = new ShortAddress(16, "Global_Variables.TCEVENTFLAG_AUTOFMTALL", 4099440);
		public static ShortAddress TCEVENTSTATE_INVALID { get; } = new ShortAddress(16, "Global_Variables.TCEVENTSTATE_INVALID", 4099456);
		public static ShortAddress TCEVENTSTATE_SIGNALED { get; } = new ShortAddress(16, "Global_Variables.TCEVENTSTATE_SIGNALED", 4099472);
		public static ShortAddress TCEVENTSTATE_RESET { get; } = new ShortAddress(16, "Global_Variables.TCEVENTSTATE_RESET", 4099488);
		public static ShortAddress TCEVENTSTATE_CONFIRMED { get; } = new ShortAddress(16, "Global_Variables.TCEVENTSTATE_CONFIRMED", 4099504);
		public static ShortAddress TCEVENTSTATE_RESETCON { get; } = new ShortAddress(16, "Global_Variables.TCEVENTSTATE_RESETCON", 4099520);
		public static ShortAddress TCEVENT_SRCNAMESIZE { get; } = new ShortAddress(16, "Global_Variables.TCEVENT_SRCNAMESIZE", 4099536);
		public static ShortAddress TCEVENT_FMTPRGSIZE { get; } = new ShortAddress(16, "Global_Variables.TCEVENT_FMTPRGSIZE", 4099552);
		public static DoubleAddress PI { get; } = new DoubleAddress(64, "Global_Variables.PI", 4099584);
		public static UintAddress MAX_STRING_LENGTH { get; } = new UintAddress(32, "Global_Variables.MAX_STRING_LENGTH", 4099680);
		public static DoubleAddress DEFAULT_HOME_POSITION { get; } = new DoubleAddress(64, "Global_Variables.DEFAULT_HOME_POSITION", 4107136);
		public static DoubleAddress DEFAULT_BACKLASHVALUE { get; } = new DoubleAddress(64, "Global_Variables.DEFAULT_BACKLASHVALUE", 4107200);
	}
	public static class MAIN
	{
		public static BoolAddress bBuildingBoxConnected { get; } = new BoolAddress(8, "MAIN.bBuildingBoxConnected", 4114944);
		public static BoolAddress bPowderBox1Connected { get; } = new BoolAddress(8, "MAIN.bPowderBox1Connected", 4114952);
		public static BoolAddress bPowderBox2Connected { get; } = new BoolAddress(8, "MAIN.bPowderBox2Connected", 4114960);
		public static BoolAddress bRedLight { get; } = new BoolAddress(8, "MAIN.bRedLight", 4114968);
		public static BoolAddress bProtectionCoverClosed { get; } = new BoolAddress(8, "MAIN.bProtectionCoverClosed", 4114976);
		public static BoolAddress bPower { get; } = new BoolAddress(8, "MAIN.bPower", 4114984);
		public static IntAddress iPowderHeightBuildBox { get; } = new IntAddress(32, "MAIN.iPowderHeightBuildBox", 4115008);
		public static IntAddress iPowderHeightPowderBox1 { get; } = new IntAddress(32, "MAIN.iPowderHeightPowderBox1", 4115040);
		public static IntAddress iPowderHeightPowderBox2 { get; } = new IntAddress(32, "MAIN.iPowderHeightPowderBox2", 4115072);
		public static FloatAddress rGlueHeight { get; } = new FloatAddress(32, "MAIN.rGlueHeight", 4115104);
		public static BoolAddress bGreen { get; } = new BoolAddress(8, "MAIN.bGreen", 4115616);
		public static BoolAddress bYellow { get; } = new BoolAddress(8, "MAIN.bYellow", 4115624);
		public static BoolAddress bRed { get; } = new BoolAddress(8, "MAIN.bRed", 4115632);
		public static StringAddress sFileName { get; } = new StringAddress(648, "MAIN.sFileName", 4115640);
		public static BoolAddress bOpenFile { get; } = new BoolAddress(8, "MAIN.bOpenFile", 4116288);
		public static BoolAddress bStepForward { get; } = new BoolAddress(8, "MAIN.bStepForward", 4116296);
		public static BoolAddress bRun { get; } = new BoolAddress(8, "MAIN.bRun", 4116320);
		public static BoolAddress TestBoolIn { get; } = new BoolAddress(8, "MAIN.TestBoolIn", 4116328);
		public static ShortAddress rGlueLevel { get; } = new ShortAddress(16, "MAIN.rGlueLevel", 4116336);
		public static FloatAddress rPosition { get; } = new FloatAddress(32, "MAIN.rPosition", 4116352);
		public static BoolAddress TestBoolOut { get; } = new BoolAddress(8, "MAIN.TestBoolOut", 4116384);
		public static BoolAddress LightOn { get; } = new BoolAddress(8, "MAIN.LightOn", 4116392);
		public static BoolAddress IsLightOn { get; } = new BoolAddress(8, "MAIN.IsLightOn", 4116400);
		public static BoolAddress TrigSequenceRequest { get; } = new BoolAddress(8, "MAIN.TrigSequenceRequest", 4116408);
		public static IntAddress TestIntIn { get; } = new IntAddress(32, "MAIN.TestIntIn", 4116416);
		public static IntAddress TestIntOut { get; } = new IntAddress(32, "MAIN.TestIntOut", 4116448);
		public static StringAddress TestStringIn { get; } = new StringAddress(648, "MAIN.TestStringIn", 4116480);
		public static StringAddress TestStringOut { get; } = new StringAddress(648, "MAIN.TestStringOut", 4117128);
		public static BoolAddress SequenceRequest { get; } = new BoolAddress(8, "MAIN.SequenceRequest", 4117776);
		public static BoolAddress SequenceDone { get; } = new BoolAddress(8, "MAIN.SequenceDone", 4117784);
		public static IntAddress SequenceError { get; } = new IntAddress(32, "MAIN.SequenceError", 4117792);
		public static BoolAddress lXAxisEnable { get; } = new BoolAddress(8, "MAIN.lXAxisEnable", 4117824);
	}
	public static class Position_Control
	{
		public static BoolAddress bPositioningDone2 { get; } = new BoolAddress(8, "Position_Control.bPositioningDone2", 4161336);
		public static BoolAddress bPositioningDone1 { get; } = new BoolAddress(8, "Position_Control.bPositioningDone1", 4163616);
		public static DoubleAddress lrServo1CurrentPos { get; } = new DoubleAddress(64, "Position_Control.lrServo1CurrentPos", 4163648);
		public static DoubleAddress lrServo2CurrentPos { get; } = new DoubleAddress(64, "Position_Control.lrServo2CurrentPos", 4163712);
		public static DoubleAddress lrServo1Position1 { get; } = new DoubleAddress(64, "Position_Control.lrServo1Position1", 4163776);
		public static DoubleAddress lrServo2Position1 { get; } = new DoubleAddress(64, "Position_Control.lrServo2Position1", 4163840);
		public static DoubleAddress lrServo1Position2 { get; } = new DoubleAddress(64, "Position_Control.lrServo1Position2", 4163904);
		public static DoubleAddress lrServo2Position2 { get; } = new DoubleAddress(64, "Position_Control.lrServo2Position2", 4163968);
	}
	public static class BackForthSequence
	{
		public static BoolAddress start_ui { get; } = new BoolAddress(8, "BackForthSequence.start_ui", 4163624);
	}
	public static class Constants
	{
		public static BoolAddress bLittleEndian { get; } = new BoolAddress(8, "Constants.bLittleEndian", 4164264);
		public static BoolAddress bSimulationMode { get; } = new BoolAddress(8, "Constants.bSimulationMode", 4164272);
		public static BoolAddress bFPUSupport { get; } = new BoolAddress(8, "Constants.bFPUSupport", 4164280);
		public static ShortAddress nRegisterSize { get; } = new ShortAddress(16, "Constants.nRegisterSize", 4171456);
		public static UshortAddress nPackMode { get; } = new UshortAddress(16, "Constants.nPackMode", 4171472);
		public static UintAddress RuntimeVersionNumeric { get; } = new UintAddress(32, "Constants.RuntimeVersionNumeric", 4171488);
		public static UintAddress CompilerVersionNumeric { get; } = new UintAddress(32, "Constants.CompilerVersionNumeric", 4171520);
	}
	public static class TwinCAT_SystemInfoVarList
	{
	}
}

