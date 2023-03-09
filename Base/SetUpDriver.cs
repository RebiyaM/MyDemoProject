namespace MyDemoProject
{
    public class SetupDriver
    {
        //Member variables
        protected IWebDriver WebDriver;

        private readonly string DriversPath = $"{AppDomain.CurrentDomain.BaseDirectory}";

        /// <summary>
        /// Start WebDriver
        /// </summary>
        public IWebDriver StartDriver()
        {
            switch (SetUpFixture.Browser)
            {
                case "firefox":
                    FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService();
                    geckoService.Host = "::1";

                    WebDriver = new FirefoxDriver(geckoService, FfOptions(), TimeSpan.FromSeconds(360));
                    break;

                case "chrome":
                    WebDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), ChromeProfile(), TimeSpan.FromSeconds(360));
                    break;

                default:
                    WebDriver = new ChromeDriver(DriversPath, ChromeProfile());
                    break;
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            return WebDriver;
        }

        /// <summary>
        /// Sets the firefox preferences before startup.
        /// </summary>
        /// <returns></returns>
        private static FirefoxOptions FfOptions()
        {
            FirefoxOptions options = new();

            options.AcceptInsecureCertificates = true;
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", true);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.manager.closeWhenDone", false);
            options.SetPreference("browser.download.animateNotifications", false);
            options.SetPreference("widget.windows.window_occlusion_tracking.enabled", false);
            options.SetPreference("browser.download.folderList", 1);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
            options.LogLevel = FirefoxDriverLogLevel.Trace;

            return options;
        }


        /// <summary>
        /// Create a custom Chrome profile to allow easy file downloading.
        /// </summary>
        /// <returns></returns>
        private static ChromeOptions ChromeProfile()
        {
            ChromeOptions options = new();
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--incognito");
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddUserProfilePreference("disable-popup-blocking", true);
            options.AddUserProfilePreference("chrome.switches", "--disable-extensions");
            options.AddUserProfilePreference("chrome.switches", "--disable-web-security");
            options.AddUserProfilePreference("chrome.switches", "--allow-running-insecure-content");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArgument("--disable-gpu");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            return options;
        }

    }
}
