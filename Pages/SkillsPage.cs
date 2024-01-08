using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Mars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class SkillsPage: CommonDriver
    {
        public void Create_SkillsPage(string skills, string skillLevel)
        {
            Thread.Sleep(2000);

            //Create add new button
            IWebElement addnewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addnewButton.Click();

            //Enter skill in place holder
            IWebElement addTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addTextbox.SendKeys(skills);

            //Click dropdown icon to select level
            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            Thread.Sleep(2000);

            SelectElement chooseskillLevel = new SelectElement(skillLevelDropdown);
            chooseskillLevel.SelectByValue(skillLevel);
          

            //Click to add in list
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(2000);
        }

        public string getSkills(string skills)
        {
            IWebElement newSkills = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skills}']"));
            return newSkills.Text;
        }

        public string getSkillLevel(string skillLevel)
        {
            IWebElement newskillLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']"));
            return newskillLevel.Text;
        }
        public void Edit_SkillsPage(string existingSkills, String existingSkillsLevel)
        {
            Thread.Sleep(2000);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[1]"));
            editIcon.Click();

        }
        public void Update_SkillsPage(string newSkills, string newSkillLevel)
        { 
            //Edit the skill in the textbox
            IWebElement editTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            editTextbox.Clear();
            editTextbox.SendKeys(newSkills);
            Thread.Sleep(2000);

            //Edit the skill level 
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement editlevelOption = new SelectElement(languageLevelDropdown);
            editlevelOption.SelectByValue(newSkillLevel);

            //Update the skill
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(2000);
        }

        public string getUpdatedSkills(string skills)
        {
            try
            {
                IWebElement newSkills = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[contains(text(), '{skills}')]"));
                return newSkills.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public string getUpdatedSkillLevel(string skillLevel)
        {
            IWebElement newSkillLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']"));
            return newSkillLevel.Text;
        }

        public void Delete_SkillsPage(string existingSkills)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[2]", 5);

            //Delete the skill
            IWebElement deleteIcon = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[2]"));
            deleteIcon.Click();
            
        }

        public string deleteSkills(string skills)
        {
            try
            {
                IWebElement deleteSkills = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{skills}']"));
                return deleteSkills.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public string getMessage()
        {
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);

            //Get the text message after entering skill and skill level
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            return successMessage.Text;
        }
    }
}
