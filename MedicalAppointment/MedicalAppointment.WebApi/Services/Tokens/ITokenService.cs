namespace MedicalAppointment.WebApi.Services.Tokens
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
