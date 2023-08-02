using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DemoQATestProject.Steps.Elements
{
    [Binding]
    public class WebTablesSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public WebTablesSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [When(@"Get Web Tables first row and Edit Info")]
        public void WhenIFormDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<WebTablesPage>().GetTableRowAndEditInfo(data.FullName);
        }

        [Then(@"I Validate the results post edit")]
        public void ThenIValidateTheResultsPostEdit()
        {
            _parallelConfig.CurrentPage.As<WebTablesPage>().ValidateResultPostEdit();
        }
    }
}
