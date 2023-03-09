namespace MyDemoProject
{

    public class DBTests
    {
        [TestCase("swell energy","Monday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy","Tuesday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy", "Wendesday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy", "Thursday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy", "Friday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy", "Saturday", ExpectedResult = "9 AM–7 PM")]
        [TestCase("swell energy", "Sunday", ExpectedResult = "9 AM–7 PM")]
        [Category("backend")]
        [Description("Verify Swell Energy's operating hours through out the week from google search")]
        public string OperatingHoursTest(string companeName,string week)
        {
            string query="Select COLUMN_hours from Table_Company where Column_Name like'%"+ companeName+
                "%' AND COLUMN_Week like'%" +week+"%'";

            DBConect conect = new DBConect();
           return conect.GetQueryResult("some conenction string",query).ToString();
            
        }
    }
}
