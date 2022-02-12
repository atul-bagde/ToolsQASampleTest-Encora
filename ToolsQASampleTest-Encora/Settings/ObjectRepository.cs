using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ToolsQASampleTest_Encora.Interface;
using ToolsQASampleTest_Encora.PageObjects;

namespace ToolsQASampleTest_Encora.Settings
{
    public class ObjectRepository
    {
        public static IWebDriver Driver { get; set; }
        public static IConfig Config { get; set; }

        public static AutomationPracticeForm AutomationPracticeForm;
    }
}
