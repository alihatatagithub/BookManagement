using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<string> AddEmployee(DTOAddEmployee model);
        Task<string> DeleteEmployee(string id);
        Task<DTOEmployeeListResponse> GetEmployeeList(DTOGetEmployeeList model);
    }
}
