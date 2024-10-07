using EmployeeManagement.Contracts.Factories;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public List<DTOEmployeeList> CreateDTOEmployee(List<Employee> employees)
        {
            return employees.Select(a => new DTOEmployeeList
            {
                Id = a.Id,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                DateOfJoining = a.DateOfJoining,
                Department = a.Department.Name
            }).ToList();
        }
        public Employee CreateEmployee(DTOAddEmployee model)
        {
            return new Employee
            {
                Email = model.Email,
                UserName = model.Email,
                DepartmentId = model.DepartmentId,
                IsActive = true,
                DateOfJoining = DateTime.Now,
                PhoneNumber = model.PhoneNumber,
            };
        }
    }
}
