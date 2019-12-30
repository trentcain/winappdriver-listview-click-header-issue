using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListviewClickHeaderIssue.Tests
{
    public class SampleAppSession : IDisposable
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        public WindowsDriver<WindowsElement> Session;

        // Source: https://stackoverflow.com/a/283917/10515370
        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public SampleAppSession(TestContext context, int itemCount)
        {
            // Launch Calculator application if it is not yet launched
            if (Session == null)
            {
                string workingDir = AssemblyDirectory.Replace("ListviewClickHeaderIssue.Tests", "ListviewClickHeaderIssue.SampleApp");
                var appiumOptions = new OpenQA.Selenium.Appium.AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", $@"{workingDir}\ListviewClickHeaderIssue.SampleApp.exe");
                appiumOptions.AddAdditionalCapability("appArguments", itemCount);
                appiumOptions.AddAdditionalCapability("appWorkingDir", workingDir);

                context.WriteLine($"Setting up options {appiumOptions.ToString()}");

                Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                Assert.IsNotNull(Session);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public void Dispose()
        {
            // Close the application and delete the session
            if (Session != null)
            {
                Session.Quit();
                Session = null;
            }
        }
    }
}
