using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalRegression.Utilities;

namespace TurnUpPortalRegression.Pages
{
    public class HomePage
    {
        private static readonly By byAdministrationTab = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        private static readonly By byTimeAndMaterialOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private static readonly By byGroupingHeader = By.XPath("//div[contains(text(),'Drag a column header and drop it here to group by ')]");

        public void NavigateToTMPage(IWebDriver driver)
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            IWebElement administrationTab = driver.FindElement(byAdministrationTab);
            //Console.WriteLine(byAdministrationTab.ToString()); 
            administrationTab.Click();

            //IWebElement timeAndMaterialOption = wait.Until(ExpectedConditions.ElementToBeClickable(byTimeAndMaterialOption));
            IWebElement timeAndMaterialOption = driver.FindElement(byTimeAndMaterialOption);
            WaitUtils.WaitToBeClickable(driver, byTimeAndMaterialOption, 6);
            timeAndMaterialOption.Click();

            WaitUtils.WaitToBeVisible(driver, byGroupingHeader, 6);
        }
    }
}
