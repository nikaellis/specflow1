using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{
    class MainPage
    {
        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool isLoginSuccessfull()
        {
            bool isLoginSuccessfull = false;
            try
            {
                IWebElement homePageLabel = driver.FindElement(By.XPath(".//*[text()='Home page']"));
                isLoginSuccessfull = homePageLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                isLoginSuccessfull = false;
            }
            return isLoginSuccessfull;
        }
        public bool AllProductsPageOpen()
        {
            bool AllProductsPageOpen = false;
            try
            {
                IWebElement add = driver.FindElement(By.LinkText("All Products"));
                AllProductsPageOpen = add.Displayed;
            }
            catch (NoSuchElementException)
            {
                AllProductsPageOpen = false;
            }
            return AllProductsPageOpen;
        }
        public bool isProductEditing()
        {
            bool isProductEditing = false;
            try
            {
                IWebElement ProdEditLabel = driver.FindElement(By.XPath(".//*[text()='Product editing']"));
                isProductEditing = ProdEditLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                isProductEditing = false;
            }
            return isProductEditing;
        }
        public bool isProductExist()
        {
            bool isProductExist = false;
            try
            {
                IWebElement ProdExist = driver.FindElement(By.LinkText("Test product"));
                isProductExist = ProdExist.Displayed;
            }
            catch (NoSuchElementException)
            {
                isProductExist = false;
            }
            return isProductExist;
        }
        public bool isLogoutSuccessfull()
        {
            bool isLogoutSuccessfull = false;
            try
            {
                IWebElement logoimg = driver.FindElement(By.XPath(".//*[text()='Login']"));
                isLogoutSuccessfull = logoimg.Displayed;
            }
            catch (NoSuchElementException)
            {
                isLogoutSuccessfull = false;
            }
            return isLogoutSuccessfull;
        }
    }
}