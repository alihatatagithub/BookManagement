using BookManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Data.DTO
{
    public class DTOGetBookList : DTOPaging
    {
        public string? Title { get; set; }
        public string? AuthorId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? OrderName { get; set; }
    }
}
