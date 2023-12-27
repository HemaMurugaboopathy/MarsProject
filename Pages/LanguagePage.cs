using Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mars.Pages
{
    public class LanguagePage: CommonDriver
    {
        public void Create_LanguagePage(string language, string languageLevel)
        {

            //Create add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));
            addNewButton.Click();

            //Enter language in place holder
            IWebElement addTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
            addTextbox.SendKeys(language);

            //Click dropdown icon to select level
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement selectlevelOption = new SelectElement(languageLevelDropdown);
            selectlevelOption.SelectByValue(languageLevel);

            //Click to add in list
            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();
            Thread.Sleep(2000);
        }

        public string getLanguage(string language)
        {
            IWebElement newLanguage = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
            return newLanguage.Text;
        }

        public string getLanguageLevel(string languageLevel)
        {
            IWebElement newLanguageLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']"));
            return newLanguageLevel.Text;
        }

        public void Edit_LanguagePage(string language, string languagelevel)
        {
            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editIcon.Click();

            //Edit the language in the textbox
            IWebElement editTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            editTextbox.Clear();
            editTextbox.SendKeys("Java");
            Thread.Sleep(2000);

            //Edit the language level 
            IWebElement editLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
            editLevel.Click();

            //Update the language
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(2000);
        }
        public string editLanguage()
        {
            IWebElement editLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
            return editLanguage.Text;
        }

        public string editLanguageLevel()
        {
            IWebElement editLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
            return editLanguageLevel.Text;
        }

        public void Delete_LanguagePage(string language)
        {
            //Delete the language
            IWebElement deleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteIcon.Click();
            Thread.Sleep(3000);
        }

        public string deleteLanguage()
        {
            IWebElement deleteLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            return deleteLanguage.Text;
        }
    }
}
