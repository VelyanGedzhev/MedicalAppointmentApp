using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Data.Models
{
    public class Physician
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public int ExamPrice { get; set; }

        [Required]
        public string Speciality { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
