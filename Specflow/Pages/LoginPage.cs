using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasicsDemo
{

    class LoginPage
    {
        private IWebDriver driver;
      
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.loginField = driver.FindElement(By.Id("Name"));
            this.passwordField = driver.FindElement(By.Id("Password"));
        }

        private IWebElement loginField;
        private IWebElement passwordField;

        public MainPage Login(String login, String password)
        {
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            passwordField.Submit();
            return new MainPage(driver);
        }
    }
}
