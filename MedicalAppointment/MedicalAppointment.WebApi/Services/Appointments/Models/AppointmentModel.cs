using MedicalAppointment.WebApi.Services.Physicians.Models;
using MedicalAppointment.WebApi.Services.Users.Models;
using System;

namespace MedicalAppointment.WebApi.Services.Appointments.Models
{
    public class AppointmentModel
    {
        public int AppUserId { get; set; }
        public AppUserModel AppUser { get; set; }
        public int PhysicianId { get; set; }
        public PhysicianModel Physician { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
