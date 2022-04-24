using MedicalAppointment.WebApi.Services.Physicians;
using MedicalAppointment.WebApi.Services.Physicians.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Controllers
{
    public class PhysiciansController : BaseController
    {
        private readonly IPhysicianService physicianService;

        public PhysiciansController(IPhysicianService physicianService)
        {
            this.physicianService = physicianService;
        }

        [HttpGet]
        public async Task<IEnumerable<PhysicianModel>> GetPhysicians()
        {
            return await this.physicianService.GetPhysiciansAsync();
        }

        [HttpGet("{name}")]
        public async Task<PhysicianModel> GetPhysicianByName(string name)
        {
            return await this.physicianService.GetPhysicianByNameAsync(name);
        }
    }
}