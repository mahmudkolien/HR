using AutoMapper;
using HR.Entities;
using HR.Models;

namespace HR.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To Model
            CreateMap<User, UserModel>();
            CreateMap<User, SaveUserModel>();

            // Model To Domain
            CreateMap<SaveUserModel, User>();

        }
    }
}