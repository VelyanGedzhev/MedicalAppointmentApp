using MedicalAppointment.WebApi.Services.Users;
using MedicalAppointment.WebApi.Services.Users.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUserModel>> Register(RegisterModel userRegister)
        {
            var user = await this.userService.RegisterUserAsync(userRegister);

            if (user == null)
            {
                return BadRequest("Username is already taken");
            }

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUserModel>> Login(LoginModel userLogin)
        {
            var user = await this.userService.LoginUserAsync(userLogin);

            if (user == null)
            {
                return BadRequest("Wrong Username or Password");
            }

            return user;
        }
    }
}