using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AlzaDemo.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace AlzaDemo.Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["SeleniumHubUrl"]), new ChromeOptions()); //remote driver against selenium hub
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestPosition()
        {
            var mainPage = new MainPage(driver);
            mainPage.GotoPage();

            mainPage.FindPosition("Quality assurance");
            var groupPositionPage = mainPage.NavigateToPositionGroup();

            for(int i = 0; i < groupPositionPage.ReturnPositionsCount(); i++)
            {
                var positionPage = groupPositionPage.OpenPositionOnIndex(i);
                positionPage.VerifyDefaultState();
                positionPage.NavigateBack();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /*
        Variant
         1)Take list of hrefs and use httpconnection
         2)Find all link elements - verify transition by clicking to index one by one
         3)Find list of hrefs and find elements by href link and click on it
         4)Find all link elements - verify transition by navigating to href links - only one acceptable
        */
        [Test]
        public void TestHref()
        {
            var mainPage = new MainPage(driver);
            mainPage.GotoPage();
            var links = driver.FindElements(By.TagName("a"));
            var linkList = new List<String>();
           // get all working links from webpage 
            for (int i = 0; i < links.Count; i++)
            {
                var href = links[i].GetAttribute("href");
                if (href == null) continue;
                linkList.Add(href);
            }
            // navigate to each Link on the webpage
            foreach (var item in linkList)
            {
                driver.Navigate().GoToUrl(item);
                try
                {
                    var error = driver.FindElements(By.XPath("//span[text()='404']"));
                    Assert.That(error, Is.Not.Null, "A element with href " + item + " does not work");
                }
                catch (NoSuchElementException)
                {
                    mainPage.GotoPage();
                    System.Threading.Thread.Sleep(2000);
                }
            }


            /*
            cloudflare - does not work due to captcha

            foreach (var link in links)
            {
                var href = link.GetAttribute("href");
                if (href == null) continue;                
                using (var webClient = new HttpClient())
                {
                    var response = webClient.GetAsync(href).Result;
                    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }
            */
        }



        [TearDown]
        public void Close()
        { 
            Helpful.TakeScreenshot(driver);
            driver.Close();
            driver.Quit();
        }



    }
}