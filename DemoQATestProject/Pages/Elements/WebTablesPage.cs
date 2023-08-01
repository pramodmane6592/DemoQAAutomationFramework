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
    public class WebTablesPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public WebTablesPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement tableEmployee => _parallelConfig.Driver.FindElement(By.XPath("//div[@class='rt-tbody']//div[1]"));
        IWebElement userForm => _parallelConfig.Driver.FindElement(By.XPath("//form[@id='userForm']"));
        IWebElement btnSubmit => _parallelConfig.Driver.FindElement(By.Id("submit"));

        public void  GetTableRowAndEditInfo(string firstName)
        {
            if (tableEmployee.Displayed)
            {
                //Click on Edit Link
                tableEmployee.FindElement(By.XPath("//span[@id='edit-record-1']")).Click();

                //Edit FirstName
                userForm.FindElement(By.XPath("//form[@id='userForm']//input[@id='firstName']")).Clear();
                userForm.FindElement(By.XPath("//form[@id='userForm']//input[@id='firstName']")).SendKeys(firstName);

                //Click
                btnSubmit.Click();

                //set
                _scenarioContext.Set(firstName, "FirstName");
            }
        }

        public void ValidateResultPostEdit()
        {
            //get actual value
            string actualFirstName = tableEmployee.FindElement(By.XPath("//div[@class='rt-tr -odd']//div[@class='rt-td']")).Text;
            string expectedFirstName = _scenarioContext.Get<string>("FirstName");

            Assert.AreEqual(expectedFirstName, actualFirstName);
        }    
        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = _parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
