using Mars.Utilities;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Mars
{
    [Binding]
    public sealed class Bootstrap : CommonDriver
    {

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }

}
