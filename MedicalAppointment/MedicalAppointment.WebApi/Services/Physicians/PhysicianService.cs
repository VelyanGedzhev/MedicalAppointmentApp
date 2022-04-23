using AutoMapper;
using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Services.Physicians.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Physicians
{
    public class PhysicianService : IPhysicianService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public PhysicianService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PhysicianModel>> GetPhysiciansAsync()
        {
            var physicians = await this.dbContext.Physicians.ToListAsync();

            return this.mapper.Map<IEnumerable<PhysicianModel>>(physicians);
        }
    }
}