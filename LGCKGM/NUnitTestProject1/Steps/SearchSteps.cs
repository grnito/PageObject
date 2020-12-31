using GoogleMaps_Testing.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace GoogleMaps_Testing.Steps
{

    [Binding]
    public class SearchSteps : DriverHelper
    {
        MapsPage mapsPage = new MapsPage();
        [Given(@"I navigate to Google Maps")]
        public void GivenINavigateToGoogleMaps()
        {
            mapsPage.GoTo();
        }

        [Given(@"I Accept cookies")]
        public void GivenIAcceptCookies()
        {
            mapsPage.SwitchIframe();
            mapsPage.IntroAgreeClick();
            mapsPage.SwitchIframeParent();
        }
        
        [Given(@"Enter ""(.*)"" in the search Box")]
        public void GivenEnterDublinInTheSearchBox(string p0)
        {
            mapsPage.TypeSearch(p0);
        }

        [Given(@"click search")]
        public void GivenClickSearch()
        {
            mapsPage.ClickSearch();
        }

        [Given(@"Verify left panel has ""(.*)"" as a headline text")]
        public void GivenVerifyLeftPanelHasAsAHeadlineText(string p0)
        {
            Assert.AreEqual(p0, mapsPage.AssertName());
        }

        [When(@"Click Directions icon")]
        public void WhenClickDirectionsIcon()
        {
            mapsPage.DestinationClick();
        }

        [Then(@"Verify destination field is ""(.*)""")]
        public void ThenVerifyDestinationFieldIs(string p0)
        {
            Assert.AreEqual(p0, mapsPage.AssertDestination());
        }
    }
}
