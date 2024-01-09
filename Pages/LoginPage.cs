using Mars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class LoginPage: CommonDriver
    {
        public void LoginActions()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 3);

            //Navigate to Sign In
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();

            //Entering email
            IWebElement emailTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailTextbox.SendKeys("h.prabhaharan@gmail.com");

            //Enter password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("123456");

            //Click login
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(2000);
        }     
    }
}
