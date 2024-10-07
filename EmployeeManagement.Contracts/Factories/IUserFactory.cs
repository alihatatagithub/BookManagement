using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Factories
{
    public interface IUserFactory
    {
        User CreateUser(RegisterDTO model,string refreshToken);
        void UpdateUserToken(User user, string refreshToken);
    }
}
