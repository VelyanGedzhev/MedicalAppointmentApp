using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicalAppointment.WebApi.Data;
using MedicalAppointment.WebApi.Data.Models;
using MedicalAppointment.WebApi.Services.Appointments.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<AppointmentDetailsModel>> GetAppointmentsByUserIdAsync(int id)
        {
            var appointments = await this.dbContext.Appointments.Where(ap => ap.AppUserId == id)
                .ProjectTo<AppointmentDetailsModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return appointments;
        }

        public async Task<AppointmentModel> BookAppointmentAsync(AppointmentModel appointment)
        {
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
