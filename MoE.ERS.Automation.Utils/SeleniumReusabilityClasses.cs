using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;


namespace MoE.ERS.Automation.Utils
{
    class SeleniumReusabilityClasses
    {

        //Generic method to locate the webelement
        public static By getWebElementByLocator(IWebDriver driver, String locator, String elementIdentifier)
        {
            By element = null;
            switch (locator.ToLower())
            {
                case "classname":
                    element = By.ClassName(elementIdentifier);
                    break;
                case "id":
                    element = By.Id(elementIdentifier);
                    break;
                case "xpath":
                    element = By.XPath(elementIdentifier);
                    break;
                case "linktext":
                    element = By.LinkText(elementIdentifier);
                    break;
                case "partiallinktext":
                    element = By.PartialLinkText(elementIdentifier);
                    break;
                case "name":
                    element = By.Name(elementIdentifier);
                    break;
                case "cssselector":
                    element = By.CssSelector(elementIdentifier);
                    break;
                case "tagname":
                    element = By.TagName(elementIdentifier);
                    break;
                default:
                    Console.WriteLine("Invalid locator has passed");
                    break;
            }
            try
                
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            }
            catch (Exception e)
            { 

                throw new Exception("Not able to find web element with locator<b> " + locator + " = "+ elementIdentifier + "</b> after 60 seconds of wait on the web page", e);
            }
            return element;
        }

        // Method: Wait for element to visible
        private static void WaitForElementVisible(IWebDriver driver, By by, int timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }
        public static void wait(int timeinseconds)
        {
            System.Threading.Thread.Sleep(timeinseconds * 1000);
        }

        public static String returnElementIdentifier(String pageIdentifier, String keyValue)
        {
            ResourceManager rm = new ResourceManager("MoE.ERS.Automation.Utils.ElementIdentifiers." + pageIdentifier, Assembly.GetExecutingAssembly());
            String elementidentifier = rm.GetString(keyValue);
            return elementidentifier;
        }

        public static void clickElement(IWebDriver driver, String locator, String keyValue, String pageIdentifier)
        {
            String elementidentifier = returnElementIdentifier(pageIdentifier, keyValue);
            By ele = getWebElementByLocator(driver, locator, elementidentifier);
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(ele));
            try
            {
                driver.FindElement(ele).Click();
            }
            catch (Exception e)
            {
                throw new Exception("Not able to click on an element having " + locator + " - <b>" + elementidentifier + "</b>", e);
            }
        }

    }

    
}
