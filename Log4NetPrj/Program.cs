using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Log4NetPrj
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            LogTraceMessage();
            LogDebugMessage();
            LogInfoMessage();
            LogWarningMessage();
            LogErrorMessage();
            LogFatalErrorMessage();
            if (Log.IsDebugEnabled)
            {
                //Log.Debug(m => m("Calling an expensive-slow argument: {0}", "bb"));
                Console.Write("true");
            }
            Console.ReadLine();
        }

        private static void LogTraceMessage()
        {
            //Log.Trace("This is a trace...");
        }

        private static void LogDebugMessage()
        {
            Log.Debug("This is a debug message...");
        }

        private static void LogInfoMessage()
        {
            Log.Info("This is an info message...");
        }

        private static void LogWarningMessage()
        {
            Log.Warn("This is a warning...");
        }

        private static void LogErrorMessage()
        {
            Log.Error("This is an error...");
        }

        private static void LogFatalErrorMessage()
        {
            Log.Fatal("This is a fatal error...");
        }
    }
}
