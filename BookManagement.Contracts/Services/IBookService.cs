using BookManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Contracts.Services
{
    public interface IBookService
    {
        Task<DTOBookListResponse> GetBookList(DTOGetBookList model);
    }
}
