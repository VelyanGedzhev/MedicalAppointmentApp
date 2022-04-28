using MedicalAppointment.WebApi.Services.Users;
using MedicalAppointment.WebApi.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public async Task<ActionResult<UserModel>> Register(UserRegisterModel registerModel)
        {
            var user = await this.userService.RegisterUserAsync(registerModel);

            if (user == null)
            {
                return BadRequest("Username is already taken");
            }

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(UserLoginModel loginModel)
        {
            var user = await this.userService.LoginUserAsync(loginModel);

            if (user == null)
            {
                return BadRequest("Wrong Username or Password");
            }

            return user;
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserEditModel editModel)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await this.userService.UpdateUserAsync(editModel, username);

            if (!result)
            {
                return BadRequest("Failed to update user");
            }

            return NoContent();
        }
    }
}