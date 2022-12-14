using datn_qlch_be.Core.DTOs;
using datn_qlch_be.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.services
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        Employee CreatePasswordHash(string password);
        bool VerifiPassword(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(Employee employee);
        Employee RegisterEmployee(EmployeeDto employee);
        string Login(EmployeeDto employee);

        Employee GetCurrentEmployee();
    }
}   
