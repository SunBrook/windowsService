using System;
using System.Configuration;

namespace DataDispose.Library.Tools
{
    public static class AppSettings
    {
        public static T GetValue<T>(string key)
        {
            var resultStr = ConfigurationManager.AppSettings[key];
            T result = (T)Convert.ChangeType(resultStr, typeof(T));
            return result;
        }
    }
}
