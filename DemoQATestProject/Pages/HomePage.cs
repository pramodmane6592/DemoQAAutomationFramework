using System;
using System.Data;
using System.Linq;
using System.Threading;
using AutoFramework.Extensions;
using OpenQA.Selenium;
using EAAutoFramework.Base;
using TechTalk.SpecFlow;
using DemoQATestProject.Pages.Elements;
using DemoQATestProject.Pages.AlertsFramesWindows;
using DemoQATestProject.Pages.Widgets;
using DemoQATestProject.Pages.Interactions;

namespace DemoQATestProject.Pages
{
    public class HomePage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public HomePage(ParallelConfig parallelConfig, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _scenarioContext = scenarioContext;
        }

        IWebElement ElementsSection => _parallelConfig.Driver.FindByXpath("//div[@class='category-cards']//h5[contains(text(),'Elements')]");
        IWebElement LnkTextBox => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Text Box')]");
        IWebElement LnkCheckBox => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Check Box')]");
        IWebElement LnkWebTables => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Web Tables')]");
        IWebElement LnkButtons => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Buttons')]");
        IWebElement LnkUploadAndDownload => _parallelConfig.Driver.FindByXpath("//span[ contains(text(),'Upload and Download')]");


        IWebElement AlertsFrameWindowsSection => _parallelConfig.Driver.FindByXpath("//div[@class='category-cards']//h5[contains(text(),'Alerts, Frame & Windows')]");
        IWebElement LnkWindows => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Browser Windows')]");
        IWebElement LnkAlerts => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Alerts')]");

        IWebElement WidgetsSection => _parallelConfig.Driver.FindByXpath("//div[@class='category-cards']//h5[contains(text(),'Widgets')]");
        IWebElement LnkToolTips => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Tool Tips')]");


        IWebElement InteractionsSection => _parallelConfig.Driver.FindByXpath("//div[@class='category-cards']//h5[contains(text(),'Interactions')]");
        IWebElement LnkSortable => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Sortable')]");
        IWebElement LnkDroppable => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Droppable')]");

        IWebElement BookStoreSection => _parallelConfig.Driver.FindByXpath("//div[@class='category-cards']//h5[contains(text(),'Book Store Application')]");
        IWebElement LnkLogin => _parallelConfig.Driver.FindByXpath("//span[contains(text(),'Login')]");        

        internal TextBoxPage ClickTextBoxLink()
        {
            ScrollIntoView(ElementsSection);
            ElementsSection.Click();
            Thread.Sleep(1000);
            LnkTextBox.Click();
            return new TextBoxPage(_parallelConfig, _scenarioContext);
        }

        internal CheckBoxPage ClickCheckBoxLink()
        {
            ScrollIntoView(ElementsSection);
            ElementsSection.Click();
            Thread.Sleep(1000);
            LnkCheckBox.Click();
            return new CheckBoxPage(_parallelConfig, _scenarioContext);
        }

        internal WebTablesPage ClickWebTablesLink()
        {
            ScrollIntoView(ElementsSection);
            ElementsSection.Click();
            Thread.Sleep(1000);
            LnkWebTables.Click();
            return new WebTablesPage(_parallelConfig, _scenarioContext);
        }

        internal ButtonsPage ClickButtonsLink()
        {
            ScrollIntoView(ElementsSection);
            ElementsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkButtons);
            LnkButtons.Click();
            return new ButtonsPage(_parallelConfig, _scenarioContext);
        }

        internal UploadDownloadPage ClickUploadAndDownloadLink()
        {
            ScrollIntoView(ElementsSection);
            ElementsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkUploadAndDownload);
            LnkUploadAndDownload.Click();
            return new UploadDownloadPage(_parallelConfig, _scenarioContext);
        }

        internal WindowsPage ClickWindowsLink()
        {
            ScrollIntoView(AlertsFrameWindowsSection);
            AlertsFrameWindowsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkWindows);
            LnkWindows.Click();
            return new WindowsPage(_parallelConfig, _scenarioContext);
        }

        internal WindowsPage ClickAlertLink()
        {
            ScrollIntoView(AlertsFrameWindowsSection);
            AlertsFrameWindowsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkAlerts);
            LnkAlerts.Click();
            return new WindowsPage(_parallelConfig, _scenarioContext);
        }

        internal ToolTipPage ClickToolTipsLink()
        {
            ScrollIntoView(WidgetsSection);
            WidgetsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkToolTips);
            LnkToolTips.Click();
            return new ToolTipPage(_parallelConfig, _scenarioContext);
        }

        internal SortPage ClickSortableLink()
        {
            ScrollIntoView(InteractionsSection);
            InteractionsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkSortable);
            LnkSortable.Click();
            return new SortPage(_parallelConfig, _scenarioContext);
        }

        internal DragAndDropPage ClickDroppableLink()
        {
            ScrollIntoView(InteractionsSection);
            InteractionsSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkDroppable);
            LnkDroppable.Click();
            return new DragAndDropPage(_parallelConfig, _scenarioContext);
        }

        internal BookStorePage ClickBookStoreLoginLink()
        {
            ScrollIntoView(BookStoreSection);
            BookStoreSection.Click();
            Thread.Sleep(1000);
            ScrollIntoView(LnkLogin);
            LnkLogin.Click();
            return new BookStorePage(_parallelConfig, _scenarioContext);
        }

        public void ScrollIntoView(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_parallelConfig.Driver;
            if (element.IsElementPresent())
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
