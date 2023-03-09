


namespace MyDemoProject
{
  //  [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class BaseTestClass
    {
        private readonly SetupDriver setupDriver = new();

        public BasePage basePage;
        public IWebDriver Driver;
        public WebDriverWait Wait;
        public static string BaseUrl;

        [OneTimeSetUp]
        public static async Task BaseOneTimeSetup()
        {
            BaseUrl = SetUpFixture.BaseUrl;
        }

        [SetUp]
        public async Task BaseSetUp()
        {
            Driver = setupDriver.StartDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(SetUpFixture.MaxWaitTimeout));
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
