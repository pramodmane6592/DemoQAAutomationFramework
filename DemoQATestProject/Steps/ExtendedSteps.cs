using DemoQATestProject.Pages;
using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;
        private readonly ScenarioContext _scenarioContext;

        public ExtendedSteps(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _scenarioContext = scenarioContext;
        }

        public void NaviateSite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
        }

        [Given(@"I navigate to Demo QA Website")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NaviateSite();
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig, _scenarioContext);
        }        

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "Text Box")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickTextBoxLink();
            else if (linkName == "Check Box")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickCheckBoxLink();
            else if (linkName == "Web Tables")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickWebTablesLink();
            else if (linkName == "Upload and Download")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickUploadAndDownloadLink();
            else if (linkName == "Browser Windows")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickWindowsLink();
            else if (linkName == "Alerts")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickAlertLink();
            else if (linkName == "Tool Tips")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickToolTipsLink();
            else if (linkName == "Sortable")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickSortableLink();
            else if (linkName == "Droppable")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickDroppableLink();
            else if (linkName == "Login")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickBookStoreLoginLink();
            else if (linkName == "Buttons")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickButtonsLink();
        }                
    }
}
