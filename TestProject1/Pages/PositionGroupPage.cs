using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class PositionGroupPage
    {
        private IWebDriver driver;

        public PositionGroupPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
