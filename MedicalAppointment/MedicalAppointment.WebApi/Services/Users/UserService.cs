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

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await this.dbContext.Users.FindAsync(id);

            return this.mapper.Map<UserModel>(user);
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var users = await this.dbContext.Users.ToListAsync();

            return this.mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public void Update(UserModel user)
        {
            var userToUpdate = this.mapper.Map<AppUser>(user);
            this.dbContext.Entry(user).State = EntityState.Modified;
        }

        public async Task<UserModel> LoginUserAsync(UserLoginModel userLogin)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(user => user.Username == userLogin.Username);

            if (user == null) return null;

            using var hmac = new HMACSHA256(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            var loggedUser = this.mapper.Map<UserModel>(user);
            loggedUser.Token = this.tokenService.CreateToken(user.Username);

            return loggedUser;
        }

        public async Task<UserModel> RegisterUserAsync(UserRegisterModel userRegister)
        {
            var usernameExists = await UsernameExistsAsync(userRegister.Username);

            if (usernameExists) return null;

            using var hmac = new HMACSHA256();

            var userToRegister = new AppUser
            {
                Username = userRegister.Username,
                Age = userRegister.Age,
                Gender = userRegister.Gender,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegister.Password)),
                PasswordSalt = hmac.Key
            };

            await this.dbContext.Users.AddAsync(userToRegister);
            await this.dbContext.SaveChangesAsync();

            var user = this.mapper.Map<UserModel>(userToRegister);

            return user;
        }

        public async Task<bool> UpdateUserAsync(UserEditModel editModel, string username)
        {
            var user =  await this.dbContext.Users.FirstOrDefaultAsync(u => u.Username == username );

            this.mapper.Map(editModel, user);

            this.dbContext.Users.Update(user);

            var result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        private async Task<bool> UsernameExistsAsync(string username)
        {
            return await this.dbContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
