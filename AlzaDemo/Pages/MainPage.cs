using System;
using System.Configuration;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AlzaDemo.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "position")]
        private IWebElement SearchEditBox;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// 
        /// </summary>
        public void GotoPage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["SutUrl"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionName"></param>
        public void FindPosition(string positionName)
        {
            SearchEditBox.SendKeys(positionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PositionGroupPage NavigateToPositionGroup()
        {
            driver.FindElement(By.XPath("//a[@href='/kariera/pozice/quality-assurance']")).Click();
            return new PositionGroupPage(driver);
        }
    }
}
