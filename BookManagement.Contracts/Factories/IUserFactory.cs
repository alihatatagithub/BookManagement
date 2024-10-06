using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Contracts.Factories
{
    public interface IUserFactory
    {
        User CreateUser(RegisterDTO model,string refreshToken);
    }
}
