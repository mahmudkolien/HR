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
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(u => new KeyValuePairModel(){Id=u.UserRole.Id,Name=u.UserRole.RoleName}));
            CreateMap<User, SaveUserModel>()
                .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(u => u.RoleId));
            CreateMap<UserRole, UserRoleModel>();

            // Model To Domain
            CreateMap<SaveUserModel, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(u => u.UserRoleId));

        }
    }
}