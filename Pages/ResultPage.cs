namespace MyDemoProject
{
    public class ResultPage : BasePage
    {
        public ResultPage(IWebDriver Driver, WebDriverWait Wait) : base(Driver, Wait)
        {
            driver = Driver;
            wait = Wait;
        }
        public IWebElement SearchBar => Find(By.Id("input"));
        public IWebElement TobeReviewed => Find(By.XPath("//span[text()='Be the first to review']"));
        public IWebElement Closed => Find(By.XPath("//span[text()='Closed']"));
        public IWebElement Opened => Find(By.XPath("//span[text()='Open']"));

        public IWebElement HourGrid(int index) => Find(By.XPath("(//div[@aria-expanded='true']//tbody//tr//td)["+ index+"]"));

        public string GetOperationHours(int index)
        {
            string hours="";

                ClickOnHours();

            return hours=HourGrid(index).Text;
        }

        public void ClickOnHours()
        {
            if (HourOfTheDay>19 || HourOfTheDay<9)
            {

                Closed.Click();
            }
            else if (HourOfTheDay >9 && HourOfTheDay<19)
            {
                Opened.Click();
            }
            else
            {
                Assert.Fail("neither closed nor opened displayed on web");
            }
        }
    }
}
