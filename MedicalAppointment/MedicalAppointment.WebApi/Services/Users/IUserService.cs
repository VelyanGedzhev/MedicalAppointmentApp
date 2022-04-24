using MedicalAppointment.WebApi.Services.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Users
{
    public interface IUserService
    {
        Task<AppUserModel> GetUserByIdAsync(int id);
        Task<IEnumerable<AppUserModel>> GetUsersAsync();
        void Update(AppUserModel user);
        Task<bool> SaveAllAsync();
        Task<AppUserModel> LoginUserAsync(LoginModel userLogin);
        Task<AppUserModel> RegisterUserAsync(RegisterModel userRegister);
    }
}
