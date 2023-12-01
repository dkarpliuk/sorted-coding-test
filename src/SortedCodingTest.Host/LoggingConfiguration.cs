using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace SortedCodingTest.Rainfall.Client
{
    public static class LoggingConfiguration
    {
        private const int FileSizeLimitBytes = 1024 * 1024;

        public static ILoggingBuilder AddLoggingConfiguration(this ILoggingBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    $"{AppDomain.CurrentDomain.BaseDirectory}/logs/.log",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: FileSizeLimitBytes,
                    rollOnFileSizeLimit: true)
                .WriteTo.Console()
                .CreateLogger();

            builder.ClearProviders();
            builder.AddSerilog();

            return builder;
        }
    }
}