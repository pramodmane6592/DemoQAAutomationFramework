using EAAutoFramework.Base;
using Microsoft.AspNetCore.Razor.Language;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.Interactions
{
    public class DragAndDropPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public DragAndDropPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement sourceElement => _parallelConfig.Driver.FindElement(By.Id("draggable"));
        IWebElement targetElement => _parallelConfig.Driver.FindElement(By.Id("droppable"));

        public void DragAndDropElement()
        {
            //Actions action = new Actions(_parallelConfig.Driver);
            //action.DragAndDrop(sourceElement, targetElement).Build().Perform();

            //Thread.Sleep(1000);
            //Assert.IsTrue(targetElement.FindElement(By.XPath("//p")).Text.Equals("Dropped!"));
        }
    }
}
