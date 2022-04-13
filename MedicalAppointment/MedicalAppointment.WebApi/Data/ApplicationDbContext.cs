using MedicalAppointment.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
