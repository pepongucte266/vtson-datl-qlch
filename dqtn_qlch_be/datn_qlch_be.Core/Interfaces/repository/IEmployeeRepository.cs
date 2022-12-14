using datn_qlch_be.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Interfaces.repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        int RegisterEmployee(Employee employee);

        Employee GetEmployeeByPhoneNumber(string phoneNumber);
    }
}
