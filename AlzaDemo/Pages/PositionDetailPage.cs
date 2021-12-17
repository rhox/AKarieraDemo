using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AlzaDemo.Pages
{
    class PositionDetailPage
    {
        private IWebDriver driver;
        private readonly Dictionary<string, string> listOfPeople = new Dictionary<string, string>
        {
            { "Řihová Simona", "https://cdn.alza.cz/foto/JobPositions/orig/6b9a4e38-6150-4ac7-9d2b-e89a1b385f10.jpg" }, 
            { "Absolín Martin", "https://cdn.alza.cz/foto/JobPositions/orig/3b732293-f54c-4d5e-a514-11510419b0dc.jpg" }, 
            { "Tomusko Ján", "https://cdn.alza.cz/foto/JobPositions/orig/a7caf904-7044-4658-97bc-53075fcb815c.jpg" }, 
            { "Minařík Jan", "https://cdn.alza.cz/foto/JobPositions/orig/85faf427-c700-470a-ae69-0573cd3b9352.jpg" }
        };

        public PositionDetailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            }

        public void VerifyDefaultState()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//alza-article-body//span[1]")).Text != null, "Description of role is empty");
            foreach (var people in driver.FindElements(By.XPath("//div[@class='card people ng-star-inserted']")))
            {
                var name = people.FindElement(By.TagName("p")).Text;
                Assert.True(people.FindElement(By.XPath("//div[@class='description']")).Text != null, "Description for " + name + " is missing");
                Assert.True(listOfPeople.ContainsKey(name), name + "is unexpected human for QA position to be on interview");
                var imgLocation = people.FindElement(By.TagName("span")).GetAttribute("style").Split('\"')[1];
                Assert.True(listOfPeople[name] == imgLocation, "Unexpected image location for " + name);
            }
        }

        public void NavigateBack()
        {
            driver.Navigate().Back();
        }
    }
}
