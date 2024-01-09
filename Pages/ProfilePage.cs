using Mars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class ProfilePage: CommonDriver
    {
        public void GoToskillsPage()
        {
            // Navigate to Skills tab
            IWebElement SkillsOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            SkillsOption.Click();

        }
    }
}
