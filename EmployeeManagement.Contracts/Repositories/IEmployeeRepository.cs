using EmployeeManagement.Data.CustomEntities;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        Task<string> CreateEmployee(Employee employee);
        Task DeleteEmployee(string id);
        Task<CustomEmployee> GetEmployeeList(DTOGetEmployeeList model);
    }
}
