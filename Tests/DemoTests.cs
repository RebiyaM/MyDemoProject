using System.Runtime.Serialization;
using System.Security.AccessControl;

namespace MyDemoProject
{
    [TestFixture,Order(0)]
    [Parallelizable(ParallelScope.All)]
   [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class DemoTests : BaseTestClass
    {
        [TestCase("Service Autopilot", "(972) 728-4040")]
        [TestCase("FieldEdge", "(800) 226-7529")]
        [Category("Smoke")]  
        [Description("Verify field service company phone number from google search")]
        public async Task GoogleSearchPhoneNumberTest(string searchTerm,string expected)
        {
            HomePage googleHome = new(Driver, Wait);
            googleHome.SearchFromGoogle(searchTerm);
            ResultPage result = new(Driver, Wait);
            string phoneNumber=result.GetPhoneNumber();
            Assert.That(phoneNumber, Is.EqualTo(expected));
        }
    }
}
