namespace MedicalAppointment.WebApi.Services.Users.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Token { get; set; }
    }
}
