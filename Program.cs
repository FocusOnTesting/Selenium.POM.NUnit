using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortalRegression.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        // Setup ChromeOptions and Open Chrome Browser
        ChromeOptions options = new ChromeOptions();

        //options.BrowserVersion = "125";
        options.AcceptInsecureCertificates = true;

        options.AddExcludedArgument("enable-automation");

        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);

        options.AddArgument("--start-maximized");
        options.AddArgument("--log-level=1");
        //options.AddArgument("disable-popup-blocking");
        //options.AddArgument("disable-extensions");
        //options.AddArgument("disable-infobars");
        //options.AddArgument("disable-notifications");
        //options.AddArgument("disable-web-security");
        //options.AddArgument("disable-browser-side-navigation");
        //options.AddArgument("disable-gpu");
        //options.AddArgument("always-authorize-plugins");
        //options.AddArgument("load-extension=src/main/resources/chrome load stopper");
        //options.AddUserProfilePreference("download.default_directory", "path");

        IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        string url = "http://horse.industryconnect.io/";
        string userName = "hari";
        string password = "123123";

        LoginPage loginPage = new LoginPage();
        loginPage.LoginAction(driver, url, userName, password);

        TMPage tMPage = new TMPage();
        tMPage.CreateTimeRecord(driver);

        tMPage.EditTimeRecord(driver);

        tMPage.DeleteTimeRecord(driver);

        //driver.Close();
    }



}