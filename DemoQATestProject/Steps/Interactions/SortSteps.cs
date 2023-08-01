using DemoQATestProject.Pages.Elements;
using DemoQATestProject.Pages.Interactions;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Interactions
{
    [Binding]
    public class SortSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public SortSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [Then(@"I sort the existing List Elements")]
        public void ThenISortTheExistingListElements()
        {
            _parallelConfig.CurrentPage.As<SortPage>().SortExistingList();
        }

    }
}
