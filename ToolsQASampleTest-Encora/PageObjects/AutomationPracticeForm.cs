using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ToolsQASampleTest_Encora.BaseClasses;
using ToolsQASampleTest_Encora.ComponentHelper;
using OpenQA.Selenium.Interactions;
using ToolsQASampleTest_Encora.Settings;

namespace ToolsQASampleTest_Encora.PageObjects
{
    public class AutomationPracticeForm : PageBase
    {
        private IWebDriver driver;
        private Actions Action;

        public AutomationPracticeForm(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Webelements

        private IWebElement FormTitle => driver.FindElement(By.XPath("//*[contains(text(), \"Student Registration Form\")]"));
        private IList<IWebElement> FormLabel_List => driver.FindElements(By.XPath("//label[@class = 'form-label']"));
        private IWebElement Input_FirstName => driver.FindElement(By.Id("firstName"));
        private IWebElement Input_LastName => driver.FindElement(By.Id("lastName"));
        private IWebElement Input_EmailAddress => driver.FindElement(By.Id("userEmail"));
        private IWebElement Input_MobileNumber => driver.FindElement(By.XPath("//input[@placeholder = \"Mobile Number\"]"));
        private IWebElement Input_CurrentAddress => driver.FindElement(By.XPath("//textarea[@id=\"currentAddress\"]"));
        private IWebElement Input_Subject => driver.FindElement(By.Id("subjectsInput"));
        private IList<IWebElement> RadioBtn_Gender => driver.FindElements(By.XPath("//label[starts-with(@for, \"gender-radio\")]"));
        private IList<IWebElement> CheckBox_Hobbies => driver.FindElements(By.XPath("//label[starts-with(@for, \"hobbies-checkbox\")]"));
        private IWebElement Select_State => driver.FindElement(By.Id("state"));
        private IWebElement Select_City => driver.FindElement(By.Id("city"));
        private IWebElement Btn_Submit => driver.FindElement(By.XPath("//button[@class = 'btn btn-primary']"));
        private IWebElement Overlay_FormInfo => driver.FindElement(By.ClassName("modal-content"));
        private IList<IWebElement> Overlay_FormLabelList => driver.FindElements(By.XPath("//table//tbody"));

        #endregion

        #region Actions 

        public string ReturnFormName()
        {
            return FormTitle.Text;
        }

        public void EnterFirstName(string firstName)
        {
            Input_FirstName.SendKeys(firstName);
        }

        public void EnterLastName(string LastName)
        {
            Input_LastName.SendKeys(LastName);
        }

        public void EnterEmailAddress(string emailID)
        {
            Input_EmailAddress.SendKeys(emailID);
        }

        public void SelectGender(string gender)
        {
            foreach (var genderOption in RadioBtn_Gender)
            {
                if (genderOption.Text == gender)
                    genderOption.Click();

                else
                    return;
            }
        }

        public void EnterMobileNumber(string mobNumber)
        {
            Input_MobileNumber.SendKeys(mobNumber);
        }

        public void EnterSubject(string subject)
        {
            Input_Subject.SendKeys(subject);
        }

        public void SelectHobbies(string hobbie)
        {
            foreach (var hobbieOption in CheckBox_Hobbies)
            {
                if (hobbieOption.Text == hobbie)
                    hobbieOption.Click();

                else
                    return;
            }
        }

        public void EnterCurrentAddress(string currentAddress)
        {
            Input_CurrentAddress.SendKeys(currentAddress);
        }

        public void SelectState(string state)
        {
            Action = new Actions(driver);
            Action.Click(Select_State).SendKeys(state).SendKeys(Keys.Enter).Build().Perform();                  
        }

        public void SelectCity(string city)
        {
            Action.Click(Select_City).SendKeys(city).SendKeys(Keys.Enter).Build().Perform();
        }

        public void SubmitForm()
        {
            Btn_Submit.Click();
        }

        public bool IsOverlayPresnt()
        {
            driver.SwitchTo().ActiveElement();

            if (GenericHelper.IsElementPresent(Overlay_FormInfo))
                return true;
            else
                return false;
        }

        public bool Compare_FormLabel_OverlayLabels()
        {
            int index = 0;
            foreach(var label in FormLabel_List)
            {
                if(label.Text == Overlay_FormLabelList[index].Text)
                {
                    index = index + 2;
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
