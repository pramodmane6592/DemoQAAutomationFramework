using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Elements
{
    [Binding]
    public class CheckBoxSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public CheckBoxSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [Then(@"I select Home check box and validate its selected")]
        public void ThenISelectHomeCheckBoxAndValidateItsSelected()
        {
            _parallelConfig.CurrentPage.As<CheckBoxPage>().SelectHomeCheckBoxAndValidate();
        }

    }
}
