using DemoQATestProject.Pages.Elements;
using DemoQATestProject.Pages.Widgets;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Widgets
{
    [Binding]
    public class ToolTipSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public ToolTipSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [When(@"I mouse over to the element and get its Tool Tip")]
        public void WhenIMouseOverToTheElementAndGetItsToolTip()
        {
            _parallelConfig.CurrentPage.As<ToolTipPage>().GetElementToolTip();
        }
    }
}
