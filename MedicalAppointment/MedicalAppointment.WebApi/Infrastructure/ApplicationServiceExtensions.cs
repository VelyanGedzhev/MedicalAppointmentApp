using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Services.Appointments;
using MedicalAppointment.WebApi.Services.Physicians;
using MedicalAppointment.WebApi.Services.Tokens;
using MedicalAppointment.WebApi.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.WebApi.Infrastructure
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhysicianService, PhysicianService>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
