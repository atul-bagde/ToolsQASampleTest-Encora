using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToolsQASampleTest_Encora.ComponentHelper
{
    public class ComboBoxHelper
    {
        private static SelectElement select;

        public static void SelectElement(int index, IWebElement Element)
        {
            select = new SelectElement(GenericHelper.GetElement(Element));
            select.SelectByIndex(index);
        }

        public static void SelectElement(string text, IWebElement Element)
        {
            select = new SelectElement(GenericHelper.GetElement(Element));
            select.SelectByText(text);
        }

        public static void SelectElementByValue(string value, IWebElement Element)
        {
            select = new SelectElement(GenericHelper.GetElement(Element));
            select.SelectByValue(value);
        }
    }
}
