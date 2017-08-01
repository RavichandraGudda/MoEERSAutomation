using MoE.ERS.Automation.BaseLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using MoE.ERS.Automation.DataSource;
using MoE.ERS.Automation.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MoE.ERS.Automation.Pages.Yahoo
{
    public class YahooAccountCreationPage : PageBase
    {
        private TestData<LogIn> logInType = null;
        public YahooAccountCreationPage(IWebDriver driver) : base(driver)
        {
            logInType = new TestData<LogIn>();
        }

        [FindsBy(How= How.Name,Using= "firstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Name, Using = "yid")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "shortCountryCode")]
        public IWebElement Code { get; set; }

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='mm']/child :: option[2]")]
        public IWebElement Month { get; set; }

        [FindsBy(How = How.Name, Using = "dd")]
        public IWebElement Day { get; set; }

        [FindsBy(How = How.Name, Using = "yyyy")]
        public IWebElement Year { get; set; }

        [FindsBy(How = How.Name, Using = "freeformGender")]
        public IWebElement Gender { get; set; }

        [FindsBy(How = How.Id, Using = "reg-submit-button")]
        public IWebElement Continue { get; set; }

        [FindsBy(How=How.Name, Using = "sendCode")]
        public IWebElement SendCode { get; set; }

        public void InputControls()
        {
            try
            {                
                var logInData = logInType.GetSingleData();
                var logInListData = logInType.GetMultipleData();
                Expression<Func<LogIn, string>> passwordExpr = login => login.Password;
                Expression<Func<LogIn, string>> userNameExpr = login => login.UserName;
                var filteredEntity = logInType.SetEntityField<string>(passwordExpr, TestDataConstants.PASSWORD);
                var filteredEntities = logInType.SetEntityFields<string>(userNameExpr, TestDataConstants.USERNAMES);
                FirstName.SendKeys("Unisys123");
                LastName.SendKeys("4356");
                Email.SendKeys("MyAutomation43567");
                Password.SendKeys("1efficient#");
                SelectElement selector = new SelectElement(Code);
                selector.SelectByValue("IN");
                Phone.SendKeys("9886328047");
                Month.Click();
                Day.SendKeys("22");
                Year.SendKeys("1987");
                Gender.SendKeys("Male");
                Continue.Click();
                SendCode.Click();
            }
            catch(Exception ex)
            { throw; }
        }
    }
}
