using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumFinalProject
{
    internal class HomePage
    {
        WebDriverWait driverWait;
        IWebDriver homePageDriver;

        public HomePage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            homePageDriver = driver;
        }

        By LoginRegisterButton = By.CssSelector("a[title=\"My account\"]");

        public void ClickOnLoginRegisterButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(LoginRegisterButton)).Click();
        }

        By CreateAnAccountButton = By.XPath("//a[text()=\"Create an Account\"]");

        public void ClickOnCreateAnAccountButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(CreateAnAccountButton)).Click();
        }

        By ClocksButton = By.XPath("//span[text()=\"Clocks\"]");

        public void ClickOnClocksButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(ClocksButton)).Click();
        }

        By HomePageButton = By.XPath("//span[text()=\"Home\"]");

        public void ClickOnHomePageButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(HomePageButton)).Click();
        }

        By CompareProductButton = By.CssSelector("a[title=\"Compare products\"]");

        public void ClickOnCompareProductsButton()
        {
            ((IJavaScriptExecutor)homePageDriver).ExecuteScript("arguments[0].scrollIntoView()", homePageDriver.FindElement(CompareProductButton));
            driverWait.Until(ExpectedConditions.ElementToBeClickable(CompareProductButton)).Click(); 
        }

        By MyAccountButton = By.XPath("//span[contains (text(), \"My Account\")]");

        public void ClickOnMyAccountButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(MyAccountButton)).Click();
        }
    }
}
