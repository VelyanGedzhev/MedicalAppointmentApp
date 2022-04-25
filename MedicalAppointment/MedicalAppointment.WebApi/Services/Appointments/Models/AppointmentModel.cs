using System;

namespace MedicalAppointment.WebApi.Services.Appointments.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public DateTime Date { get; set; }
    }
}
