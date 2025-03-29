using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceOrderCreatorApi.DTOs.User;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> RegisterAsync(RegisterUserDTO registerUserDTO, IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}
