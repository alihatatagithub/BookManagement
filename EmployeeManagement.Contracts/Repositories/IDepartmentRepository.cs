using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<DTODepartmentListResponse>> GetDepartmentList();
    }
}
