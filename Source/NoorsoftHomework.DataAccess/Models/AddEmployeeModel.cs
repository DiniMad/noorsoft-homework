using System;

namespace NoorsoftHomework.DataAccess.Models
{
    public record AddEmployeeModel(string   FirstName,
                                   string   LastName,
                                   DateTime BirthDate,
                                   DateTime RecruitmentDate,
                                   int?     SupervisorId);
}