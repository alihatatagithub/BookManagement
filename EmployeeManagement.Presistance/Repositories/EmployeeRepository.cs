using EmployeeManagement.Common;
using EmployeeManagement.Contracts.Repositories;
using EmployeeManagement.Data.CustomEntities;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Repositories
{
    public class EmployeeRepository :  IEmployeeRepository
    {
        private readonly EmployeeEntities EmployeeEntities;
        private readonly UserManager<User> _userManager;

        public EmployeeRepository(EmployeeEntities employeeEntities, UserManager<User> userManager)
        {
            EmployeeEntities = employeeEntities;
            _userManager = userManager;
        }
        public async Task<CustomEmployee> GetEmployeeList(DTOGetEmployeeList model)
        {
            var query = EmployeeEntities.Employees.AsQueryable();

            var booksCount = query.Count();

            if (!string.IsNullOrEmpty(model.SearchText))
                query = query.Where(a => model.SearchText.Contains(a.Email) || model.SearchText.Contains(a.PhoneNumber));

            if (model.DepartmentId != null)
                query = query.Where(a => a.DepartmentId == model.DepartmentId);


            if (model.OrderName != null)
            {
                if (model.OrderName == "Email")
                {
                    if(model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.Email);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.Email);
                    }
                }

                else if(model.OrderName == "Department")
                {
                    if (model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.Department.Name);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.Department.Name);
                    }
                }
                else if (model.OrderName == "PhoneNumber")
                {
                    if (model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.PhoneNumber);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.PhoneNumber);
                    }
                }

            }
            
            var books = await query.Skip((model.PageNumber - 1) * model.PageSize)
                        .Take(model.PageSize)
                        .Include(a => a.Department)
                        .ToListAsync();

            return new CustomEmployee
            {
                Employees = books,
                Count = booksCount
            };


        }

        public async Task<string> CreateEmployee(Employee employee)
        {
            var result = await _userManager.CreateAsync(employee, "Test@123");
            if (result.Succeeded) return string.Empty;
            string res = string.Empty;
            foreach (var item in result.Errors)
            {
                res += item;
            }
            return res;
        }
        public async Task DeleteEmployee(string id)
        {
            var result = await EmployeeEntities.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();
            EmployeeEntities.Employees.Remove(result);
        }
    }
}
