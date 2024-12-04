using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFinalProject
{
    internal class ClocksPage
    {
        WebDriverWait driverWait;
        IWebDriver clocksPageWebDriver;

        public ClocksPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            clocksPageWebDriver = driver;
        }

        By BestClockParallelsParent = By.CssSelector("div[data-id=\"1162\"]");
        By BestClockParallelsCompare = By.CssSelector("a[data-id=\"1162\"]");

        public void ClickOnBestClockParallels()
        {
            Actions action = new Actions(clocksPageWebDriver);       

            ((IJavaScriptExecutor)clocksPageWebDriver).ExecuteScript("arguments[0].scrollIntoView()", clocksPageWebDriver.FindElement(BestClockParallelsParent));
           
            action.SendKeys(Keys.Escape).Perform();
            Thread.Sleep(2000);

            action.MoveToElement(clocksPageWebDriver.FindElement(BestClockParallelsParent)).Perform();
            Thread.Sleep(1000);

            action.SendKeys(Keys.Escape).Perform();
            Thread.Sleep(2000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(BestClockParallelsCompare)).Click();
          
        }

        By DolorAdHacTorquentParent = By.CssSelector("div[data-id=\"1055\"]");
        By DolorAdHacTorquentCompare = By.CssSelector("a[data-id=\"1055\"]");

        public void DolorAdHacTorquent()
        {
            Actions action = new Actions(clocksPageWebDriver);

            ((IJavaScriptExecutor)clocksPageWebDriver).ExecuteScript("arguments[0].scrollIntoView()", clocksPageWebDriver.FindElement(DolorAdHacTorquentParent));      

            action.MoveToElement(clocksPageWebDriver.FindElement(DolorAdHacTorquentParent)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(DolorAdHacTorquentCompare)).Click();

            Actions escapePopUp = new Actions(clocksPageWebDriver);
            escapePopUp.SendKeys(Keys.Escape).Perform();
        }
    }
}
