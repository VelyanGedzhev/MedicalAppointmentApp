using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Services.Users.Models
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
