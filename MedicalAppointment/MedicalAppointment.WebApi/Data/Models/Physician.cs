﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.WebApi.Data.Models
{
    public class Physician
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public int ExamPrice { get; set; }

        [Required]
        public string Speciality { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
