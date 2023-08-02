using DemoQATestProject.Pages;
using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Elements
{
    [Binding]
    public class ButtonsSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public ButtonsSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [StepDefinition(@"I click on (.*) button and get text displyed")]
        public void ThenIClickButtonAndGetTextDisplyed(string btnName)
        {
            _parallelConfig.CurrentPage.As<ButtonsPage>().ClickButtonAndGetText(btnName);
        }
    }
}
