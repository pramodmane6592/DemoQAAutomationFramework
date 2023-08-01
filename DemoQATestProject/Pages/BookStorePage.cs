using AutoFramework.Extensions;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages
{
    public class BookStorePage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public BookStorePage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement btnNewUser => _parallelConfig.Driver.FindElement(By.Id("newUser"));
        IWebElement btnLogin => _parallelConfig.Driver.FindElement(By.Id("login"));
        IWebElement txtUserName => _parallelConfig.Driver.FindElement(By.Id("userName"));
        IWebElement txtPassword => _parallelConfig.Driver.FindElement(By.Id("password"));
        IWebElement txtFirstName => _parallelConfig.Driver.FindElement(By.Id("firstname"));
        IWebElement txtLastName => _parallelConfig.Driver.FindElement(By.Id("lastname"));
        IWebElement btnRegister => _parallelConfig.Driver.FindElement(By.Id("register")); 
        IWebElement chkCaptcha => _parallelConfig.Driver.FindElement(By.Id("recaptcha-anchor"));

        IWebElement spanLogin => _parallelConfig.Driver.FindElement(By.XPath("//span[contains(text(),'Login')]"));



        public void RegisterNewUser()
        {
            Random rnd= new Random();
            int randomNo = rnd.Next(0, 1000);

            btnNewUser.Click();
            txtFirstName.SendKeys("fname");
            txtLastName.SendKeys("lname");
            txtUserName.SendKeys("username" + randomNo);
            txtPassword.SendKeys("Password" + "@" + randomNo);

            _scenarioContext.Set("username" + randomNo, "UserName");
            _scenarioContext.Set("Password" + "@" + randomNo, "Password");

            chkCaptcha.Click();
            Thread.Sleep(3000);

            ScrollIntoView(btnRegister);
            btnRegister.Click();

            IAlert simpleAlert = _parallelConfig.Driver.SwitchTo().Alert();
            simpleAlert.Accept();

            Login();
        }

        public void Login()
        {
            ScrollIntoView(spanLogin);
            spanLogin.Click();

            txtUserName.SendKeys(_scenarioContext.Get<string>("UserName"));
            txtPassword.SendKeys(_scenarioContext.Get<string>("Password"));

            btnLogin.Click();
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
