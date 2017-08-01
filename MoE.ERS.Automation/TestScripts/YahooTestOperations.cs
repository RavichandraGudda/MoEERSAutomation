using MoE.ERS.Automation.BaseLibrary;
using OpenQA.Selenium;
using System;
using Xunit;
using Assert = Xunit.Assert;
using MoE.ERS.Automation.Pages.Yahoo;
using MoE.ERS.Automation.Utils;
using MoE.ERS.Automation.Utils.Reports;
    

namespace MoE.ERS.Automation.TestScripts.Yahoo
{
    public class YahooTestOperations
    {
        private IWebDriver _webDriver = null;
        private HtmlReporter htmlReporter = null;
        private string startTime, endTime;
        private bool isFailed = false;
        public YahooTestOperations()
        {            
            htmlReporter = HtmlReporter.GetInstance();            
        }

        private void NavigateToPage()
        {          
            this._webDriver = DriverFactory.Create("chrome");
            this._webDriver.Url = "https://login.yahoo.com/account/create?";
        }
        [Fact(DisplayName = "Input the controls in Yahoo account creation page.")]
        public void InputControls()
        {
            try
            {
                startTime = DateTime.Now.ToShortTimeString();
                NavigateToPage();
                //Arrange
                var yahoopage = new YahooAccountCreationPage(this._webDriver);
                //Act
                yahoopage.InputControls();
                yahoopage.TestLogin();
            }
            catch(Exception) {
                isFailed = true;
                GetScreenShot.Capture(this._webDriver, "InputControls");
            }
            finally
            {
                endTime = DateTime.Now.ToShortTimeString();
                htmlReporter.AddResultToReport("InputControls", "", ""
                                               , isFailed ? "FAIL" : "PASS", "InputControls.png", startTime, endTime);
                this._webDriver.Quit();
            }
        }
        [Fact(DisplayName ="ValidateResults")]
        public void ValidateResults()
        {
            int expected = 1;
            int actual = 1;
            try
            {
                startTime = DateTime.Now.ToShortTimeString();
                NavigateToPage();
                Assert.Equal(expected, actual);     
            }
            catch(Exception ex)
            {
                isFailed = true;
                GetScreenShot.Capture(this._webDriver, "ValidateResults");
            }
            finally
            {
                endTime = DateTime.Now.ToShortTimeString();
                htmlReporter.AddResultToReport("ValidateResults", actual.ToString(), expected.ToString()
                                               , isFailed?"FAIL":"PASS", "ValidateResults.png", startTime, endTime);
                this._webDriver.Quit();
            }
        }

        [Fact(DisplayName ="Vaidate One More")]
        public void ValidateOneMore()
        {
            int actual = 2;
            int expected = 1;
            try
            {
                startTime = DateTime.Now.ToShortTimeString();
                NavigateToPage();
                Assert.Equal(expected, actual);
            }
            catch(Exception ex)
            {
                isFailed = true;
                GetScreenShot.Capture(this._webDriver, "ValidateOneMore");
            }
            finally
            {
                endTime = DateTime.Now.ToShortTimeString();
                htmlReporter.AddResultToReport("ValidateOneMore", actual.ToString(), expected.ToString()
                                               , isFailed ? "FAIL" : "PASS", "ValidateOneMore.png", startTime, endTime);
                this._webDriver.Quit();
            }
        }
        //[Fact(DisplayName = "TearDown Method")]
        //public void Dispose()
        //{              
        //}           
    }
}   