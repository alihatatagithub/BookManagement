using BookManagement.Common;
using BookManagement.Contracts.Repositories;
using BookManagement.Data.CustomEntities;
using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Presistance.Repositories
{
    public class BookRepository :  IBookRepository
    {
        private readonly BookEntities BookEntities;
        public BookRepository(BookEntities book)
        {
            BookEntities = book;
        }
        public async Task<CustomBook> GetBookList(DTOGetBookList model)
        {
            var query = BookEntities.Books.AsQueryable();

            var booksCount = query.Count();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(a => a.Title == model.Title);

            if (!string.IsNullOrEmpty(model.AuthorId))
                query = query.Where(a => a.AuthorId == model.AuthorId);

            if (model.PublicationDate != null)
                query = query.Where(a => a.PublicationDate == model.PublicationDate);
            if (model.OrderName != null)
            {
                if (model.OrderName == "Title")
                {
                    if(model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.Title);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.Title);
                    }
                }

                else if(model.OrderName == "Author")
                {
                    if (model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.Author.UserName);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.Author.UserName);
                    }
                }
                else if (model.OrderName == "PublicationDate")
                {
                    if (model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.PublicationDate);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.PublicationDate);
                    }
                }
                else if (model.OrderName == "Quantity")
                {
                    if (model.Direction == "asc")
                    {
                        query = query.OrderBy(a => a.Quantity);
                    }
                    else
                    {
                        query = query.OrderByDescending(a => a.Quantity);
                    }
                }

            }
            
            var books = await query.Skip((model.PageNumber - 1) * model.PageSize)
                        .Take(model.PageSize)
                        .Include(a => a.Author)
                        .ToListAsync();

            return new CustomBook
            {
                Books = books,
                Count = booksCount
            };


        }
    }
}
