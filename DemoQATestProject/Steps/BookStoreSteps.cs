using DemoQATestProject.Pages;
using DemoQATestProject.Pages.Elements;
using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Steps
{
    [Binding]
    public class BookStoreSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public BookStoreSteps(ParallelConfig parellelConfig) : base(parellelConfig)
        {
            _parallelConfig = parellelConfig;
        }

        [Then(@"I Register New User And Login With registerd credentials")]
        public void ThenIRegisterNewUserAndLoginWithRegisterdCredentials()
        {
            _parallelConfig.CurrentPage.As<BookStorePage>().RegisterNewUser();
        }

    }
}
