using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using OpenQA.Selenium;

namespace AlzaDemo
{
    public class Helpful
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(ConfigurationManager.AppSettings["ScreenshotPath"] + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg", ScreenshotImageFormat.Png);
        }
    }
}
