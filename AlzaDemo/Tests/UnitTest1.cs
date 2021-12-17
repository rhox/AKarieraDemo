using System.Configuration;
using System.IO;
using System.Reflection;
using AlzaDemo.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlzaDemo.Tests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Test]
        public void Test1()
        {
            driver.Url = ConfigurationManager.AppSettings["SutUrl"];
            var mainPage = new MainPage(driver);

            mainPage.FindPosition("Quality assurance");
            var groupPositionPage = mainPage.NavigateToPositionGroup();

            for(int i = 0; i < groupPositionPage.ReturnPositionsCount(); i++)
            {
                var positionPage = groupPositionPage.OpenPositionOnIndex(i);
                positionPage.VerifyDefaultState();
                positionPage.NavigateBack();
            }

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