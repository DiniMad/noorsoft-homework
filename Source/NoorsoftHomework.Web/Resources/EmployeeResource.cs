namespace NoorsoftHomework.Web.Resources
{
    public class EmployeeResource
    {
        public int    Id                    { get; init; }
        public string FirstName             { get; init; }
        public string LastName              { get; init; }
        public string BirthDate             { get; init; }
        public string RecruitmentDate       { get; init; }
        public int?   SupervisorId          { get; init; }
        public byte   AgeInYears            { get; init; }
        public byte   WorkExperienceInYears { get; init; }
        public bool   IsManager             { get; init; }
    }
}