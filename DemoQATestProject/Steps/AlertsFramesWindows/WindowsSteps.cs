using DemoQATestProject.Pages.AlertsFramesWindows;
using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.AlertsFramesWindows
{
    [Binding]
    public class WindowsSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public WindowsSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [Then(@"I Open new tab and validate")]
        public void ThenIOpenNewTabAndValidate()
        {
            _parallelConfig.CurrentPage.As<WindowsPage>().OpenNewTabAndSwitchToSame();
        }

        [Then(@"I Open new Window and validate")]
        public void ThenIOpenNewWindowAndValidate()
        {
            _parallelConfig.CurrentPage.As<WindowsPage>().OpenNewWindowSwitchToSame();
        }

        [Then(@"I Open new Alert and Accept")]
        public void ThenIOpenNewAlertAndAccept()
        {
            _parallelConfig.CurrentPage.As<WindowsPage>().HandleBrowserAlert();
        }

    }
}
