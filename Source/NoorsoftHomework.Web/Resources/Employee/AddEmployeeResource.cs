namespace NoorsoftHomework.Web.Resources.Employee
{
    public record AddEmployeeResource(string FirstName,
                                      string LastName,
                                      string BirthDate,
                                      string RecruitmentDate,
                                      int?   SupervisorId);
}