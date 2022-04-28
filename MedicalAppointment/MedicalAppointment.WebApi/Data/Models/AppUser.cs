using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Data.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
