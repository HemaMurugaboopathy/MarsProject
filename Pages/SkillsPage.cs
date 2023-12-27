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
        public void Create_SkillsPage(string skill, string skilllevel)
        {
            //Create add new button
            IWebElement addnewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addnewButton.Click();

            //Enter skill in place holder
            IWebElement addTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            addTextbox.SendKeys("SQL");

            //Click dropdown icon to select level
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            element.Click();
            Thread.Sleep(2000);

            //Choose level to be selected
            IWebElement selectlevelOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
            selectlevelOption.Click();

            //Click to add in list
            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);
        }
        public void Edit_SkillsPage(IWebDriver driver)
        {

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editIcon.Click();

            //Edit the skill in the textbox
            IWebElement editTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            editTextbox.Clear();
            editTextbox.SendKeys("Java");
            Thread.Sleep(2000);

            //Update the skill
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(2000);
        }
        public void Delete_SkillsPage(IWebDriver driver)
        {

            //Delete the skill
            IWebElement deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteIcon.Click();
            Thread.Sleep(3000);
        }
    }
}
