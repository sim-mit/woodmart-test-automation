using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net.Mail;

namespace SeleniumFinalProject
{
    internal class MyAccountPage
    {
        WebDriverWait driverWait;
        IWebDriver myAccountPageDriver;

        string username;
        string email;
        string password;

        public MyAccountPage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            myAccountPageDriver = driver;

            string timestamp = DateTime.Now.ToString().Replace('/', '1').Replace(':', '2').Replace(" ", "3");
            username = "user_" + timestamp;
            email = "test_" + timestamp + "@test.com";
            password = timestamp + "Abcd!";
        }

        By UserNameField = By.CssSelector("input#reg_username");

        public void AddUserName()
        {   
            driverWait.Until(ExpectedConditions.ElementToBeClickable(UserNameField)).SendKeys(username);
        }

        By EmailField = By.CssSelector("input#reg_email");

        public void AddEmail()
        {
            Actions action = new Actions(myAccountPageDriver);
            action.MoveToElement(myAccountPageDriver.FindElement(EmailField)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(EmailField)).SendKeys(email);
        }

        By PasswordField = By.CssSelector("input#reg_password");

        public void AddPassword()
        {
            Actions action = new Actions(myAccountPageDriver);
            action.MoveToElement(myAccountPageDriver.FindElement(PasswordField)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(PasswordField)).SendKeys(password);
        }

        By RegisterButton = By.XPath("//button[text()=\"Register\"]");

        public void ClickRegisterButton()
        {
            Actions action = new Actions(myAccountPageDriver);
            action.MoveToElement(myAccountPageDriver.FindElement(RegisterButton)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(RegisterButton)).Click();
        }

        By AccountDetails = By.XPath("//a[text()=\"Account details\"]");

        public void ClickOnAccountDetails()
        {
            Actions action = new Actions(myAccountPageDriver);
            action.MoveToElement(myAccountPageDriver.FindElement(AccountDetails)).Perform();
            Thread.Sleep(1000);

            driverWait.Until(ExpectedConditions.ElementToBeClickable(AccountDetails)).Click();
        }

        By EmailAddressField = By.CssSelector("input#account_email");

        public void FindEmailAddressField()
        {
            Actions action = new Actions(myAccountPageDriver);
            action.MoveToElement(myAccountPageDriver.FindElement(EmailAddressField)).Perform();
            Thread.Sleep(1000);

            IWebElement inputFieldText = myAccountPageDriver.FindElement(EmailAddressField);

            string enteredText = inputFieldText.GetAttribute("value");

            Assert.That(enteredText, Is.EqualTo(email));

            Console.WriteLine("The email address is: " + enteredText);
        }

        By LogoutButton = By.XPath("//a[text()=\"Logout\"]");

        public void ClickOnLogoutButton()
        {
            driverWait.Until(ExpectedConditions.ElementToBeClickable(LogoutButton)).Click();
        }
    }
}
