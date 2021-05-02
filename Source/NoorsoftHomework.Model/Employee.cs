using System;

namespace NoorsoftHomework.Model
{
    public record Employee
    {
        public int      Id              { get; init; }
        public string   FirstName       { get; init; }
        public string   LastName        { get; init; }
        public DateTime BirthDate       { get; init; }
        public DateTime RecruitmentDate { get; init; }
        public int?     SupervisorId    { get; init; }
    }
}