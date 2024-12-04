using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace SeleniumFinalProject
{
    internal class ComparePage
    {
        WebDriverWait driverWait;
        IWebDriver comparePageDriver;

        public ComparePage(IWebDriver driver)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            comparePageDriver = driver;
        }

        By ProductsSelector = By.CssSelector("table.wd-compare-table>tbody>tr:first-child>td");

        public void ConfirmNumberOfProducts()
        {
            ReadOnlyCollection<IWebElement> productElements = comparePageDriver.FindElements(ProductsSelector);
            int numberOfProducts = productElements.Count;
            
            Assert.That(2, Is.EqualTo(numberOfProducts ));

            string nameFirst = productElements[0].FindElement(By.CssSelector("a.wd-entities-title")).Text;
            string nameSecond = productElements[1].FindElement(By.CssSelector("a.wd-entities-title")).Text;

            Assert.That("Best clock parallels", Is.EqualTo(nameFirst));
            Assert.That("Dolor ad hac torquent", Is.EqualTo(nameSecond));
        }

        public void ConfirmProductHasFiveStars()
        {
            ReadOnlyCollection<IWebElement> productElements = comparePageDriver.FindElements(ProductsSelector);
 
            string ratingFirst = productElements[0].FindElement(By.CssSelector("span.rating")).GetAttribute("class");

            Assert.IsNotEmpty(ratingFirst);
        }

        public void ConfirmProductsAreInStock()
        {
            ReadOnlyCollection<IWebElement> productElements = comparePageDriver.FindElements(By.CssSelector("td[data-title=\"Availability\"]"));
            string stockFirst = productElements[0].FindElement(By.CssSelector("p.stock")).Text;
            string stockSecond = productElements[1].FindElement(By.CssSelector("p.stock")).Text;

            Assert.That("In stock", Is.EqualTo(stockFirst));
            Assert.That("In stock", Is.EqualTo(stockSecond));
        }

        public void ConfirmProductsAreFromDifferentBrands()
        {
            ReadOnlyCollection<IWebElement> productElements = comparePageDriver.FindElements(By.CssSelector("td[data-title=\"Brand\"]"));
            string brandFirst = productElements[0].FindElement(By.CssSelector("div.wd-compare-brand>img")).GetAttribute("title");
            string brandSecond = productElements[1].FindElement(By.CssSelector("div.wd-compare-brand>picture")).GetAttribute("title");

            Assert.That(brandFirst, Is.Not.EqualTo(brandSecond));
        }

        public void ConfirmProductDoesNotHaveColorSelection()
        {
            ReadOnlyCollection<IWebElement> productElements = comparePageDriver.FindElements(By.CssSelector("td[data-title=\"Color\"]"));
            string elementText = productElements.ElementAt(1).Text;

            Assert.That(elementText.Contains("-"));
        }

        By RemoveFirstProduct = By.CssSelector("a[data-id=\"1162\"]");    
        By RemoveSecondProduct = By.CssSelector("a[data-id=\"1055\"]");

        public void RemoveProducts()
        {

            comparePageDriver.FindElement(RemoveFirstProduct).Click();
            Thread.Sleep(1000);
            comparePageDriver.FindElement(RemoveSecondProduct).Click();

            string pageMessage = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains (text(), \"Compare list is empty.\")]"))).Text;

            string productsNumber = driverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("header.whb-header a[title=\"Compare products\"] span.wd-tools-count"))).Text;

            Assert.That("Compare list is empty.", Is.EqualTo(pageMessage));
            Assert.That("0", Is.EqualTo(productsNumber));
        }
    }
}
