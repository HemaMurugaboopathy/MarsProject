using Mars.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V118.Browser;
using TechTalk.SpecFlow;

namespace Mars
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }

}
