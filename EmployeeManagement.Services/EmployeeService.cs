using EmployeeManagement.Common.Helpers;
using EmployeeManagement.Contracts.Common;
using EmployeeManagement.Contracts.Factories;
using EmployeeManagement.Contracts.Services;
using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IEmployeeFactory> _employeeFactory;
        private readonly SecurityHelper _securityHelper;
        public EmployeeService(SecurityHelper securityHelper, Lazy<IUnitOfWork> unitOfWork , Lazy<IEmployeeFactory> employeeFactory)
        {
            _securityHelper = securityHelper;
            _unitOfWork = unitOfWork;
            _employeeFactory = employeeFactory;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IEmployeeFactory EmployeeFactory => _employeeFactory.Value;

        public async Task<DTOEmployeeListResponse> GetEmployeeList(DTOGetEmployeeList model)
        {
            var result = await UnitOfWork.EmployeeRepository.GetEmployeeList(model);
            var dto =  EmployeeFactory.CreateDTOEmployee(result.Employees);
            return new DTOEmployeeListResponse
            {
                EmployeeList = dto,
                Count = result.Count
            };

        }
        public async Task<string> AddEmployee(DTOAddEmployee model)
        {
            var employee = EmployeeFactory.CreateEmployee(model);
            return await UnitOfWork.EmployeeRepository.CreateEmployee(employee);
        }
        public async Task<string> DeleteEmployee(string id)
        {
             await UnitOfWork.EmployeeRepository.DeleteEmployee(id);
            return string.Empty;
        }
    }
}
