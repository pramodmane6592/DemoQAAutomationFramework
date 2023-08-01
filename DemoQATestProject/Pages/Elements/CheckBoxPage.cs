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
    public class CheckBoxPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CheckBoxPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement chkHome => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='tree-node-home']//following::span[@class='rct-checkbox']"));
        IWebElement Result => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='result']"));

        public void SelectHomeCheckBoxAndValidate()
        {
            ScrollIntoView(chkHome);
            chkHome.Click();

            //Assert
            string selectedItems = Result.FindElement(By.XPath("//span[contains(text(),'home')]")).Text;
            Assert.IsTrue(selectedItems.Equals("home"));
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = _parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
