namespace NoorsoftHomework.Web.Resources.Employee
{
    public record EmployeeResource(int    Id,
                                   string FirstName,
                                   string LastName,
                                   string BirthDate,
                                   string RecruitmentDate,
                                   int?   SupervisorId,
                                   byte   AgeInYears,
                                   byte   WorkExperienceInYears,
                                   bool   IsManager);
}