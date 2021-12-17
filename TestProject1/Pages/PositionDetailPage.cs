using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages
{
    class PositionDetailPage
    {
        private IWebDriver driver;

        public PositionDetailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


    }
}
