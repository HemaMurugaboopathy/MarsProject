using Mars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mars.Pages
{
    public class LanguagePage: CommonDriver
    {
        //Finding elements by ID
        private IWebElement AddNewButtonElement => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));
        private IWebElement AddTextBoxElement => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement LanguageLevelDropDownElement => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButtonElement => driver.FindElement(By.XPath("//input[@value='Add']"));

        private Func<string, By> NewLanguageXPath = language => By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{language}']");

        private Func<string, IWebElement> NewLanguageLevelElement = languageLevel => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{languageLevel}']"));

        private Func<string, By> EditIconXPath = existingLanguage => By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[1]");
        private IWebElement EditTextBoxElement => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement UpdateButtonElement => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement CancelButtonElement => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        private Func<string, By> DeleteIconXPath = existingLanguage => By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]");
        private IWebElement SuccessMessageElement => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

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
            AddNewButtonElement.Click();

            //Enter language in place holder
            AddTextBoxElement.SendKeys(language);

            //Click dropdown icon to select level
            SelectElement selectlevelOption = new SelectElement(LanguageLevelDropDownElement);
            selectlevelOption.SelectByValue(languageLevel);

            //Click to add in list
            AddButtonElement.Click();
        }
        public string getLanguage(string language)
        {
            By xPath = NewLanguageXPath(language);
            Wait.WaitToBeClickable(driver, xPath, 5);

            IWebElement newLanguage = driver.FindElement(xPath);
            return newLanguage.Text;
        }

        public string getLanguageLevel(string languageLevel)
        {
            return NewLanguageLevelElement(languageLevel).Text;
        }

        public void Edit_LanguagePage(string existingLanguage, string existingLanguageLevel)
        {
            By xPath = EditIconXPath(existingLanguage); 
            Wait.WaitToBeClickable(driver, xPath, 5);

            //Click edit icon 
            IWebElement editIcon = driver.FindElement(xPath);
            editIcon.Click();
        }
    public void Update_LanguagePage(string newLanguage, string newLanguageLevel)
        {
            Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Add Language']", 5);
            
            //Edit the language in the textbox
            EditTextBoxElement.Clear();
            EditTextBoxElement.SendKeys(newLanguage);

            //Edit the language level 
            SelectElement editlevelOption = new SelectElement(LanguageLevelDropDownElement);
            editlevelOption.SelectByValue(newLanguageLevel);

            //Update the language
            UpdateButtonElement.Click();
        }
        
        public string getCancelLanguage()
        {
            try
            { 
                return CancelButtonElement.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public void Delete_LanguagePage(string existingLanguage)
        {
            By xPath = DeleteIconXPath(existingLanguage);
            Wait.WaitToBeClickable(driver, xPath, 5);

            //Delete the language
            IWebElement deleteIcon = driver.FindElement(xPath);
            deleteIcon.Click();
        }
        public string getMessage()
        {
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);

            //Get the text message after entering language and language level
            return SuccessMessageElement.Text;
        }
    }
}
