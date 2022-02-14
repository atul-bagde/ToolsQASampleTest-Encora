using ToolsQASampleTest_Encora.PageObjects;
using ToolsQASampleTest_Encora.Settings;
using ToolsQASampleTest_Encora.ComponentHelper;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolsQASampleTest_Encora.Configurations;

namespace ToolsQASampleTest_Encora.StepDefinations
{
    [Binding]
    public sealed class AutomationFormTest
    {
        [Given(@"I navigate to Automation testing form page")]
        public void GivenINavigateToAutomationTestingFormPage()
        {
            NavigationHelper.NavigateToURL("https://demoqa.com/automation-practice-form");
            ObjectRepository.AutomationPracticeForm = new AutomationPracticeForm(ObjectRepository.Driver);
            Assert.AreEqual(ObjectRepository.AutomationPracticeForm.ReturnFormName(), AssertionElements.FormTitle);
        }

        [Given(@"I fill up ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""")]
        public void GivenIFillUpAnd(string fName, string Lname, string email, string gender, string mobile, string dob, string subject, string hobbies, string address, string state, string city)
        {
            ObjectRepository.AutomationPracticeForm.EnterFirstName(fName);
            ObjectRepository.AutomationPracticeForm.EnterLastName(Lname);
            ObjectRepository.AutomationPracticeForm.EnterEmailAddress(email);
            ObjectRepository.AutomationPracticeForm.SelectGender(gender);
            ObjectRepository.AutomationPracticeForm.EnterMobileNumber(mobile);
            ObjectRepository.AutomationPracticeForm.EnterSubject(subject);
            ObjectRepository.AutomationPracticeForm.SelectHobbies(hobbies);
            ObjectRepository.AutomationPracticeForm.EnterCurrentAddress(address);
            ObjectRepository.AutomationPracticeForm.SelectState(state);
            ObjectRepository.AutomationPracticeForm.SelectCity(city);
        }

        [Given(@"I click Submit")]
        public void GivenIClickSubmit()
        {
            ObjectRepository.AutomationPracticeForm.SubmitForm();
        }

        [Then(@"An Overlay with submitted information of form should appear")]
        public void ThenAnOverlayWithSubmittedInformationOfFormShouldAppear()
        {
            Assert.IsTrue(ObjectRepository.AutomationPracticeForm.IsOverlayPresnt());
        }

        [Then(@"All the Labels from the form should be present on the Overlay")]
        public void ThenAllTheLabelsFromTheFormShouldBePresentOnTheOverlay()
        {
            Assert.IsTrue(ObjectRepository.AutomationPracticeForm.Compare_FormLabel_OverlayLabels());
        }
    }
}