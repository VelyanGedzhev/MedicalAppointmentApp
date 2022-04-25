using System;

namespace MedicalAppointment.WebApi.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int PhysicianId { get; set; }
        public Physician Physician { get; set; }
        public DateTime Date { get; set; }
    }
}
