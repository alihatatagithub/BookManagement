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
        public UnitOfWork(EmployeeEntities context,Lazy<IUserRepository> userRepository, Lazy<IEmployeeRepository> employeeRepository)
        {
            _userRepository = userRepository;
            _context = context;
            _employeeRepository = employeeRepository;

        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        private EmployeeEntities BookEntities => _context;


        public async Task SaveChangesAsync()
        {
             await BookEntities.SaveChangesAsync();
        }
    }
}
