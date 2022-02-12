using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQASampleTest_Encora.Interface;
using System.Configuration;
using ToolsQASampleTest_Encora.Settings;

namespace ToolsQASampleTest_Encora.Configurations
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);

            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }

            catch (Exception)
            {
                return null;
            }
        }

        public int GetElementLoadTimeout()
        {
            string elementTimeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (elementTimeout == null)
                return 30;
            else
                return Convert.ToInt32(elementTimeout);
        }

        public int GetPageLoadTimeout()
        {
            string pageTimeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (pageTimeout == null)
                return 20;
            else
                return Convert.ToInt32(pageTimeout);
        }

        public string GetWebAppURL()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.URL);
        }
    }
}
