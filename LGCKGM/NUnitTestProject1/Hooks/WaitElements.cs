using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMaps_Testing.Hooks
{
    public static class ExtensionMethods
    {
        public static IWebElement WaitGetElement(this IWebDriver driver, By by, int timeoutInSeconds = 25, bool allowDisabledElement = false)
        {
            return WaitGetElements(driver, by, timeoutInSeconds, allowDisabledElement).First();
        }

        public static IList<IWebElement> WaitGetElements(this IWebDriver driver, By by, int timeoutInSeconds = 25, bool allowDisabledElement = false)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(InvalidOperationException),
                typeof(ElementNotInteractableException),
                typeof(ElementNotVisibleException),
                typeof(InvalidElementStateException));

            try
            {
                return wait.Until(d =>
                {
                    var elements = d.FindElements(by);
                    if (elements.Any())
                    {
                        if (!elements.First().Displayed)
                        {
                            throw new ElementNotVisibleException();
                        }

                        if (!allowDisabledElement && !elements.First().Enabled)
                        {
                            throw new ElementNotInteractableException();
                        }
                    }
                    else
                    {
                        throw new NoSuchElementException();
                    }

                    return elements;
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " with the following selector: " + by.ToString());
            }
        }
    }
}