using MedicalAppointment.WebApi.Services.Users;
using MedicalAppointment.WebApi.Services.Users.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserModel>> GetUser(int id)
        {
            return await this.userService.GetUserByIdAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<AppUserModel>> GetUsers()
        {
            return await this.userService.GetUsersAsync();
        }
    }
}
