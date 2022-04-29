using AutoMapper;
using MedicalAppointment.WebApi.Data.Models;
using MedicalAppointment.WebApi.Services.Appointments.Models;
using MedicalAppointment.WebApi.Services.Physicians.Models;
using MedicalAppointment.WebApi.Services.Users.Models;

namespace MedicalAppointment.WebApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AppUser, UserModel>().ReverseMap();
            this.CreateMap<Physician, PhysicianModel>();
            this.CreateMap<Appointment, AppointmentModel>();
            this.CreateMap<Appointment, AppointmentDetailsModel>()
                .ForMember(
                    d => d.Date,
                    cfg => cfg.MapFrom(s => s.Date.ToString("d")));
            this.CreateMap<UserEditModel, AppUser>();
        }
    }
}
