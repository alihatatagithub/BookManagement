using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? LastLogIn { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
