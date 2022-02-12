using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQASampleTest_Encora.Configurations;

namespace ToolsQASampleTest_Encora.Interface
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        String GetWebAppURL();
        int GetPageLoadTimeout();
        int GetElementLoadTimeout();
    }
}
