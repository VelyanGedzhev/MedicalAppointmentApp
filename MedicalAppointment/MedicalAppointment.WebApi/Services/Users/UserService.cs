using AutoMapper;
using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Data.Models;
using MedicalAppointment.WebApi.Services.Tokens;
using MedicalAppointment.WebApi.Services.Users.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public UserService(ApplicationDbContext dbContext, ITokenService tokenService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        public async Task<AppUserModel> GetUserByIdAsync(int id)
        {
            var user = await this.dbContext.Users.FindAsync(id);

            return this.mapper.Map<AppUserModel>(user);
        }

        public async Task<IEnumerable<AppUserModel>> GetUsersAsync()
        {
            var users = await this.dbContext.Users.ToListAsync();

            return this.mapper.Map<IEnumerable<AppUserModel>>(users);
        }

        public async Task<AppUserModel> LoginUserAsync(LoginModel userLogin)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(user => user.Username == userLogin.Username);

            if (user == null) return null;

            using var hmac = new HMACSHA256(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            var loggedUser = this.mapper.Map<AppUserModel>(user);
            loggedUser.Token = this.tokenService.CreateToken(user.Username);

            return loggedUser;
        }

        public async Task<AppUserModel> RegisterUserAsync(RegisterModel userRegister)
        {
            var usernameExists = await UsernameExistsAsync(userRegister.Username);

            if (usernameExists) return null;

            using var hmac = new HMACSHA256();

            var userToRegister = new AppUser
            {
                Username = userRegister.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegister.Password)),
                PasswordSalt = hmac.Key
            };

            await this.dbContext.Users.AddAsync(userToRegister);
            await this.dbContext.SaveChangesAsync();

            var user = this.mapper.Map<AppUserModel>(userToRegister);

            return user;
        }

        private async Task<bool> UsernameExistsAsync(string username)
        {
            return await this.dbContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
