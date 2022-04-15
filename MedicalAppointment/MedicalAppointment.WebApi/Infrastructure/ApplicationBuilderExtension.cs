using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MedicalAppointment.WebApi.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            //SeedUsers(services);


            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedUsers(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Users.Any())
            {
                return;
            }

            data.Users.AddRange(new[] 
            {
                new AppUser { Username = "JohnMiller"},
                new AppUser { Username = "StevenTaylor"},
            });

            data.SaveChanges();
        }
    }
}