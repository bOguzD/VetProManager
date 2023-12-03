using AutoMapper;
using VetProManager.DAL.Modules.Security;
using VetProManager.DAL.Modules.Shared;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Mapper {
    public class AutoMapper : Profile {
        public AutoMapper() {
            CreateMap<Species, SpeciesDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
