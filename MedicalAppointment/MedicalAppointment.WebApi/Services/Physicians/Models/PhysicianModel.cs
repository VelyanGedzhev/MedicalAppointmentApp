using MedicalAppointment.WebApi.Services.Appointments.Models;
using System.Collections.Generic;

namespace MedicalAppointment.WebApi.Services.Physicians.Models
{
    public class PhysicianModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ExamPrice { get; set; }
        public string Speciality { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
    }
}
