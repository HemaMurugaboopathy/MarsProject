using Mars.Pages;
using OpenQA.Selenium.Chrome;
using Mars.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions: CommonDriver
    {
        LoginPage loginPageobj = new LoginPage();
        LanguagePage languagePageobj = new LanguagePage();

        [Given(@"I logged in Mars portal successfully")]
        public void GivenILoggedInMarsPortalSuccessfully()
        {
            loginPageobj.LoginActions();
        }

        [When(@"I create a new '([^']*)' and '([^']*)'")]
        public void WhenICreateANewAnd(string language, string languagelevel)
        {
            languagePageobj.Create_LanguagePage(language, languagelevel);
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
        public void WhenIEditAnExistingAnd(string language, string languagelevel)
        {
            languagePageobj.Edit_LanguagePage(language, languagelevel);
        }

        [Then(@"the '([^']*)' and '([^']*)' should be updated successfully")]
        public void ThenTheAndShouldBeUpdatedSuccessfully(string language, string languagelevel)
        {
            string editLanguage = languagePageobj.editLanguage();
            string editLanguageLevel = languagePageobj.editLanguageLevel();

            Assert.That(editLanguage == language, "Actual language and expected language do not match");
            Assert.That(editLanguageLevel == languagelevel, "Actual language level and expected language level do not match");
        }

        [When(@"I delete an existing '([^']*)' and '([^']*)'")]
        public void WhenIDeleteAnExistingAnd(string language)
        {
            languagePageobj.Delete_LanguagePage(language);
        }

        [Then(@"the '([^']*)' and '([^']*)' should be deleted successfully")]
        public void ThenTheAndShouldBeDeletedSuccessfully(string language)
        {
            string deleteLanguage = languagePageobj.deleteLanguage();

            Assert.That(deleteLanguage != language, "Language get deleted successfully");
        }
    }
}
