using System.Reflection;
using Microsoft.Extensions.Configuration;
using FinanceTrackerAPI.Core.Utilities.Configuration.Sections;

namespace FinanceTrackerAPI.Core.Utilities.Configuration
{
    public static class AppSettings
    {
        private static IConfigurationRoot? _ConfigRoot;

        private static string? ApplicationExeDirectory()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);

            return appRoot;
        }

        private static IConfigurationRoot GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(ApplicationExeDirectory()!)
            .AddJsonFile("appsettings.json");

            _ConfigRoot ??= builder.Build();
            return _ConfigRoot;
        }

        public static Documentation? Documentation => GetAppSettings().GetSection(nameof(Documentation)).Get<Documentation>();
    }
}
