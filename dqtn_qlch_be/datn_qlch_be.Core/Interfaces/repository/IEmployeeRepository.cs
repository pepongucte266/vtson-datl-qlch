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
<<<<<<< HEAD

        Employee GetEmployeeByPhoneNumber(string phoneNumber);
=======
>>>>>>> a2420c4b2b22e57a2d91072034b6f0c119899d7b
    }
}
