namespace NoorsoftHomework.Web.Resources.Employee
{
    public record UpdateEmployeeResource(string FirstName,
                                         string LastName,
                                         string BirthDate,
                                         string RecruitmentDate,
                                         int?   SupervisorId);
}