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
            CreateMap<User, SaveUserModel>();
            CreateMap<Department,DepartmentModel>();
            CreateMap<Department,DepartmentSaveModel>();
            CreateMap<Company,CompanyModel>();
            CreateMap<Company,CompanySaveModel>();


            // Model To Domain
            CreateMap<SaveUserModel, User>();
            CreateMap<DepartmentSaveModel,Department>();
            CreateMap<CompanySaveModel,Company>();

        }
    }
}