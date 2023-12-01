using SortedCodingTest.App;
using SortedCodingTest.App.Interfaces;
using SortedCodingTest.Host;
using SortedCodingTest.Rainfall.Client;

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
            builder.Services.AddInvalidModelStateHandler();
            builder.Services.AddRainfallApiClient(builder.Configuration);
            builder.Services.AddTransient<IRainfallService, RainfallService>();

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