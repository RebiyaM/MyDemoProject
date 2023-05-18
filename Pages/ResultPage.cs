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
        public IWebElement PhoneNumber => Find(By.XPath("//span[@class='LrzXr zdqRlf kno-fv']"));

        public string GetPhoneNumber()
        {
            string phoneNumber="";
            return phoneNumber = PhoneNumber.Text;
        }


    }
}
