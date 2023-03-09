namespace MyDemoProject
{
    public class HomePage:BasePage
    {
        public HomePage(IWebDriver Driver, WebDriverWait Wait) : base(Driver, Wait)
        {
            driver = Driver;
            wait = Wait;
        }
        public IWebElement SearchBar => Find(By.Name("q"));

        public void SearchFromGoogle(string searchTerms) => SearchBar.SendKeys(searchTerms + Keys.Enter);
    }
}
