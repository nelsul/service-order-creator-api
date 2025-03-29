using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceOrderCreatorApi.DTOs.User;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;
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

        public async Task<UserDTO> RegisterAsync(RegisterUserDTO registerUserDTO)
        {
            var user = registerUserDTO.ToUser();

            var createUser = await _userManager.CreateAsync(user, registerUserDTO.Password);

            if (!createUser.Succeeded)
            {
                var ex = new Exception("Erro while creating user");
                ex.Data["Details"] = createUser.Errors;
                throw ex;
            }

            var createRole = await _userManager.AddToRoleAsync(user, "User");

            if (!createRole.Succeeded)
            {
                var ex = new Exception("Erro while creating user role");
                ex.Data["Details"] = createRole.Errors;
                throw ex;
            }

            return user.ToDTO("");
        }
    }
}
