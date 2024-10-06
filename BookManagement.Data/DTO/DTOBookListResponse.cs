using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Data.DTO
{
    public class DTOBookListResponse
    {
        public List<DTOBookList> BookList { get; set; }
        public int Count { get; set; }
    }
    public class DTOBookList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
    }
}
