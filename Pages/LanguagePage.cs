using Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Collections.Specialized.BitVector32;

namespace Mars.Pages
{
    public class LanguagePage: CommonDriver
    {
        public void Create_LanguagePage(string language, string languageLevel)
        {
            Thread.Sleep(3000);

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

        public void Edit_LanguagePage(string existingLanguage, string existinLanguageLevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]", 5);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]"));
            editIcon.Click();
        }


        public void Update_LanguagePage(string newLanguage, string newLanguageLevel)
        {
            Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            //Edit the language in the textbox
            IWebElement editTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            editTextbox.Clear();
            editTextbox.SendKeys(newLanguage);

            //Edit the language level 
            IWebElement languageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
            SelectElement editlevelOption = new SelectElement(languageLevelDropdown);
            editlevelOption.SelectByValue(newLanguageLevel);

            //Update the language
            IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateButton.Click();
            Thread.Sleep(2000);

        }

        public string getUpdatedLanguage(string language)
        {
            try
            {
                IWebElement newLanguage = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[contains(text(), '{language}')]"));
                return newLanguage.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public string getUpdatedLanguageLevel(string languageLevel)
        {
            IWebElement newLanguageLevel = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']"));
            return newLanguageLevel.Text;
        }
        public void Cancel_LanguagePage(string existingLanguage)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]", 5);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]"));
            editIcon.Click();

            //Cancel the language
            IWebElement cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            cancelButton.Click();
        }
        public string getCancelLanguage()
        {
            IWebElement cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            return cancelButton.Text;
        }
        public void Delete_LanguagePage(string existingLanguage)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]", 5);

            //Delete the language
            IWebElement deleteIcon = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]"));
            deleteIcon.Click();
            Thread.Sleep(3000);
        }

        public string deleteLanguage(string language)
        {
            try
            {
                IWebElement deleteLanguage = driver.FindElement(By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
                return deleteLanguage.Text;
            }
            catch(NoSuchElementException)
            {
                return null;
            }
        }
    }
}
