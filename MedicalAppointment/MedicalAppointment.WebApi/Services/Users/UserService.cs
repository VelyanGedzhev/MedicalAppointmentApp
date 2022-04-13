using AutoMapper;
using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Services.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
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
    }
}
