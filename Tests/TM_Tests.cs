using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalRegression.Pages;
using TurnUpPortalRegression.Utilities;

namespace TurnUpPortalRegression.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpTests()
        {
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

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string url = "http://horse.industryconnect.io/";
            string userName = "hari";
            string password = "123123";

            LoginPage loginPage = new LoginPage();
            loginPage.LoginAction(driver, url, userName, password);

            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [Test, Order(1)]
        public void CreatTime_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Test, Order(2)]
        public void EditTime_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver);
        }

        [Test, Order(3)]
        public void DeleteTime_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void TearDownTests()
        {
            driver.Close();
        }
    }
}
