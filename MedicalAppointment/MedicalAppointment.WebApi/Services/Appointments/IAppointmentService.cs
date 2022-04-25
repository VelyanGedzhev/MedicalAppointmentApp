using MedicalAppointment.WebApi.Services.Appointments.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Appointments
{
    public interface IAppointmentService
    {
        Task<AppointmentModel> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentModel>> GetAppointmentsByUserIdAsync(int id);
        Task<AppointmentModel> BookAppointmentAsync(AppointmentModel appointment);
    }
}