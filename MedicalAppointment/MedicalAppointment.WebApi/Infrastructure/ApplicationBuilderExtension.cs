﻿using MedicalAppointment.WebApi.Data;
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
            SeedPhysicians(services);
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

        private static void SeedPhysicians(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Physicians.Any())
            {
                return;
            }

            data.Physicians.AddRange(new[]
            {
                new Physician { Name = "John Miller", Gender = "Male", City = "Boston", Address = "Newbury Street", ExamPrice = 50, Speciality = "Cardiologist", ImageUrl = DataConstants.DefaultMaleImageUrl},
                new Physician { Name = "Annie Cash", Gender = "Female", City = "Los Angeles", Address = "Hollywood Boulevard", ExamPrice = 100, Speciality = "Oncologist", ImageUrl = DataConstants.DefaultFemaleImageUrl},
                new Physician { Name = "Ben Huston", Gender = "Male", City = "New York", Address = "Minetta Street", ExamPrice = 45, Speciality = "Familly Physician", ImageUrl = DataConstants.DefaultMaleImageUrl},
                new Physician { Name = "Dominique McElligott", Gender = "Female", City = "New York", Address = "Cranberry Street", ExamPrice = 75, Speciality = "Familly Physician", ImageUrl = DataConstants.DefaultFemaleImageUrl},
                new Physician { Name = "Erin Moriarty ", Gender = "Female", City = "New York", Address = "West 10th Street", ExamPrice = 60, Speciality = "Familly Physician", ImageUrl = DataConstants.DefaultFemaleImageUrl},
            });

            data.SaveChanges();
        }
    }
}