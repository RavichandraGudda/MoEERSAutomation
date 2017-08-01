using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MoE.ERS.Automation.BaseLibrary
{
    public abstract class PageBase
    {
        internal PageBase(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        internal void TestLogin()
        { }
    }
}
