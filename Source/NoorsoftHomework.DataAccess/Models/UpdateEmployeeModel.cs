using System;

namespace NoorsoftHomework.DataAccess.Models
{
    public record UpdateEmployeeModel(int      Id,
                                      string   FirstName,
                                      string   LastName,
                                      DateTime BirthDate,
                                      DateTime RecruitmentDate,
                                      int?     SupervisorId)
    {
        public UpdateEmployeeModel() : this(default, default, default, default, default, default)
        {
        }
    }
}