using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Services
{
    public interface IUserService
    {
        Task<DTOTokensResponse> Login(RegisterDTO model);
        Task<DTOTokensResponse> RefreshToken(UserTokensDTO model);
        Task<DTOTokensResponse> Register(RegisterDTO model);
    }
}
