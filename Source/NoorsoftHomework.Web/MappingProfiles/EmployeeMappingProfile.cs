using AutoMapper;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Model;
using NoorsoftHomework.Web.Handlers.Employee.Commands;
using NoorsoftHomework.Web.Helpers;
using NoorsoftHomework.Web.Resources.Employee;

namespace NoorsoftHomework.Web.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            MapEmployeeToEmployeeResource();
            MapUpdateEmployeeCommandToUpdateEmployeeModel();
            MapAddEmployeeCommandToAddEmployeeModel();
            MapIntIdAndAddEmployeeModelToEmployeeResource();
            MapDeleteEmployeeCommandToDeleteEmployeeModel();
            MapDeleteEmployeeCommandToIsEmployeeSupervisorModel();
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

        private void MapUpdateEmployeeCommandToUpdateEmployeeModel()
        {
            CreateMap<UpdateEmployeeCommand, UpdateEmployeeModel>()
                .ConstructUsing(command =>
                                    new UpdateEmployeeModel(command.Id,
                                                            command.Resource.FirstName,
                                                            command.Resource.LastName,
                                                            command.Resource.BirthDate.PersianToDateTime(),
                                                            command.Resource.RecruitmentDate.PersianToDateTime(),
                                                            command.Resource.SupervisorId));
        }

        private void MapAddEmployeeCommandToAddEmployeeModel()
        {
            CreateMap<AddEmployeeCommand, AddEmployeeModel>()
                .ConstructUsing(command =>
                                    new AddEmployeeModel(command.Resource.FirstName,
                                                         command.Resource.LastName,
                                                         command.Resource.BirthDate.PersianToDateTime(),
                                                         command.Resource.RecruitmentDate.PersianToDateTime(),
                                                         command.Resource.SupervisorId));
        }

        private void MapIntIdAndAddEmployeeModelToEmployeeResource()
        {
            CreateMap<(int id, AddEmployeeModel addModel), EmployeeResource>()
                .ConstructUsing(tuple =>
                                    new EmployeeResource(tuple.id,
                                                         tuple.addModel.FirstName,
                                                         tuple.addModel.LastName,
                                                         tuple.addModel.BirthDate.ToPersianDate(),
                                                         tuple.addModel.RecruitmentDate.ToPersianDate(),
                                                         tuple.addModel.SupervisorId,
                                                         (byte) tuple.addModel.BirthDate.TillNowInYears(),
                                                         (byte) tuple.addModel.RecruitmentDate.TillNowInYears(),
                                                         tuple.addModel.SupervisorId == null));
        }

        private void MapDeleteEmployeeCommandToDeleteEmployeeModel()
        {
            CreateMap<DeleteEmployeeCommand, DeleteEmployeeModel>()
                .ConstructUsing(command => new DeleteEmployeeModel(command.Id));
        }

        private void MapDeleteEmployeeCommandToIsEmployeeSupervisorModel()
        {
            CreateMap<DeleteEmployeeCommand, IsEmployeeSupervisorModel>()
                .ConstructUsing(command => new IsEmployeeSupervisorModel(command.Id));
        }
    }
}