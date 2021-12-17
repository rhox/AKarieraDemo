using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AlzaDemo.Pages
{
    class PositionGroupPage
    {
        private IWebDriver driver;

        public PositionGroupPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public int ReturnPositionsCount()
        {
            System.Threading.Thread.Sleep(2000);
            return new List<IWebElement>(driver.FindElements(By.XPath("//a[@class='row ng-star-inserted']"))).Count;
        }


        public PositionDetailPage OpenPositionOnIndex(int i)
        {
            driver.FindElements(By.XPath("//a[@class='row ng-star-inserted']"))[i].Click();
            System.Threading.Thread.Sleep(2000);
            return new PositionDetailPage(driver);
        }
    }
}
