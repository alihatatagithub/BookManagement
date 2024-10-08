using EmployeeManagement.Contracts.Repositories;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeEntities EmployeeEntities;
        public DepartmentRepository(EmployeeEntities employeeEntities)
        {
            EmployeeEntities = employeeEntities;
        }
        public async Task<List<DTODepartmentListResponse>> GetDepartmentList()
        {
            return await EmployeeEntities.Departments.Select(a => new DTODepartmentListResponse { Id = a.Id, Name = a.Name }).ToListAsync();
        }
    }
}
