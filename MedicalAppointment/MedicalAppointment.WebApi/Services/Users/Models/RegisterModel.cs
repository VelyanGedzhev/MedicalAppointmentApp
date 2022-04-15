using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Services.Users.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
