using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalRegression.Utilities
{
    public class WaitUtils
    {
        public static void WaitToBeVisible(IWebDriver driver, By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitToBeExist(IWebDriver driver, By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        //public static void WaitToBeClickable(IWebDriver driver, string locaterType, string locaterValue, int seconds)
        public static void WaitToBeClickable(IWebDriver driver, By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            //switch (locaterType.ToUpper())
            //{
            //    case "ID":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locaterValue)));
            //        break;
            //    case "NAME":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locaterValue)));
            //        break;
            //    case "TAG_NAME":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(locaterValue)));
            //        break;
            //    case "CLASS_NAME":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locaterValue)));
            //        break;
            //    case "LINK_TEXT":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(locaterValue)));
            //        break;
            //    case "PARTIAL_LINK_TEXT":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(locaterValue)));
            //        break;
            //    case "CSS_SELECTOR":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locaterValue)));
            //        break;
            //    case "XPATH":
            //        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locaterValue)));
            //        break;
            //}
        }
    }
}
