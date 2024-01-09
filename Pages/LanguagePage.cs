using Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mars.Pages
{
    public class LanguagePage: CommonDriver
    {
        public void Delete_All()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//i[@class='remove icon']", 8);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }

            IReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='first']//i[@class='remove icon']"));
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void Create_LanguagePage(string language, string languageLevel)
             {
            //Create add new button
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));
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
        }

        public string getLanguage(string language)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{language}']", 5);

            IWebElement newLanguage = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{language}']"));
            return newLanguage.Text;
        }

        public string getLanguageLevel(string languageLevel)
        {
            IWebElement newLanguageLevel = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']"));
            return newLanguageLevel.Text;
        }

        public void Edit_LanguagePage(string existingLanguage, string existinLanguageLevel)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]", 5);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]"));
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
        }
        
        public string getCancelLanguage()
        {
            try
            { 
            IWebElement cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            return cancelButton.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public void Delete_LanguagePage(string existingLanguage)
        {
            Wait.WaitToBeClickable(driver, "XPath", $"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]", 5);

            //Delete the language
            IWebElement deleteIcon = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]"));
            deleteIcon.Click();
        }

        public string getMessage()
        {
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);

            //Get the text message after entering language and language level
            IWebElement successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            return successMessage.Text;
        }
    }
}
