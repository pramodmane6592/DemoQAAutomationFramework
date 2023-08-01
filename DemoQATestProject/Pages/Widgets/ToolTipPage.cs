using AutoFramework.Extensions;
using EAAutoFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.Widgets
{
    public class ToolTipPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public ToolTipPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement btnToolTip => _parallelConfig.Driver.FindElement(By.Id("toolTipButton"));

        public void GetElementToolTip()
        {
            ScrollIntoView(btnToolTip);


            Actions actions = new Actions(_parallelConfig.Driver);                                  
            actions.MoveToElement(btnToolTip).Perform();

            IWebElement toolTip = _parallelConfig.Driver.FindElement(By.XPath("//button[@aria-describedby='buttonToolTip']"));

            // To get the tool tip text and assert 
            String toolTipText = toolTip.Text;            
            Assert.IsTrue(toolTipText.Equals("Hover me to see"));           
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = _parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

    }
}
