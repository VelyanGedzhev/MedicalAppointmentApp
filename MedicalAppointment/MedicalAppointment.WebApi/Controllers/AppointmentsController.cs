﻿using MedicalAppointment.WebApi.Services.Appointments;
using MedicalAppointment.WebApi.Services.Appointments.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebApi.Controllers
{
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<AppointmentModel>> GetAppointments(int id)
        {
            return await this.appointmentService.GetAppointmentsByUserIdAsync(id);
        }
    }
}