namespace EzTransaction.Controllers;

using EzTransaction.Controllers.Extensions;
using EzTransaction.Models.Config;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.Configure<MySqlConfig>(builder.Configuration.GetSection(typeof(MySqlConfig).Name));

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add business dependencies
        builder.Services.AddBusinessServices();
        builder.Services.AddBusinessRepositories();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}