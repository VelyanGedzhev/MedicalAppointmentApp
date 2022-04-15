using MedicalAppointment.WebApi.Services.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Users
{
    public interface IUserService
    {
        Task<AppUserModel> GetUserByIdAsync(int id);
        Task<IEnumerable<AppUserModel>> GetUsersAsync();
        Task<AppUserModel> RegisterUserAsync(RegisterModel userRegister);
    }
}
