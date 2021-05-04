using AutoMapper;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Model;
using NoorsoftHomework.Web.Handlers.Employee.Commands;
using NoorsoftHomework.Web.Helpers;
using NoorsoftHomework.Web.Resources;

namespace NoorsoftHomework.Web.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            MapEmployeeToEmployeeResource();
            MapUpdateEmployeeResourceToUpdateEmployeeModel();
            UpdateEmployeeModelToEmployeeResource();
        }

        private void MapEmployeeToEmployeeResource()
        {
            CreateMap<Employee, EmployeeResource>()
                .ForMember(resource => resource.BirthDate,
                           expression => expression.MapFrom(employee => employee.BirthDate.ToPersianDate()))
                .ForMember(resource => resource.RecruitmentDate,
                           expression => expression.MapFrom(employee => employee.RecruitmentDate.ToPersianDate()))
                .ForMember(resource => resource.AgeInYears,
                           expression => expression.MapFrom(employee => employee.BirthDate.TillNowInYears()))
                .ForMember(resource => resource.WorkExperienceInYears,
                           expression => expression.MapFrom(employee => employee.RecruitmentDate.TillNowInYears()))
                .ForMember(resource => resource.IsManager,
                           expression => expression.MapFrom(employee => employee.SupervisorId == null));
        }
        private void MapUpdateEmployeeResourceToUpdateEmployeeModel()
        {
            CreateMap<UpdateEmployeeRequest, UpdateEmployeeModel>()
                .ForMember(model => model.Id,
                           expression => expression.MapFrom(request =>
                                                                request.Id))
                .ForMember(model => model.FirstName,
                           expression => expression.MapFrom(request =>
                                                                request.Resource.FirstName))
                .ForMember(model => model.LastName,
                           expression => expression.MapFrom(request =>
                                                                request.Resource.LastName))
                .ForMember(model => model.BirthDate,
                           expression => expression.MapFrom(request =>
                                                                request.Resource.BirthDate.PersianToDateTime()))
                .ForMember(model => model.RecruitmentDate,
                           expression => expression.MapFrom(request =>
                                                                request.Resource.RecruitmentDate.PersianToDateTime()))
                .ForMember(model => model.SupervisorId,
                           expression => expression.MapFrom(request =>
                                                                request.Resource.SupervisorId));
        }
        private void UpdateEmployeeModelToEmployeeResource()
        {
            CreateMap< UpdateEmployeeModel, EmployeeResource>()
                .ForMember(resource => resource.BirthDate,
                           expression => expression.MapFrom(employee => employee.BirthDate.ToPersianDate()))
                .ForMember(resource => resource.RecruitmentDate,
                           expression => expression.MapFrom(employee => employee.RecruitmentDate.ToPersianDate()))
                .ForMember(resource => resource.AgeInYears,
                           expression => expression.MapFrom(employee => employee.BirthDate.TillNowInYears()))
                .ForMember(resource => resource.WorkExperienceInYears,
                           expression => expression.MapFrom(employee => employee.RecruitmentDate.TillNowInYears()))
                .ForMember(resource => resource.IsManager,
                           expression => expression.MapFrom(employee => employee.SupervisorId == null));
        }
    }
}