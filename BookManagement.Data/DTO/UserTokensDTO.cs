using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Data.DTO
{
    public class UserTokensDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
