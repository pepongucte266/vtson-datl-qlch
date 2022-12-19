using Dapper;
using datn_qlch_be.Core.Entities;
using datn_qlch_be.Core.Interfaces.repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Infrastructure.Repository
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration): base(configuration) { }

        public int RegisterEmployee(Employee employee)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"$EmployeeName", employee.EmployeeName);
            parameters.Add($"$PhoneNumber", employee.PhoneNumber);
            parameters.Add($"$PasswordHash", employee.PasswordHash, System.Data.DbType.Binary);
            parameters.Add($"$PasswordSalt", employee.PasswordSalt, System.Data.DbType.Binary);
            parameters.Add($"$Address", employee.Address);
            parameters.Add($"$Role", employee.Role);
            var res = SqlConnection.Execute($"Proc_RegisterEmployee", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        } 
    }
}
