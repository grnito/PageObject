using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace GoogleMaps_Testing.Hooks
{
    [Binding]
    public sealed class Hooks1 : DriverHelper
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");
            Driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}