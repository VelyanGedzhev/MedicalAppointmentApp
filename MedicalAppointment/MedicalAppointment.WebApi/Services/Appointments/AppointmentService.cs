using AutoMapper;
using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Data.Models;
using MedicalAppointment.WebApi.Services.Appointments.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Services.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AppointmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AppointmentModel> GetAppointmentByIdAsync(int id)
        {
            var appointment = await this.dbContext.Appointments.FindAsync(id);

            return this.mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByUserIdAsync(int id)
        {
            var appointments = await this.dbContext.Appointments.Where(ap => ap.AppUserId == id).ToListAsync();

            return this.mapper.Map<IEnumerable<AppointmentModel>>(appointments);
        }

        public async Task<AppointmentModel> BookAppointmentAsync(AppointmentModel appointment)
        {

            if (appointment.Date.Date < DateTime.UtcNow)
            {
                return null;
            }

            bool isbBooked = IsBooked(appointment.Date.Date, appointment.PhysicianId);

            if (isbBooked)
            {
                return null;
            }

            var appointmentToAdd = new Appointment
            {
                AppUserId = appointment.AppUserId,
                PhysicianId = appointment.PhysicianId,
                Date = appointment.Date.Date
            };

            await this.dbContext.Appointments.AddAsync(appointmentToAdd);
            await this.dbContext.SaveChangesAsync();

            return this.mapper.Map<AppointmentModel>(appointmentToAdd);
        }

        private bool IsBooked(DateTime appointmantDate, int physicianId)
            => this.dbContext
                .Appointments
                .Any(a => a.Date == appointmantDate && a.PhysicianId == physicianId);
    }
}
