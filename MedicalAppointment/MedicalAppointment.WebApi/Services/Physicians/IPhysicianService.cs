using MedicalAppointment.WebApi.Services.Physicians.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Physicians
{
    public interface IPhysicianService
    {
        Task<IEnumerable<PhysicianModel>> GetPhysiciansAsync();

        Task<PhysicianModel> GetPhysicianByNameAsync(string name);
    }
}