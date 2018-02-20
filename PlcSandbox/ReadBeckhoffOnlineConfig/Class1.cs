namespace ReadBeckhoffOnlineConfig
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using NUnit.Framework;
    using TcEventLoggerAdsProxyLib;
    using TwinCAT;
    using TwinCAT.Ads;
    using TwinCAT.Ads.SumCommand;
    using TwinCAT.Ads.TypeSystem;
    using TwinCAT.Ads.ValueAccess;
    using TwinCAT.TypeSystem;

    public class Class1
    {
        [Test]
        public void TestClass()
        {
            var beckhoffClient = new TcAdsClient();

            // beckhoffClient.Connect("192.168.100.1.1.1", 851); //"164.4.4.112.1.1", 853);
            beckhoffClient.Connect("164.4.4.112.1.1", 853); // Release-datorn
            var isConnected = beckhoffClient.IsConnected;
            var loader = beckhoffClient.CreateSymbolInfoLoader();
            var symbols = loader.GetSymbols(true);

            // var symbol = loader.FindSymbol("BackForthSequence.start_ui");
            // var value = beckhoffClient.ReadSymbol(symbol);
            // var value2 = beckhoffClient.ReadSymbol("BackForthSequence.start_ui", typeof(bool), true);
            // foreach (TcAdsSymbolInfo tcAdsSymbolInfo in symbols)
            // {
            //    Console.WriteLine(tcAdsSymbolInfo.Name);
            // }
        }

        [Test]
        public void CopyPasteTestDynamic()
        {
            using (TcAdsClient client = new TcAdsClient())
            {
                client.Synchronize = false;

                // Connect to the target device
                client.Connect("164.4.4.112.1.1", 853);

                // Usage of "dynamic" Type and Symbols (>= .NET4 only)
                SymbolLoaderSettings settings = new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree);
                IAdsSymbolLoader dynLoader = (IAdsSymbolLoader) SymbolLoaderFactory.Create(client, settings);

                // Set the Default setting for Notifications
                dynLoader.DefaultNotificationSettings = new AdsNotificationSettings(AdsTransMode.OnChange, 200, 2000);

                // Get the Symbols (Dynamic Symbols)
                dynamic dynamicSymbols = ((IDynamicSymbolLoader) dynLoader).SymbolsDynamic;

                dynamic adsPort = dynamicSymbols.TwinCAT_SystemInfoVarList._AppInfo.AdsPort;

                // Access Main Symbol with Dynamic Language Runtime support (DLR)
                // Dynamically created property "Main"
                // dynamic symMain = dynamicSymbols.Main;

                // Main is an 'VirtualSymbol' / Organizational unit that doesn't have a value
                // Calling ReadValue is not allowed
                // bool test = symMain.HasValue;
                // dynamic invalid = symMain.ReadValue();

                // Reading TaskInfo Value
                // With calling ReadValue() a 'snapshot' of the Symbols Instance is taken
                dynamic vTaskInfoArray = dynamicSymbols.TwinCAT_SystemInfoVarList._TaskInfo.ReadValue();

                // Getting the Snapshot time in UTC format
                DateTime timeStamp1 = vTaskInfoArray.UtcTimeStamp;

                // Getting TaskInfo Symbol for Task 1
                dynamic symTaskInfo1 = dynamicSymbols.TwinCAT_SystemInfoVarList._TaskInfo[1];

                // Getting CycleCount Symbol
                dynamic symCycleCount = symTaskInfo1.CycleCount;

                // Take Snapshot value of the ApplicationInfo struct
                dynamic vAppInfo = dynamicSymbols.TwinCAT_SystemInfoVarList._AppInfo.ReadValue();

                // Get the UTC Timestamp of the snapshot
                DateTime timeStamp2 = vAppInfo.UtcTimeStamp;

                // Access the ProjectName of the ApplicationInfo Snapshot (type-safe!)
                string projectNameValue = vAppInfo.ProjectName;

                // Reading the CycleCount Value
                uint cycleCountValue = symTaskInfo1.CycleCount.ReadValue(); // Taking a Value Snapshot

                // Registering for dynamic "ValueChanged" events for the Values
                // Using Default Notification settings
                symCycleCount.ValueChanged += new EventHandler<ValueChangedArgs>(cycleCount_ValueChanged);

                // Override default notification settings
                symTaskInfo1.NotificationSettings = new AdsNotificationSettings(AdsTransMode.Cyclic, 500, 0);

                // Register for ValueChanged event.
                symTaskInfo1.ValueChanged +=
                    new EventHandler<ValueChangedArgs>(taskInfo1Value_ValueChanged); // Struct Type

                Thread.Sleep(10000); // Sleep main thread for 10 Seconds
            }

            Console.WriteLine("CycleCount Changed events received: {0}", _cycleCountEvents);
            Console.WriteLine("taskInfo1 Changed events received: {0}", _taskInfo1Events);
        }

        [Test]
        public void CopyPasteTestStatic()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press [Enter] for start:");

            // logger.Active = false;
            Stopwatch stopper = new Stopwatch();

            stopper.Start();

            using (AdsSession session = new AdsSession(new AmsNetId("164.4.4.112.1.1"), 853))
            {
                // client.Synchronize = false;

                // Connect the AdsClient to the device target.
                var connection = session.Connect();

                // Creates the Symbol Objects as hierarchical tree
                SymbolLoaderSettings settings = new SymbolLoaderSettings(SymbolsLoadMode.VirtualTree, ValueAccessMode.IndexGroupOffsetPreferred);
                var symbolLoader = session.SymbolServer.Symbols; // SymbolLoaderFactory.Create(client, settings);

                //// Dump Datatypes from Target Device
                // Console.WriteLine(string.Format("Dumping '{0}' DataTypes:", symbolLoader.DataTypes.Count));
                // foreach (IDataType type in symbolLoader.DataTypes)
                // {
                //    Console.WriteLine(type);
                // }
                // Console.WriteLine("");

                // Dump Symbols from target device
                Console.WriteLine("Dumping '{0}' Symbols:", symbolLoader.Count);
                WriteSymbolTree(symbolLoader, (AdsConnection) connection);
            }

            stopper.Stop();
            TimeSpan elapsed = stopper.Elapsed;

            Console.WriteLine(string.Empty);
        }

        private static void WriteSymbolTree(ReadOnlySymbolCollection symbolLoaderSymbols, AdsConnection connection)
        {
            Console.WriteLine("\t");
            foreach (var symbolLoaderSymbol in symbolLoaderSymbols)
            {
                Console.Write(symbolLoaderSymbol.InstancePath);

                // var symbolInfo = client.ReadSymbolInfo(symbolLoaderSymbol.InstancePath);
                // var symbolInfor = new symbolin
                try
                {
                    if (symbolLoaderSymbol is ISymbol info)
                    {

                        if (info.Category == DataTypeCategory.Primitive)
                        {
                            SymbolCollection coll = new SymbolCollection() { symbolLoaderSymbol };
                            SumSymbolRead readCommand = new SumSymbolRead(connection, coll);
                            object[] values = readCommand.Read();
                            Console.Write(": " + values.FirstOrDefault());
                        }
                        else
                        {
                            Console.Write(": " + info.Category);
                        }
                    }
                    else
                    {
                        Console.Write(": -");
                    }
                }
                catch (Exception e)
                {
                    var type =  symbolLoaderSymbol.DataType.GetType();
                    var symbol = connection.ReadSymbol(symbolLoaderSymbol.InstanceName, symbolLoaderSymbol.DataType.GetType(), true);
                    Console.Write("Exception: "+ e);
                }

                Console.WriteLine(string.Empty);
                if (symbolLoaderSymbol.SubSymbols.Any())
                {
                    Console.WriteLine("__________subs to " + symbolLoaderSymbol.InstancePath);
                    WriteSymbolTree(symbolLoaderSymbol.SubSymbols, connection);
                }
            }
        }

        static void cycleCount_ValueChanged(object sender, ValueChangedArgs e)
        {
            lock (_notificationSynchronizer)
            {
                Interlocked.Increment(ref _cycleCountEvents);

                // val is a type safe value of int!
                dynamic val = e.Value;
                uint intVal = val;

                DateTime changedTime = e.UtcRtime.ToLocalTime(); // Convert UTC to local time
                Console.WriteLine("CycleCount changed to: {0}, TimeStamp: {1}", intVal, changedTime.ToString("HH:mm:ss:fff"));
            }
        }

        static int _taskInfo1Events = 0;
        static object _notificationSynchronizer = new object();
        static int _cycleCountEvents = 0;

        [Test]
        public void LoggTest()
        {
            var eventlogger = new TcEventLogger();
            eventlogger.Connect("192.168.100.1.1.1");
            var isConnected = eventlogger.IsConnected;
            var events = eventlogger.GetLoggedEvents(10000);
            var lksdjf = eventlogger.ActiveAlarms;
            foreach (TcLoggedEvent eEvent in events)
            {
                Console.WriteLine(eEvent.SourceName);
            }
        }

        /// <summary>
        /// Handler function for the TaskInfo ValueChanged event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        static void taskInfo1Value_ValueChanged(object sender, ValueChangedArgs e)
        {
            lock (_notificationSynchronizer)
            {
                Interlocked.Increment(ref _taskInfo1Events);
                dynamic val = e.Value;
                DateTime changedTime = e.UtcRtime.ToLocalTime(); // Convert to local time

                // Val is a during Runtime created struct type and contains
                // the same Properties as related PLC object.
                uint cycleTime = val.CycleTime;
                Console.WriteLine("TaskInfo1Value changed TimeStamp: {0}", changedTime.ToString("HH:mm:ss:fff"));
            }
            }

    }
}
