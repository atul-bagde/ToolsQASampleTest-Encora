using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium;
using ToolsQASampleTest_Encora.Settings;

namespace ToolsQASampleTest_Encora.ComponentHelper
{
    public class GenericHelper
    {
        public static bool IsElementPresent(IWebElement Element)
        {
            try
            {
                return Element.Enabled && Element.Displayed;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public static IWebElement GetElement(IWebElement Element)
        {
            if (IsElementPresent(Element))
            {
                return Element;
            }

            else
            {
                throw new NoSuchElementException("Element not found" + Element.ToString());
            }
        }

        public static WebDriverWait GetWebDriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            return wait;
        }

        public static bool WaitForElementToLoad(IWebElement element, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(timeout);
            var flag = wait.Until(WaitForElementToLoadFunc(element));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout()));
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForElementToLoadFunc(IWebElement Element)
        {
            return ((x) =>
            {
                if (Element.Enabled && Element.Displayed)
                    return true;
                else
                    return false;
            });
        }


        public static bool WaitForElementVsible(IWebElement element, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(timeout);
            var flag = wait.Until(WaitForElementVsibleFunc(element));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout()));
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForElementVsibleFunc(IWebElement element)
        {
            return ((x) =>
            {
                if (element.Displayed)
                    return true;
                else
                    return false;
            });
        }

        public static bool FindBySafe(IWebElement element)
        {
            try
            {
                return IsElementPresent(element);
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
