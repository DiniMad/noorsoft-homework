namespace NoorsoftHomework.Web.Resources.Employee
{
    public class AddEmployeeResource
    {
        public string FirstName       { get; init; }
        public string LastName        { get; init; }
        public string BirthDate       { get; init; }
        public string RecruitmentDate { get; init; }
        public int?   SupervisorId    { get; init; }
    }
}