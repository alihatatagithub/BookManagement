using EmployeeManagement.Contracts.Common;
using EmployeeManagement.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeEntities _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        public UnitOfWork(EmployeeEntities context,Lazy<IUserRepository> userRepository, Lazy<IEmployeeRepository> employeeRepository, Lazy<IDepartmentRepository> departmentRepository)
        {
            _userRepository = userRepository;
            _context = context;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;

        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
        private EmployeeEntities BookEntities => _context;


        public async Task SaveChangesAsync()
        {
             await BookEntities.SaveChangesAsync();
        }
    }
}
