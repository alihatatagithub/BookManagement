using BookManagement.Contracts.Factories;
using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Presistance.Factories
{
    public class BookFactory : IBookFactory
    {
        public List<DTOBookList> CreateDTOBook(List<Book> books)
        {
            return books.Select(book => new DTOBookList
            {
                Id = book.Id,
                Author = book.Author.UserName,
                PublicationDate = book.PublicationDate.ToString(),
                Quantity = book.Quantity,
                Title = book.Title
            }).ToList();
        }
    }
}
