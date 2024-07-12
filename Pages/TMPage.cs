using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using TurnUpPortalRegression.Utilities;
using NUnit.Framework;

namespace TurnUpPortalRegression.Pages
{
    public class TMPage
    {
        private static readonly By byAdministrationTab = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        private static readonly By byTimeAndMaterialOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private static readonly By byCreateNewButton = By.XPath("//*[@id=\"container\"]/p/a");
        private static readonly By byTypeCodeDropdown = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]");
        private static readonly By byMaterialOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]");
        private static readonly By byTimeOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]");
        private static readonly By byCodeTextBox = By.Id("Code");
        private static readonly By byDescriptionTextBox = By.Id("Description");
        private static readonly By byPriceOverlap = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]");
        private static readonly By byPriceTextBox = By.Id("Price");
        private static readonly By byFileUpload = By.Id("files");
        private static readonly By bySaveButton = By.Id("SaveButton");
        private static readonly By byGoToLastPage = By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span");
        private static readonly By byNewCode = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]");
        private static readonly By byGroupingHeader = By.XPath("//div[contains(text(),'Drag a column header and drop it here to group by ')]");
        private static readonly By byEditButton = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        private static readonly By byDeleteButton = By.XPath("//tbody/tr[last()]/td[5]/a[2]");

        public void CreateTimeRecord(IWebDriver driver)
        {
            //IWebElement createNewButton = wait.Until(ExpectedConditions.ElementToBeClickable(byCreateNewButton));
            IWebElement createNewButton = driver.FindElement(byCreateNewButton);
            WaitUtils.WaitToBeClickable(driver, byCreateNewButton, 6);
            createNewButton.Click();

            //IWebElement typeCodeDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(byTypeCodeDropdown));
            IWebElement typeCodeDropdown = driver.FindElement(byTypeCodeDropdown);
            WaitUtils.WaitToBeClickable(driver, byTypeCodeDropdown, 6);
            typeCodeDropdown.Click();

            //IWebElement timeOption = wait.Until(ExpectedConditions.ElementToBeClickable(byTimeOption));
            IWebElement timeOption = driver.FindElement(byTimeOption);

            //wait.Until(ExpectedConditions.ElementIsVisible(byTimeOption));
            WaitUtils.WaitToBeClickable(driver, byTimeOption, 6);
            //Thread.Sleep(1000);
            timeOption.Click();

            IWebElement codeTextBox = driver.FindElement(byCodeTextBox);
            codeTextBox.SendKeys("JayCode001");

            IWebElement descriptionTextBox = driver.FindElement(byDescriptionTextBox);
            descriptionTextBox.SendKeys("JayDescription001");

            IWebElement priceOverlap = driver.FindElement(byPriceOverlap);
            priceOverlap.Click();
            IWebElement priceTextBox = driver.FindElement(byPriceTextBox);
            priceTextBox.SendKeys("66.66");

            IWebElement fileUpload = driver.FindElement(byFileUpload);
            string filePath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\TurnUpPortFile.txt";
            fileUpload.SendKeys(filePath);

            IWebElement saveButton = driver.FindElement(bySaveButton);
            saveButton.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(byGroupingHeader));
            WaitUtils.WaitToBeVisible(driver, byGroupingHeader, 6);

            //Thread.Sleep(1000);

            //IWebElement goToLastPage = wait.Until(ExpectedConditions.ElementToBeClickable(byGoToLastPage));
            IWebElement goToLastPage = driver.FindElement(byGoToLastPage);
            WaitUtils.WaitToBeVisible(driver, byGoToLastPage, 6);
            goToLastPage.Click();

            IWebElement newCode = driver.FindElement(byNewCode);
            Assert.That(newCode.Text == "JayCode001", "Create new Time and Material item Failded. Test Failed!");

            //if (newCode.Text == "JayCode001")
            //{
            //    Console.WriteLine("Create new Time and Material item successfully.  Test Passed!");
            //}
            //else
            //{
            //    Console.WriteLine("Create new Time and Material item Failded. Test Failed!");
            //}
        }
        public void EditTimeRecord(IWebDriver driver)
        {
            //var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            IWebElement goToLastPage = driver.FindElement(byGoToLastPage);
            WaitUtils.WaitToBeClickable(driver, byGoToLastPage, 6);
            goToLastPage.Click();

            //IWebElement editButton = wait.Until(ExpectedConditions.ElementToBeClickable(byEditButton));
            IWebElement editButton = driver.FindElement(byEditButton);
            WaitUtils.WaitToBeClickable(driver, byEditButton, 6);
            editButton.Click();

            //IWebElement typeCodeDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(byTypeCodeDropdown));
            IWebElement typeCodeDropdown = driver.FindElement(byTypeCodeDropdown);
            WaitUtils.WaitToBeClickable(driver, byTypeCodeDropdown, 5);
            typeCodeDropdown.Click();

            //IWebElement materialOption = wait.Until(ExpectedConditions.ElementToBeClickable(byMaterialOption));
            IWebElement materialOption = driver.FindElement(byMaterialOption);
            WaitUtils.WaitToBeClickable(driver, byMaterialOption, 5);
            materialOption.Click();

            IWebElement codeTextBox = driver.FindElement(byCodeTextBox);
            codeTextBox.Clear();
            codeTextBox.SendKeys("JayCode002");

            IWebElement descriptionTextBox = driver.FindElement(byDescriptionTextBox);
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys("JayDescription002");

            IWebElement priceOverlap = driver.FindElement(byPriceOverlap);
            priceOverlap.Click();
            IWebElement priceTextBox = driver.FindElement(byPriceTextBox);
            priceTextBox.Clear();
            priceOverlap.Click();
            priceTextBox.SendKeys("99.99");

            IWebElement fileUpload = driver.FindElement(byFileUpload);
            string filePath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\TurnUpPortFile.txt";
            fileUpload.SendKeys(filePath);

            IWebElement saveButton = driver.FindElement(bySaveButton);
            saveButton.Click();

            //wait.Until(ExpectedConditions.ElementIsVisible(byGroupingHeader));
            WaitUtils.WaitToBeVisible(driver, byGroupingHeader, 6);

            //IWebElement goToLastPage = wait.Until(ExpectedConditions.ElementToBeClickable(byGoToLastPage));
            goToLastPage = driver.FindElement(byGoToLastPage);
            WaitUtils.WaitToBeClickable(driver, byGoToLastPage, 6);
            goToLastPage.Click();

            WaitUtils.WaitToBeVisible(driver, byGroupingHeader, 6);

            IWebElement newCode = driver.FindElement(byNewCode);
            Assert.That(newCode.Text == "JayCode002", "Edit new created record Failded. Test Failed!");
            //if (newCode.Text == "JayCode002")
            //{
            //    Console.WriteLine("Edit new created record successfully. Test Passed!");
            //}
            //else
            //{
            //    Console.WriteLine("Edit new created record Failded. Test Failed!");
            //}

        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            IWebElement goToLastPage = driver.FindElement(byGoToLastPage);
            WaitUtils.WaitToBeVisible(driver, byGoToLastPage, 6);
            goToLastPage.Click();
                        
            IWebElement deleteButton = driver.FindElement(byDeleteButton);
            deleteButton.Click();

            driver.SwitchTo().Alert().Accept();

            driver.Navigate().Refresh();
                //RefreshAsync();

            //wait.Until(ExpectedConditions.ElementIsVisible(byGroupingHeader));
            WaitUtils.WaitToBeVisible(driver, byGroupingHeader, 6);

            //IWebElement goToLastPage = wait.Until(ExpectedConditions.ElementToBeClickable(byGoToLastPage));
            goToLastPage = driver.FindElement(byGoToLastPage);
            WaitUtils.WaitToBeClickable(driver, byGoToLastPage, 6);
            goToLastPage.Click();

            IWebElement newCode = driver.FindElement(byNewCode);

            Assert.That(newCode.Text != "JayCode002", "Delete new created record Failded. Test Failed!");
            //if (newCode.Text != "JayCode002")
            //{
            //    Console.WriteLine("Delete new created record successfully. Test Passed!");
            //}
            //else
            //{
            //    Console.WriteLine("Delete new created record Failded. Test Failed!");
            //}

        }

    }
}
