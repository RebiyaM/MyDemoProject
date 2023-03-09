using SeleniumExtras.WaitHelpers;

namespace MyDemoProject
{
    /// <summary>
    /// Base level page object with common page elements.
    /// </summary>
    public abstract class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        private BaseTestClass BaseTest = new();
        public  int HourOfTheDay = currentTime.Hour;
        public static TimeZoneInfo tzi = TZConvert.GetTimeZoneInfo("Pacific Standard Time");
        public static DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, tzi);
        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            driver = BaseTest.Driver;
            wait = BaseTest.Wait;
            this.driver = driver;
            this.wait = wait;
        }

        public void ClickAndRetry(IWebElement elementToClick, By by, int maxTimeOut = 35)
        {
            elementToClick.Click();
            try
            {
                Find(by, maxTimeOut);
            }
            catch (WebDriverTimeoutException)
            {
                elementToClick.Click();
            }
            catch (StaleElementReferenceException)
            {
                elementToClick.Click();
            }
            catch (ElementClickInterceptedException)
            {
                elementToClick.Click();
            }
        }

        public IWebElement Find(By by, int maxTimeOut = 0)
        {
            WaitFor(by, maxTimeOut);

            if (maxTimeOut != 0) wait.Timeout = TimeSpan.FromSeconds(SetUpFixture.MaxWaitTimeout);

            return driver.FindElement(by);
        }

        public IWebElement FindById(string id, int maxTimeOut = 30)
        {
            WaitFor(By.Id(id));
            return driver.FindElement(By.Id(id));
        }



        /// <summary>
        /// Automatic retry when wait condition fails
        /// </summary>
        public virtual void WaitFor(By by, int maxTimeout = 0)
        {
            //If the max timeout is not passed, then take the value from the appsettings.config
            if (maxTimeout == 0)
            {
                wait.Timeout = TimeSpan.FromSeconds(SetUpFixture.MaxWaitTimeout);
            }
            else
            {
                wait.Timeout = TimeSpan.FromSeconds(maxTimeout);
            }

            IWebElement elementToBeDisplayed;
            var element = wait.Until(condition =>
            {
                try
                {
                    wait.Until(condition => ExpectedConditions.StalenessOf(driver.FindElement(by)));
                    elementToBeDisplayed = driver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotInteractableException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });

            if (maxTimeout != SetUpFixture.MaxWaitTimeout)
                wait.Timeout = TimeSpan.FromSeconds(SetUpFixture.MaxWaitTimeout);
        }

        public string CurrentURL => driver.Url;

        public bool IsElementDisplayed(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
