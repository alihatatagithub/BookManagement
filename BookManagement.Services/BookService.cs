using BookManagement.Common.Helpers;
using BookManagement.Contracts.Common;
using BookManagement.Contracts.Factories;
using BookManagement.Contracts.Services;
using BookManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IBookFactory> _bookFactory;
        private readonly SecurityHelper _securityHelper;
        public BookService(SecurityHelper securityHelper, Lazy<IUnitOfWork> unitOfWork , Lazy<IBookFactory> bookFactory)
        {
            _securityHelper = securityHelper;
            _unitOfWork = unitOfWork;
            _bookFactory = bookFactory;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IBookFactory BookFactory => _bookFactory.Value;

        public async Task<DTOBookListResponse> GetBookList(DTOGetBookList model)
        {
            var result = await UnitOfWork.BookRepository.GetBookList(model);
            var dto =  BookFactory.CreateDTOBook(result.Books);
            return new DTOBookListResponse
            {
                BookList = dto,
                Count = result.Count
            };

        }
    }
}
