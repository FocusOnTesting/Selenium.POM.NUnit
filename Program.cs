using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        options.AddArgument("disable-popup-blocking");
        options.AddArgument("disable-extensions");
        options.AddArgument("disable-infobars");
        options.AddArgument("disable-notifications");
        options.AddArgument("disable-web-security");
        options.AddArgument("disable-browser-side-navigation");
        options.AddArgument("--start-maximized");


        //options.AddArgument("disable-gpu");
        //options.AddArgument("always-authorize-plugins");
        //options.AddArgument("load-extension=src/main/resources/chrome load stopper");
        //options.AddUserProfilePreference("download.default_directory", "path");

        IWebDriver driver = new ChromeDriver(options);

        // Launch TurnUp portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        
        //driver.Manage().Window.Maximize();

        // Identify username textbox and enter valid username
        IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
        userNameTextbox.SendKeys("hari");

        // Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        // Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();

        // check if user has logged in successfull
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in Successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test Failed!");
        }
        
        //driver.Close();
    }

}