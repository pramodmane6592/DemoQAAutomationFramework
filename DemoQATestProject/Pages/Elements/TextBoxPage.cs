using AutoFramework.Extensions;
using EAAutoFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.Elements
{
    public class TextBoxPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public TextBoxPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement txtFullName => _parallelConfig.Driver.FindElement(By.Id("userName"));
        IWebElement txtEmailId => _parallelConfig.Driver.FindElement(By.Id("userEmail"));
        IWebElement txtCurrentAddress => _parallelConfig.Driver.FindElement(By.Id("currentAddress"));
        IWebElement txtPermanentAddress => _parallelConfig.Driver.FindElement(By.Id("permanentAddress"));
        IWebElement btnSubmit => _parallelConfig.Driver.FindElement(By.Id("submit"));
        IWebElement outputName => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='output']//p[@id='name']"));
        IWebElement outputEmail => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='output']//p[@id='email']"));
        IWebElement outputCureentAddress => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='output']//p[@id='currentAddress']"));
        IWebElement outputPermanentAddress => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='output']//p[@id='permanentAddress']"));

        public void EnterFormDetailsAndSubmit(string fullName, string email, string currentAddress, string permanentAddress)
        {
            //Enter form data
            txtFullName.SendKeys(fullName);
            txtEmailId.SendKeys(email);
            txtCurrentAddress.SendKeys(currentAddress);
            txtPermanentAddress.SendKeys(permanentAddress);

            //Click Submit
            ScrollIntoView(btnSubmit);
            btnSubmit.Click();

            //Set
            _scenarioContext.Set(fullName, "FullName");
            _scenarioContext.Set(email, "Email");
            _scenarioContext.Set(currentAddress, "currentAddress");
            _scenarioContext.Set(permanentAddress, "permanentAddress");
        }

        public void VerifyDetailsPostSubmission()
        {
            Assert.True(outputName.Text.Contains(_scenarioContext.Get<string>("FullName")));
            Assert.True(outputEmail.Text.Contains(_scenarioContext.Get<string>("Email")));
            Assert.True(outputCureentAddress.Text.Contains(_scenarioContext.Get<string>("currentAddress")));
            Assert.True(outputPermanentAddress.Text.Contains(_scenarioContext.Get<string>("permanentAddress")));
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = _parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
