using GoogleMaps_Testing.Hooks;
using OpenQA.Selenium;

namespace GoogleMaps_Testing.Pages
{
    public class MapsPage : DriverHelper
    {

        IWebElement iFrameElement => Driver.WaitGetElement(By.ClassName("widget-consent-frame"));
        IWebElement agreeButton => Driver.WaitGetElement(By.XPath("//*[@jscontroller=\"soHxf\"]"));
        IWebElement searchInput => Driver.WaitGetElement(By.Id("searchboxinput"));
        IWebElement searchButton => Driver.WaitGetElement(By.Id("searchbox-searchbutton"));
        IWebElement getLocationName => Driver.WaitGetElement(By.XPath("//*[@jsan=\"7.x3AX1-LfntMc-header-title-title,7.gm2-headline-5\"]"));
        IWebElement destinationButton => Driver.WaitGetElement(By.XPath("//*[@data-value=\"Directions\"]"));
        IWebElement finalDestination => Driver.WaitGetElement(By.XPath("//input[@class='tactile-searchbox-input'][@placeholder='']"));

        public void SwitchIframe() => Driver.SwitchTo().Frame(iFrameElement);
        public void SwitchIframeParent() => Driver.SwitchTo().ParentFrame();
        public void IntroAgreeClick() => agreeButton.Click();
        public void TypeSearch(string location) => searchInput.SendKeys(location);
        public void ClickSearch() => searchButton.Click();
        public void DestinationClick() => destinationButton.Click();

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.google.com/maps?hl=en&tab=ml");
        }

        public string AssertName()
        {
            return getLocationName.Text;
        }
        public string AssertDestination()
        {
            return finalDestination.GetAttribute("aria-label");
        }
    }
}
