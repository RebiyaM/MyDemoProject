using Microsoft.Extensions.Configuration;

namespace MyDemoProject
{
    /// <summary>
    /// This class will find praramaters from appsettings to
    /// use for set up data.
    /// </summary>
    [SetUpFixture]
    public class SetUpFixture
    {
        public static readonly string WorkingDir = FileManagement.WorkingDir;
        public static readonly string ProjectDir = FileManagement.ProjectDir;
        public static readonly string driversPath = $"{AppDomain.CurrentDomain.BaseDirectory}";
        public static string Username;
        public static string Password;
        public static string Browser;
        public static string BaseUrl;

        public static int MaxWaitTimeout;

        public static bool TakeScreenshotOnFailure;
        [OneTimeSetUp]
        public async Task RunOnceSetup()
        {
            SetConfig();

        }

        public static void SetConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(ProjectDir, "appSettings.json"));
            var root = builder.Build();

            Browser = root.GetSection("browser").Value;
            Password = root.GetSection("password").Value;
            Username = root.GetSection("username").Value;
            BaseUrl = root.GetSection("baseUrl").Value;

            MaxWaitTimeout = int.Parse(root.GetSection("maxWaitTimeout").Value);
        }

    }
}
