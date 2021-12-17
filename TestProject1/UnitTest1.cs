using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("c:\\Users\\jakub.holomek\\Automation\\Alza\\AlzaKariera");
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.alza.cz/kariera"; 
            var value = ConfigurationManager.AppSettings["SutUrl"];
        }


        public void TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(ConfigurationManager.AppSettings["ScreenshotUrl"] + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}