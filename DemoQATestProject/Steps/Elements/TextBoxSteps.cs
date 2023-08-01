using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DemoQATestProject.Steps.Elements
{
    [Binding]
    public class TextBoxSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public TextBoxSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [When(@"I enter form details and submit")]
        public void WhenIFormDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<TextBoxPage>().EnterFormDetailsAndSubmit(data.FullName, data.Email, data.CurrentAddress, data.PermanentAddress);
        }

        [Then(@"I Validate the results post submission")]
        public void IValidateTheResults()
        {
            _parallelConfig.CurrentPage.As<TextBoxPage>().VerifyDetailsPostSubmission();
        }
    }
}
