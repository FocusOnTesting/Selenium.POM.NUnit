using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalRegression.Pages
{
    public class LoginPage
    {
        private static readonly By byUserNameTextbox = By.Id("UserName");
        private static readonly By byPasswordTextbox = By.Id("Password");
        private static readonly By byLoginButton = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        private static readonly By byHello = By.XPath("//*[@id=\"logoutForm\"]/ul/li/a");
        public void LoginAction(IWebDriver driver, string url, string userName, string password)
        {
            // Launch TurnUp portal
            driver.Navigate().GoToUrl(url);

            //driver.Manage().Window.Maximize();

            // Identify username textbox and enter valid username
            IWebElement userNameTextbox = driver.FindElement(byUserNameTextbox);
            userNameTextbox.SendKeys(userName);

            // Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(byPasswordTextbox);
            passwordTextbox.SendKeys(password);

            // Identify login button and click on it
            IWebElement loginButton = driver.FindElement(byLoginButton);
            loginButton.Click();

            // check if user has logged in successfull
            IWebElement helloHari = driver.FindElement(byHello);
            if (helloHari.Text == "Hello " + userName + "!")
            {
                Console.WriteLine("User has logged in Successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }
        }

    }
}
