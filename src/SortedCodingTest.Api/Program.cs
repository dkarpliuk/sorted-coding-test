using SortedCodingTest.Application;
using SortedCodingTest.Application.Interfaces;

namespace SortedCodingTest.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RainfallApiClientOptions>(builder.Configuration.GetSection(nameof(RainfallApiClientOptions)));
            builder.Services.AddTransient<IRainfallApiClient, RainfallApiClient>();
            builder.Services.AddTransient<IRainfallService, RainfallService>();
            builder.Services.AddInvalidModelStateHandler();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}