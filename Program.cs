using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
public class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver(); 

        // Launch TurnUp portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();

        // Identify username textbox and enter valid username
        IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
        userNameTextbox.SendKeys("hari");

        // Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        // Identify login buton and click on it
        IWebElement loginButon = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButon.Click();

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
        driver.Close();
    }

}