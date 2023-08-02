using DemoQATestProject.Pages.Interactions;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Interactions
{
    [Binding]
    public class DragAndDropSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public DragAndDropSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [Then(@"I perform drag and drop action")]
        public void ThenIPerformDragAndDropAction()
        {
            _parallelConfig.CurrentPage.As<DragAndDropPage>().DragAndDropElement();
        }

    }
}
