using BookManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Contracts.Services
{
    public interface IUserService
    {
        Task<DTOTokensResponse> Login(RegisterDTO model);
        Task<DTOTokensResponse> RefreshToken(UserTokensDTO model);
        Task<DTOTokensResponse> Register(RegisterDTO model);
    }
}
