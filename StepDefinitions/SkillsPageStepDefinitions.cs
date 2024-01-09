using Mars.Pages;
using Mars.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SkillsPageStepDefinitions : CommonDriver
    {
        ProfilePage profilePageobj = new ProfilePage();
        SkillsPage skillsPageobj = new SkillsPage();

        [When(@"I navigate to skill page")]
        public void WhenINavigateToSkillPage()
        {
            profilePageobj.GoToskillsPage();
        }

        [Then(@"I delete all records in the skills page")]
        public void ThenIDeleteAllRecordsInTheSkillsPage()
        {
            skillsPageobj.Delete_All();
        }


        [Then(@"I create a new '([^']*)' and '([^']*)'")]
        public void ThenICreateANewAnd(string skills, string skillLevel)
        {
            skillsPageobj.Create_SkillsPage(skills, skillLevel);
        }

        [Then(@"the '([^']*)' and '([^']*)' created successfully")]
        public void ThenTheAndCreatedSuccessfully(string skills, string skillLevel)
        {
            string newSkills = skillsPageobj.getSkills(skills);
            string newSkillLevel = skillsPageobj.getSkillLevel(skillLevel);

            Assert.That(newSkills == skills, "Actual language and expected language do not match");
            Assert.That(newSkillLevel == skillLevel, "Actual language level and expected language level do not match");

        }

        [Then(@"I edit an existing '([^']*)' and '([^']*)'")]
        public void ThenIEditAnExistingAnd(string existingSkill, string existingSkillLevel)
        {
            skillsPageobj.Edit_SkillsPage(existingSkill, existingSkillLevel);
        }

        [Then(@"the '([^']*)' and '([^']*)' should be updated successfully for skills page")]
        public void ThenTheAndShouldBeUpdatedSuccessfullyForSkillsPage(string newSkill, string newSkillLevel)
        {
            skillsPageobj.Update_SkillsPage(newSkill, newSkillLevel);

            string updatedSkill = skillsPageobj.getSkills(newSkill);
            string updatedSkillLevel = skillsPageobj.getSkillLevel(newSkillLevel);

            Assert.That(updatedSkill == newSkill, "Actual language and expected language do not match");
            Assert.That(updatedSkillLevel == newSkillLevel, "Actual language level and expected language level do not match");
        }

        [Then(@"I delete an existing '([^']*)' in skill page")]
        public void ThenIDeleteAnExistingInSkillPage(string existingSkill)
        {
            skillsPageobj.Delete_SkillsPage(existingSkill);
        }

        [Then(@"the '([^']*)' should be shown on the skill page")]
        public void ThenTheShouldBeShownOnTheSkillPage(string expectedMessage)
        {
            string actualMessage = skillsPageobj.getMessage();

            Assert.That(expectedMessage == actualMessage, "Skill get deleted successfully");
        }


        [Then(@"the '([^']*)' should not to be created")]
        public void ThenTheShouldNotToBeCreated(string newSkills)
        {
            string updatedSkills = skillsPageobj.getUpdatedSkills(newSkills);


            Assert.That(updatedSkills == null, "Empty text box not created");
        }

    }
}
