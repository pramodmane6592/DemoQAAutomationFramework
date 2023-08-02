using AutoFramework.Extensions;
using EAAutoFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace DemoQATestProject.Pages.Elements
{
    public class ButtonsPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public ButtonsPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement btnClickMe => _parallelConfig.Driver.FindElement(By.XPath("//button[contains(text(),'Click Me')]"));
        IWebElement btnRightClick => _parallelConfig.Driver.FindElement(By.Id("rightClickBtn"));
        IWebElement btnDoubleClick => _parallelConfig.Driver.FindElement(By.Id("doubleClickBtn"));

        IWebElement pDynamicClickMessage => _parallelConfig.Driver.FindElement(By.Id("dynamicClickMessage"));
        IWebElement pRightClickMessage => _parallelConfig.Driver.FindElement(By.Id("rightClickMessage"));
        IWebElement pDoubleClickMessage => _parallelConfig.Driver.FindElement(By.Id("doubleClickMessage"));

        public void ClickButtonAndGetText(string btnName)
        {
            if (btnName.Equals("Right Click Me"))
            {
                Actions a = new Actions(_parallelConfig.Driver);
                a.MoveToElement(btnRightClick).
                ContextClick().
                Build().Perform();

                Thread.Sleep(1000);
                Assert.IsTrue(pRightClickMessage.Text.Equals("You have done a right click"));
            }
            else if (btnName.Equals("Double Click Me"))
            {
                Actions act = new Actions(_parallelConfig.Driver);                
                act.DoubleClick(btnDoubleClick).Perform();

                Thread.Sleep(1000);
                Assert.IsTrue(pDoubleClickMessage.Text.Equals("You have done a double click"));
            }
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
