using AutoMapper;
using MedicalAppointment.WebApi.Data.Models;
using MedicalAppointment.WebApi.Services.Physicians.Models;
using MedicalAppointment.WebApi.Services.Users.Models;

namespace MedicalAppointment.WebApi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AppUser, AppUserModel>().ReverseMap();
            this.CreateMap<Physician, PhysicianModel>();
        }
    }
}
