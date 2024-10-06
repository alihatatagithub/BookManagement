using BookManagement.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Presistance
{
    public class BookEntities : IdentityDbContext<User>
    {
        public BookEntities(DbContextOptions<BookEntities> options) : base(options)
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
