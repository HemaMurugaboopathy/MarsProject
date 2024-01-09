using Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mars.Pages
{
    public class SkillsPage: CommonDriver
    {
        public void Delete_All()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//i[@class='remove icon']", 8);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }

            IReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }
        public void Create_SkillsPage(string skills, string skillLevel)
        {
            //Create add new button
            IWebElement addnewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addnewButton.Click();

            //Enter skill in place holder
            IWebElement addTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            addTextbox.SendKeys(skills);

            //Click dropdown icon to select level
            IWebElement skillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));

            SelectElement chooseskillLevel = new SelectElement(skillLevelDropdown);
            chooseskillLevel.SelectByValue(skillLevel);
          

            //Click to add in list
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
        }

        public string getSkills(string skills)
        {
            Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skills}']", 5);

            IWebElement newSkills = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skills}']"));
            return newSkills.Text;
        }

        public string getSkillLevel(string skillLevel)
        {
            Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']", 2);

            IWebElement newskillLevel = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']"));
            return newskillLevel.Text;
        }

        public void Edit_SkillsPage(string existingSkills, String existingSkillsLevel)
        {
            
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[1]", 5);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[1]"));
            editIcon.Click();

        }

        public void Update_SkillsPage(string newSkills, string newSkillLevel)
        {
            Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Add Skill']", 5);

            //Edit the skill in the textbox
            IWebElement editTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            editTextbox.Clear();
            editTextbox.SendKeys(newSkills);

            //Edit the skill level 
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement editlevelOption = new SelectElement(languageLevelDropdown);
            editlevelOption.SelectByValue(newSkillLevel);

            //Update the skill
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
        }

        public string getUpdatedSkills(string skills)
        {
            try
            {
                IWebElement newSkills = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[contains(text(), '{skills}')]"));
                return newSkills.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public void Delete_SkillsPage(string existingSkill)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkill}']/following-sibling::td[last()]/span[@class='button'][2]", 5);

            //Delete the skill
            IWebElement deleteIcon = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkill}']/following-sibling::td[last()]/span[@class='button'][2]"));
            deleteIcon.Click();
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