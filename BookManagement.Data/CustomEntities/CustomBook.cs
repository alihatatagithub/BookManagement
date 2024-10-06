using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Data.CustomEntities
{
    public class CustomBook
    {
        public List<Book> Books { get; set; }
        public int Count { get; set; }
    }
}
