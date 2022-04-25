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
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Physician>()
                .HasMany(a => a.Appointments)
                .WithOne(p => p.Physician)
                .HasForeignKey(a => a.PhysicianId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AppUser>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.AppUser)
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
