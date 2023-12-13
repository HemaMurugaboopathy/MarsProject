using Mars.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using static System.Collections.Specialized.BitVector32;

internal class Program
{
    private static void Main(string[] args)
    {
        //Navigate to URL
        IWebDriver driver = new ChromeDriver();

        LoginPage loginPageobj = new LoginPage();
        loginPageobj.LoginActions(driver);


    }
}