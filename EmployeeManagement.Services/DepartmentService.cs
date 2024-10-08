using EmployeeManagement.Contracts.Common;
using EmployeeManagement.Contracts.Services;
using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        public DepartmentService(Lazy<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        public async Task<List<DTODepartmentListResponse>> GetDepartmentList()
        {
            return await UnitOfWork.DepartmentRepository.GetDepartmentList();
        }

    }
}
