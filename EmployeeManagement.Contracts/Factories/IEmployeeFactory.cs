using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Factories
{
    public interface IEmployeeFactory
    {
        List<DTOEmployeeList> CreateDTOEmployee(List<Employee> employees);
        Employee CreateEmployee(DTOAddEmployee model);
    }
}
