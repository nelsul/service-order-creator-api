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
        private readonly IImageStorageService _imageStorageService;

        public UserService(UserManager<User> userManager, IImageStorageService imageStorageService)
        {
            _userManager = userManager;
            _imageStorageService = imageStorageService;
        }

        public Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterUserDTO registerUserDTO)
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

            var profilePicFileName = await SaveProfilePic(registerUserDTO.Image!);

            user.ProfilePictureFile = profilePicFileName;

            await _userManager.UpdateAsync(user);

            return true;
        }

        private async Task<string> SaveProfilePic(IFormFile image)
        {
            var fileName = await _imageStorageService.StoreAsync(
                "/Users/nelsonneto/dev/service_order_creator/api/storage/profile-pics",
                image
            );

            return fileName;
        }
    }
}
