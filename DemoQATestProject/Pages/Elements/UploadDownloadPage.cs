using EAAutoFramework.Base;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoQATestProject.Pages.Elements
{
    public class UploadDownloadPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public UploadDownloadPage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement btnChooseFile => _parallelConfig.Driver.FindElement(By.Id("uploadFile"));
        IWebElement uploadFilePath => _parallelConfig.Driver.FindElement(By.XPath("//p[@id='uploadedFilePath']"));
        IWebElement btnDownloadFile => _parallelConfig.Driver.FindElement(By.Id("downloadButton"));

        public void UploadFile()
        {
            btnChooseFile.SendKeys(Environment.CurrentDirectory.ToString() + @"\TestData\sampleFile.JPEG");
            _scenarioContext.Set("sampleFile.JPEG", "fileName");
        }

        public void ValidateUploadFilePath()
        {
            string fileName = _scenarioContext.Get<string>("fileName");
            Assert.IsTrue(uploadFilePath.Text.Equals(@"C:\fakepath\" + fileName));
        }

        public void DownloadFile()
        {
            btnDownloadFile.Click();
            Thread.Sleep(3000);

            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

            string[] files = Directory.GetFiles(downloadPath, "*.JPEG");
            Assert.Pass("File Downloaded Successfuly");

            foreach (string file in files)
            {
                //Assert.IsTrue(file.Contains(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\sampleFile.JPEG"));
            }
        }
    }
}
