using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps.Elements
{
    [Binding]
    public class UploadDownloadSteps : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public UploadDownloadSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [When(@"I upload the test file on the application")]
        public void WhenIUploadTheTestFileOnTheApplication()
        {
            _parallelConfig.CurrentPage.As<UploadDownloadPage>().UploadFile();
        }

        [Then(@"I validate uploaded file path")]
        public void ThenIValidateUploadedFilePath()
        {
            _parallelConfig.CurrentPage.As<UploadDownloadPage>().ValidateUploadFilePath();
        }

        [When(@"I download sample file from the application")]
        public void WhenIDownloadSampleFileFromTheApplication()
        {
            _parallelConfig.CurrentPage.As<UploadDownloadPage>().DownloadFile();
        }


    }
}
