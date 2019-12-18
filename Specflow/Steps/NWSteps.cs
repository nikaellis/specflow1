using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBasicsDemo;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.Steps
{
    [Binding]
    public class NWSteps
    {
        private IWebDriver driver;

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }

        [When(@"I login with ""(.*)"" username and ""(.*)"" password")]
        public void WhenILoginWithUsernameAndPassword(string login, string password)
        {
            new LoginPage(driver).Login(login, password);
        }

        [Then(@"Login is successfull")]
        public void ThenLoginIsSuccessfull()
        {
            Assert.IsTrue(new MainPage(driver).isLoginSuccessfull(), "Login failed");
        }

        [When(@"I click All product link")]
        public void IClickAllProductLink()
        {
            driver.FindElement(By.LinkText("All Products")).Click();
        }

        [Then(@"open All product page")]
        public void ThenOpenAllProductPage()
        {
            Assert.IsTrue(new MainPage(driver).AllProductsPageOpen(), "All Product failed");
        }

        [When(@"I click Create new")]
        public void WhenIClickCreateNew()
        {
            driver.FindElement(By.LinkText("Create new")).Click();
        }

        [Then(@"open Product editing page")]
        public void ThenOpenProductEditingPage()
        {
            Assert.IsTrue(new MainPage(driver).isProductEditing(), "Product editing open failed");
        }
        [Then(@"create New Product")]
        public void ThenCreateNewProduct()
        {
            driver.FindElement(By.Id("ProductName")).SendKeys("Test Product");
            driver.FindElement(By.XPath("//option[. = 'Seafood']")).Click();
            driver.FindElement(By.XPath("//option[. = 'New England Seafood Cannery']")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("15");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("1kg");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("15");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("100");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("0");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        [Then(@"I check product exist")]
        public void ThenICheckProductExist()
        {
            driver.FindElement(By.LinkText("Test Product")).Click();
            //получаем значения
            string valueProductName = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
            string elementCategoryId = driver.FindElement(By.CssSelector("#CategoryId > option:nth-child(9)")).GetAttribute("text");
            string elementSupplierId = driver.FindElement(By.CssSelector("#SupplierId > option:nth-child(20)")).GetAttribute("text");
            string valueUnitPrice = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
            string valueQuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value");
            string valueUnitsInStock = driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value");
            string valueUnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value");
            string valueReorderLevel = driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value");

            //проверяем значения
            Assert.AreEqual(valueProductName, "Test Product");
            Assert.AreEqual(elementCategoryId, "Seafood");
            Assert.AreEqual(elementSupplierId, "New England Seafood Cannery");
            Assert.AreEqual(valueUnitPrice, "15,0000");
            Assert.AreEqual(valueQuantityPerUnit, "1kg");
            Assert.AreEqual(valueUnitsInStock, "15");
            Assert.AreEqual(valueUnitsOnOrder, "100");
            Assert.AreEqual(valueReorderLevel, "0");
        }
        [Then(@"Logout")]
        public void ThenLogout()
        {
            driver.FindElement(By.XPath(".//*[text()='Logout']")).Click();
            Assert.IsTrue(new MainPage(driver).isLogoutSuccessfull(), "Logout failed");
            driver.Close();
        }

    }
}