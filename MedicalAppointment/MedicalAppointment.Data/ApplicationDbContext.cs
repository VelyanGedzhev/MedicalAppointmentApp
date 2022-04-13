using MedicalAppointment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Data
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
