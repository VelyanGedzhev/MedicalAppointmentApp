using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Services.Users.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
