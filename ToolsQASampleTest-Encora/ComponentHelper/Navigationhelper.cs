using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ToolsQASampleTest_Encora.Settings;

namespace ToolsQASampleTest_Encora.ComponentHelper
{
    public class NavigationHelper
    {
        public static void NavigateToURL(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}
