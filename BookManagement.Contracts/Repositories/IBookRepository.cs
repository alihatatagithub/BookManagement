using BookManagement.Data.CustomEntities;
using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Contracts.Repositories
{
    public interface IBookRepository
    {
        Task<CustomBook> GetBookList(DTOGetBookList model);
    }
}
