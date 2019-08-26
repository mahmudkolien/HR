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
            CreateMap<UserRole, UserRoleModel>();
            CreateMap<Department,DepartmentModel>();
            CreateMap<Department,DepartmentSaveModel>();
            CreateMap<Company,CompanyModel>();
            CreateMap<Company,CompanySaveModel>();
            CreateMap<Branch,BranchModel>();
            CreateMap<Branch,BranchSaveModel>();

            // Model To Domain
            CreateMap<UserQueryModel, UserQuery>();
            CreateMap<SaveUserModel, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(u => u.UserRoleId))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<DepartmentSaveModel,Department>();
            CreateMap<CompanySaveModel,Company>();
            CreateMap<BranchSaveModel,Branch>();

        }
    }
}