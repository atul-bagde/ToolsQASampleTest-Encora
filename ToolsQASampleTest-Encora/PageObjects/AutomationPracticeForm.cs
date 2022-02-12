using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ToolsQASampleTest_Encora.BaseClasses;
using ToolsQASampleTest_Encora.ComponentHelper;

namespace ToolsQASampleTest_Encora.PageObjects
{
    public class AutomationPracticeForm : PageBase
    {
        private IWebDriver driver;

        public AutomationPracticeForm(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Webelements

        private IWebElement FormTitle => driver.FindElement(By.XPath("//*[contains(text(), \"Student Registration Form\")]"));
        private IWebElement Input_FirstName => driver.FindElement(By.Id("firstName"));
        private IWebElement Input_LastName => driver.FindElement(By.Id("lastName"));
        private IWebElement Input_EmailAddress => driver.FindElement(By.Id("userEmail"));
        private IWebElement Input_MobileNumber => driver.FindElement(By.XPath("//input[@placeholder = \"Mobile Number\"]"));
        private IWebElement Input_CurrentAddress => driver.FindElement(By.XPath("//input[@placeholder = \"Current Address\"]"));
        private IWebElement Input_Subject => driver.FindElement(By.Id("subjectsInput"));
        private IList<IWebElement> RadioBtn_Gender => driver.FindElements(By.TagName("radio"));
        private IList<IWebElement> CheckBox_Hobbies => driver.FindElements(By.TagName("checkbox"));
        private IWebElement DatePicker_DOB => driver.FindElement(By.Id("dateOfBirthInput"));        
        private IWebElement Select_State => driver.FindElement(By.Id("state"));        
        private IWebElement Select_City => driver.FindElement(By.Id("city"));     
        private IWebElement Btn_Submit => driver.FindElement(By.Id("submit"));
        private IWebElement Overlay_FormInfo => driver.FindElement(By.ClassName("modal-content"));
        private IList<IWebElement> Overlay_FormLabelList => driver.FindElements(By.TagName("tr"));

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

        }

        public void SelectDate()
        {

        }

        public void EnterSubject(string subject)
        {
            Input_Subject.SendKeys(subject);    
        }

        public void SelectHobbies()
        {

        }

        public void EnterCurrentAddress(string currentAddress)
        {
            Input_CurrentAddress.SendKeys(currentAddress);
        }

        public void SubmitForm()
        {
            Btn_Submit.Click();
        }

        public bool IsOverlayPresnt()
        {
            driver.SwitchTo().ActiveElement();

            if(GenericHelper.IsElementPresent(Overlay_FormInfo))
                return true;
            else 
                return false;
        }

        #endregion
    }
}
