using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NoorsoftHomework.DataAccess.Interfaces;
using NoorsoftHomework.DataAccess.Models;
using NoorsoftHomework.Model;

namespace NoorsoftHomework.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private const    string        GetEmployeesStoredProcedureName      = "GetEmployees";
        private const    string        GetEmployeesCountStoredProcedureName = "GetEmployeesCount";
        private const    string        AddEmployeeStoredProcedureName       = "InsertEmployee";
        private const    string        UpdateEmployeeStoredProcedureName    = "UpdateEmployee";
        private const    string        DeleteEmployeeStoredProcedureName    = "DeleteEmployee";
        private readonly IDbConnection _connection;

        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IReadOnlyList<Employee>> Get(GetEmployeesParameters parameters)
        {
            var employees =
                await _connection.QueryAsync<Employee>(GetEmployeesStoredProcedureName,
                                                       parameters,
                                                       commandType: CommandType.StoredProcedure);
            return employees.ToList();
        }

        public async Task<int> Count()
        {
            var employeesCount =
                await _connection.QueryFirstOrDefaultAsync<int>(GetEmployeesCountStoredProcedureName,
                                                                commandType: CommandType.StoredProcedure);
            return employeesCount;
        }

        public async Task<int> Add(AddEmployeeModel addModel)
        {
            var id = await _connection.ExecuteScalarAsync<int>(AddEmployeeStoredProcedureName,
                                                               addModel,
                                                               commandType: CommandType.StoredProcedure);
            return id;
        }

        public async Task Update(UpdateEmployeeModel updateModel)
        {
            await _connection.ExecuteAsync(UpdateEmployeeStoredProcedureName,
                                           updateModel,
                                           commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(DeleteEmployeeModel deleteModel)
        {
            await _connection.ExecuteAsync(DeleteEmployeeStoredProcedureName,
                                           deleteModel,
                                           commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}