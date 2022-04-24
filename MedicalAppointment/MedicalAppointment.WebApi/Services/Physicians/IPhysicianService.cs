using MedicalAppointment.WebApi.Services.Physicians.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Physicians
{
    public interface IPhysicianService
    {
        Task<PhysicianModel> GetPhysicianByIdAsync(int id);
        Task<IEnumerable<PhysicianModel>> GetPhysiciansAsync();
        Task<IEnumerable<PhysicianModel>> GetPhysiciansByNameAsync(string name);
    }
}