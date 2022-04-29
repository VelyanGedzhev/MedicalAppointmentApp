namespace MedicalAppointment.WebApi.Services.Appointments.Models
{
    public class AppointmentDetailsModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string Date { get; set; }
    }
}
