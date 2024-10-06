using BookManagement.Contracts.Common;
using BookManagement.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace BookManagement.Presistance.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookEntities _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        public UnitOfWork(BookEntities context,Lazy<IUserRepository> userRepository, Lazy<IBookRepository> bookRepository)
        {
            _userRepository = userRepository;
            _context = context;
            _bookRepository = bookRepository;

        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IBookRepository BookRepository => _bookRepository.Value;
        private BookEntities BookEntities => _context;


        public async Task SaveChangesAsync()
        {
             await BookEntities.SaveChangesAsync();
        }
    }
}
