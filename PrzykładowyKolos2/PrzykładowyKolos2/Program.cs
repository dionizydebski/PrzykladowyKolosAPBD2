using Microsoft.EntityFrameworkCore;
using PharmacyApi.Services;
using PrzykładowyKolos2.Context;
using PrzykładowyKolos2.Repositories;
using PrzykładowyKolos2.Services;

namespace PrzykładowyKolos2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //Registering services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IWytworniaRepository, WytworniaRepository>();
        builder.Services.AddScoped<IWytworniaService, WytworniaService>();
        
        builder.Services.AddDbContext<ApbdContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        //Configuring the HTTP request pipeline
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