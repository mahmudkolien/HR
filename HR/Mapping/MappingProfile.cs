using System.Linq;
using AutoMapper;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Models;
using HR.Models.QueryModels;

namespace HR.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To Model
            CreateMap(typeof(QueryResult<>), typeof(QueryResultModel<>));
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(u => new KeyValuePairModel(){Id=u.UserRole.Id,Name=u.UserRole.RoleName}));
            CreateMap<User, SaveUserModel>()
                .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(u => u.RoleId));
            CreateMap<UserRole, UserRoleModel>()
                .ForMember(dest => dest.UserRolePermissions, opt => opt.MapFrom(x => x.UserRolePermissions.Select(y => new KeyValuePairModel { Id = y.Id, Name = y.Permission })));
            CreateMap<UserRole, SaveUserRoleModel>()
                .ForMember(dest => dest.UserRolePermissions, opt => opt.MapFrom(x => x.UserRolePermissions.Select(y => y.Permission)));
            CreateMap<User, AuthenticateUserModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(u => u.UserRole.RoleName));
            
            // Model To Domain
            CreateMap<UserQueryModel, UserQuery>();
            CreateMap<SaveUserModel, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(u => u.UserRoleId))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UserRoleQueryModel, UserRoleQuery>();
            CreateMap<SaveUserRoleModel, UserRole>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserRolePermissions, opt => opt.MapFrom(r => r.UserRolePermissions.Select(per => new UserRolePermission { Permission =  per})));
                // .ForMember(dest => dest.UserRolePermissions, opt => opt.Ignore())
                // .AfterMap((model, entity) => {
                //     // Remove unselected Role Permissions
                //     var removedRolePermissions = entity.UserRolePermissions.Where(r => !model.UserRolePermissions.Contains(r.Permission)).ToList();
                //     foreach (var per in removedRolePermissions)
                //         entity.UserRolePermissions.Remove(per);

                //     // Add new Role Permissions
                //     var addedRolePermissions = model.UserRolePermissions.Where(per => !entity.UserRolePermissions.Any(r => r.Permission == per)).Select(per => new UserRolePermission { Permission = per }).ToList();   
                //     foreach (var per in addedRolePermissions)
                //         entity.UserRolePermissions.Add(per);
                // });

        }
    }
}