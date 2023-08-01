using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;
using Microsoft.Extensions.Options;

namespace EAAutoFramework.Base
{
    public class TestInitializeHook : Steps
    {

        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:                    
                    driverOptions = new InternetExplorerOptions();
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.AddArguments("disable-blink-features=AutomationControlled");
                    chromeOptions.AddArguments("--disable-notifications");
                    chromeOptions.AddArgument("--remote-debugging-port=0");
                    
                    _parallelConfig.Driver = new ChromeDriver(Environment.CurrentDirectory.ToString() + @"\Drivers\ChromeDriver\");                    
                    _parallelConfig.Driver.Manage().Cookies.DeleteAllCookies();
                    _parallelConfig.Driver.Manage().Window.Maximize();
                    break;
            }                        
        }

        public virtual void NaviateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }

        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}
