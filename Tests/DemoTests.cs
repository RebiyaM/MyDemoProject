using System.Runtime.Serialization;
using System.Security.AccessControl;

namespace MyDemoProject
{
    [TestFixture,Order(0)]
   // [Parallelizable(ParallelScope.All)]
  //  [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class DemoTests : BaseTestClass
    {

        [TestCase("swell energy", 2)]
        [TestCase("swell energy", 4)]
        [TestCase("swell energy", 6)]
        [TestCase("swell energy", 8)]
        [TestCase("swell energy", 10)]
        [TestCase("swell energy", 12)]
        [TestCase("swell energy", 14)]
        [Category("Smoke")]
      //  [Ignore("bug")]
        [Description("Verify Swell Energy's operating hours through out the week from google search")]
        public async Task OperatingHoursTest(string searchTerm, int indexInGrid)
        {
            string expectedHours = "9 AM–7 PM";

            HomePage googleHome = new(Driver, Wait);
            googleHome.SearchFromGoogle(searchTerm);
            if (SetUpFixture.Browser == "chrome") { Assert.IsTrue(Driver.Title.Equals("swell energy - Google Search")); }
            
            ResultPage result = new(Driver, Wait);
            string hourInTheWeek=result.GetOperationHours(indexInGrid);
            Assert.That(hourInTheWeek,Is.EqualTo( expectedHours));
        }
    }
}
