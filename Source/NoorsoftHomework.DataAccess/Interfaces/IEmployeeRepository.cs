using System.Collections.Generic;
using System.Threading.Tasks;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Model;

namespace NoorsoftHomework.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<Employee>> Get(GetEmployeesParameters parameters);
        Task<int>                     Count();
        Task<bool>                    IsSupervisor(IsEmployeeSupervisorModel isSupervisorModel);
        Task<int>                     Add(AddEmployeeModel                   addModel);
        Task                          Update(UpdateEmployeeModel             updateModel);
        Task                          Delete(DeleteEmployeeModel             deleteModel);
    }
}