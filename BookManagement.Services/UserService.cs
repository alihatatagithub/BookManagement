using BookManagement.Common.Helpers;
using BookManagement.Contracts.Common;
using BookManagement.Contracts.Factories;
using BookManagement.Contracts.Services;
using BookManagement.Data.DTO;
using BookManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class UserService : IUserService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IUserFactory> _userFactory;
        private readonly SecurityHelper _securityHelper;
        public UserService(Lazy<IUnitOfWork> unitOfWork, Lazy<IUserFactory> userFactory, SecurityHelper securityHelper)
        {
            _unitOfWork = unitOfWork;
            _userFactory = userFactory;
            _securityHelper = securityHelper;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IUserFactory UserFactory => _userFactory.Value;
        public async Task<DTOTokensResponse> Register(RegisterDTO model)
        {
            string refreshToken = _securityHelper.GenerateRefreshToken();
            var user = UserFactory.CreateUser(model,refreshToken);
            string result = await UnitOfWork.UserRepository.CreateUser(user, model.Password);

            if (string.IsNullOrEmpty(result))
            {
                string token = _securityHelper.GenerateToken(user.Id, model.Email);
                return new DTOTokensResponse { AccessToken = token , RefreshToken = refreshToken };
            }
            return new DTOTokensResponse { Errors = result };
        }
        public async Task<DTOTokensResponse> Login(RegisterDTO model)
        {
            var user = await UnitOfWork.UserRepository.CheckUserPassword(model.Email, model.Password);
            if (user != null)
            {
                string token = _securityHelper.GenerateToken(user.Id, model.Email);
                return new DTOTokensResponse { AccessToken = token, RefreshToken = user.RefreshToken };
            }
            return new DTOTokensResponse { Errors = "Not Valid User" };

        }
        public async Task<DTOTokensResponse> RefreshToken(UserTokensDTO model)
        {
            string userId = _securityHelper.ValidateAccessToken(model.AccessToken);
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await UnitOfWork.UserRepository.CheckUserToken(userId, model.RefreshToken);
                if (user != null)
                {
                    string token = _securityHelper.GenerateToken(user.Id, user.Email);
                    return new DTOTokensResponse { AccessToken = token, RefreshToken = user.RefreshToken };
                }
            }
            return new DTOTokensResponse { Errors = "Not Valid Token" };



        }
    }
}
