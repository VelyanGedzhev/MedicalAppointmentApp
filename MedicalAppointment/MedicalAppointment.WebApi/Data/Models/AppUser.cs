using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Data.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
