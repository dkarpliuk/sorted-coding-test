using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace SortedCodingTest.Rainfall.Client
{
    public static class LoggingConfiguration
    {
        public static ILoggingBuilder AddLoggingConfiguration(this ILoggingBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}/logs/.log", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();

            builder.ClearProviders();
            builder.AddSerilog();

            return builder;
        }
    }
}