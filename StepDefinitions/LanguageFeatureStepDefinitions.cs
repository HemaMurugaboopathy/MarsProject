using Mars.Pages;
using OpenQA.Selenium.Chrome;
using Mars.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageobj = new LoginPage();
        LanguagePage languagePageobj = new LanguagePage();

        [Given(@"I logged in Mars portal successfully")]
        public void GivenILoggedInMarsPortalSuccessfully()
        {
            loginPageobj.LoginActions();
        }

        [When(@"I delete all records in the language page")]
        public void WhenIDeleteAllRecordsInTheLanguagePage()
        {
            languagePageobj.Delete_All();
        }


        [When(@"I create a new '([^']*)' and '([^']*)'")]
        public void WhenICreateANewAnd(string language, string languageLevel)
        {
            languagePageobj.Create_LanguagePage(language, languageLevel);
        }

        [Then(@"the '([^']*)' and '([^']*)' should be created successfully")]
        public void ThenTheAndShouldBeCreatedSuccessfully(string language, string languageLevel)
        {
            string newLanguage = languagePageobj.getLanguage(language);
            string newLanguageLevel = languagePageobj.getLanguageLevel(languageLevel);

            Assert.That(newLanguage == language, "Actual language and expected language do not match");
            Assert.That(newLanguageLevel == languageLevel, "Actual language level and expected language level do not match");
        }

        [When(@"I edit an existing '([^']*)' and '([^']*)'")]
        public void WhenIEditAnExistingAnd(string existingLanguage, string existingLanguageLevel)
        {
            languagePageobj.Edit_LanguagePage(existingLanguage, existingLanguageLevel);
        }

        [Then(@"the '([^']*)' and '([^']*)' should be updated successfully")]
        public void ThenTheAndShouldBeUpdatedSuccessfully(string newLanguage, string newLanguageLevel)
        {
            languagePageobj.Update_LanguagePage(newLanguage, newLanguageLevel);

            string updatedLanguage = languagePageobj.getLanguage(newLanguage);
            string updatedLanguageLevel = languagePageobj.getLanguageLevel(newLanguageLevel);

            Assert.That(updatedLanguage == newLanguage, "Actual language and expected language do not match");
            Assert.That(updatedLanguageLevel == newLanguageLevel, "Actual language level and expected language level do not match");
        }

        [When(@"I delete an existing '([^']*)'")]
        public void WhenIDeleteAnExisting(string language)
        {
            languagePageobj.Delete_LanguagePage(language);
        }

        [Then(@"the '([^']*)' should be shown on the language page")]
        public void ThenTheShouldBeShownOnTheSkillPage(string expectedMessage)
        {
            string actualMessage = languagePageobj.getMessage();

            Assert.That(expectedMessage == actualMessage, "Expected message occurred successfully");
        }

        [Then(@"I have to cancel by clicking cancel button")]
        public void ThenIHaveToCancelByClickingCancelButton()
        {
            string cancelLanguage = languagePageobj.getCancelLanguage();
            Assert.That(string.IsNullOrEmpty(cancelLanguage), Is.True, "Cancelled successfully");
        }


    }   
}
