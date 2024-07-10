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

        string url = "http://horse.industryconnect.io/";
        string userName = "hari";
        string password = "123123";

        LoginAction(driver, url, userName, password);

        CreateTimeRecord(driver);

        EditTimeRecord(driver);

        DeleteTimeRecord(driver);

        //driver.Close();
    }

    public static void LoginAction(IWebDriver driver, string url, string userName, string password)
    {
        // Launch TurnUp portal
        driver.Navigate().GoToUrl(url);

        //driver.Manage().Window.Maximize();

        // Identify username textbox and enter valid username
        IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
        userNameTextbox.SendKeys(userName);

        // Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys(password);

        // Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();

        // check if user has logged in successfull
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (helloHari.Text == "Hello " + userName+ "!")
        {
            Console.WriteLine("User has logged in Successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test Failed!");
        }
    }

    public static void CreateTimeRecord(IWebDriver driver)
    {
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();
        Thread.Sleep(1000);

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();
        Thread.Sleep(1000);

        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();
        Thread.Sleep(1000);

        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]"));
        typeCodeDropdown.Click();
        Thread.Sleep(1000);

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.SendKeys("JayCode001");

        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
        descriptionTextBox.SendKeys("JayDescription001");

        IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceOverlap.Click();
        IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
        priceTextBox.SendKeys("66.66");

        IWebElement fileUpload = driver.FindElement(By.Id("files"));
        string filePath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\TurnUpPortFile.txt";
        fileUpload.SendKeys(filePath);
        Thread.Sleep(1000);

        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(1000);

        IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newCode.Text == "JayCode001")
        {
            Console.WriteLine("Create new Time and Material item successfully.  Test Passed!");
        }
        else
        {
            Console.WriteLine("Create new Time and Material item Failded. Test Failed!");
        }
    }
    public static void EditTimeRecord(IWebDriver driver)
    {
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();
        Thread.Sleep(1000);

        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]"));
        typeCodeDropdown.Click();
        Thread.Sleep(1000);

        IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
        materialOption.Click();

        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.Clear();
        codeTextBox.SendKeys("JayCode002");

        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
        descriptionTextBox.Clear();
        descriptionTextBox.SendKeys("JayDescription002");
        
        IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceOverlap.Click();
        IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
        priceTextBox.Clear();
        priceOverlap.Click();
        priceTextBox.SendKeys("99.99");

        IWebElement fileUpload = driver.FindElement(By.Id("files"));
        string filePath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\TurnUpPortFile.txt";
        fileUpload.SendKeys(filePath);
        Thread.Sleep(1000);

        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(1000);

        IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newCode.Text == "JayCode002")
        {
            Console.WriteLine("Edit new created record successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Edit new created record  Failded. Test Failed!");
        }

    }

    public static void DeleteTimeRecord(IWebDriver driver)
    {
        IWebElement deleteButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[2]"));
        deleteButton.Click();
        Thread.Sleep(1000);

        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(2000);

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newCode.Text != "JayCode002")
        {
            Console.WriteLine("Delete new created record successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Delete new created record Failded. Test Failed!");
        }

    }

}