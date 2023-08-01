using EAAutoFramework.Base;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.Interactions
{
    public class SortPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public SortPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement lstSort => _parallelConfig.Driver.FindElement(By.XPath("//div[@class='sortable-container']//div[@id='demo-tabpane-list']"));

        public void SortExistingList()
        {
            List<string> originalList = new List<string>();

            IReadOnlyList<IWebElement> webElements = lstSort.FindElements(By.XPath("//div[contains(@class, 'list-group-item')]"));

            foreach (var elment in webElements)
            {
                originalList.Add(elment.Text);
            }

            var sortedList = originalList.OrderBy(x => x).ToList();

            foreach (var elment in sortedList) { Console.WriteLine(elment); }
        }
    }
}
