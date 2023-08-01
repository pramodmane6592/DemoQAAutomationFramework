# DemoQAAutomationFrameworkWithSpecflow

Setup - 
#appsettings.josn - Modify this file update test environments, AUT, UseName, Password or other test automaton configuration setttings.  

DemoQAAutomationFrameworkWithSpecflow contains 2 projects as below

1.	AutoFramework - This is a class library project which contains all Selenium generic libraries, Config and Utilities.
   
  •	Base – Contains base classes like Base.cs, BasePage.cs, BaseStep.cs, TestInitializeHook.cs etc
  • Config – ConfigReader, Settings, TestSettings to read application like Env, UserName, Password
  •	Extensions – WebDriver and Web Element extension methods
  •	Helpers – Helper classes DataBaseHelpers, ExcelHelpers etc.
  
2.	DemoQATestProject - This is a test project which contains tests developed with Selenium C# and Specflow with Gherkin language syntaxes. Highlevel project 
    information is as below -
   
  •	Drivers – Latest Chromer/Firefox driver exe
  •	Features – Feature files specific to each page scenarios like TextBox, CheckBox etc
  •	Hooks – Hooks class file handle test scenarios execution and generate logs using Extent Report.
  •	Pages – Object Repository and private functions specific to each page
  •	Steps – Steps definitions classes implemented separately for each page
  •	Test Data – Test data required test automation execution e.g sampleFile to Upload 
  
3. Test Automation Results -  Test Automation are generated using Extent Report also. You can find/configure logs at     
   C:\extentreport\SeleniumWithSpecflow\SpecflowParallelTest
