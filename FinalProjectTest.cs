using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumFinalProject
{
    [TestFixture]
    internal class FinalProjectTest
    {
        IWebDriver driver;

        HomePage homePage;
        MyAccountPage myAccountPage;

        [OneTimeSetUp]
        public void IntializeUserDetails()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://woodmart.xtemos.com/home/");

            homePage = new HomePage(driver);

            myAccountPage = new MyAccountPage(driver);
        }

        [Test]
        [Order(1)]
        public void ConfirmSuccessfulRegister()
        {
            homePage.ClickOnLoginRegisterButton();

            homePage.ClickOnCreateAnAccountButton();

            myAccountPage.AddUserName();

            myAccountPage.AddEmail();

            myAccountPage.AddPassword();

            myAccountPage.ClickRegisterButton();

            myAccountPage.ClickOnAccountDetails();

            myAccountPage.FindEmailAddressField();
        }

        [Test]
        [Order(2)]
        public void ConfirmBothProductsAreAddedToCompare()
        {
            homePage.ClickOnHomePageButton();

            homePage.ClickOnClocksButton();

            ClocksPage clocksPage = new ClocksPage(driver);
            clocksPage.ClickOnBestClockParallels();
            clocksPage.DolorAdHacTorquent();

            homePage.ClickOnCompareProductsButton();

            ComparePage comparePage = new ComparePage(driver);
            comparePage.ConfirmNumberOfProducts();

            comparePage.ConfirmProductHasFiveStars();

            comparePage.ConfirmProductsAreInStock();

            comparePage.ConfirmProductDoesNotHaveColorSelection();

            comparePage.RemoveProducts();

            homePage.ClickOnMyAccountButton();

            myAccountPage.ClickOnLogoutButton();

        }


        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
