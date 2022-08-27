using log4net;
using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DataDispose.Library.Tools
{
    public class LogHelper
    {
        public static readonly ILog Log = LogManager.GetLogger("InfoOrErrorLogger");

        public static void Info(string write)
        {
            Log.Debug($"Info:\n{write}\n\n");
        }
        public static void Error(string write)
        {
            Log.Debug($"Error:\n{write}\n\n");
        }
        public static void Error(string write, Exception ex)
        {
            Log.Debug($"Error:\n{write}\n错误:\n{ex}\n\n");
        }
    }
}
