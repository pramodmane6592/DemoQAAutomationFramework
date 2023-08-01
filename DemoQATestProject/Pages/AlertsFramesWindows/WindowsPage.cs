using EAAutoFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.AlertsFramesWindows
{
    public class WindowsPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public WindowsPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement btnNewTab => _parallelConfig.Driver.FindElement(By.Id("tabButton"));
        IWebElement btnNewWindow => _parallelConfig.Driver.FindElement(By.Id("windowButton"));
        IWebElement btnAlert => _parallelConfig.Driver.FindElement(By.Id("alertButton"));

        public void OpenNewTabAndSwitchToSame()
        {
            btnNewTab.Click();

            //switch to new tab
            string newTabHandle = _parallelConfig.Driver.WindowHandles.Last();
            _parallelConfig.Driver.SwitchTo().Window(newTabHandle);            

            Assert.IsTrue(_parallelConfig.Driver.Url.Contains("demoqa.com/sample"));
        }

        public void OpenNewWindowSwitchToSame()
        {
            btnNewWindow.Click();

            //switch to new tab
            var newWindowHandles = _parallelConfig.Driver.WindowHandles;
            _parallelConfig.Driver.SwitchTo().Window(newWindowHandles[1]);

            Assert.IsTrue(_parallelConfig.Driver.Url.Contains("demoqa.com/sample"));

            _parallelConfig.Driver.Close();
        }

        public void HandleBrowserAlert()
        {
            btnAlert.Click();

            IAlert simpleAlert = _parallelConfig.Driver.SwitchTo().Alert();
            simpleAlert.Accept();
        }
    }
}
