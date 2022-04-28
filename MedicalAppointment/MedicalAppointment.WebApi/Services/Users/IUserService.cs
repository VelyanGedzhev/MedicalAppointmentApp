using MedicalAppointment.WebApi.Services.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Users
{
    public interface IUserService
    {
        Task<UserModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetUsersAsync();
        void Update(UserModel user);
        Task<bool> SaveAllAsync();
        Task<UserModel> LoginUserAsync(UserLoginModel loginModel);
        Task<UserModel> RegisterUserAsync(UserRegisterModel registerModel);
        Task<bool> UpdateUserAsync(UserEditModel editModel, string username);
    }
}
