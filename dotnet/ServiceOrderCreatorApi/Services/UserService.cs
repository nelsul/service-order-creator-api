using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceOrderCreatorApi.DTOs.User;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IImageStorageService _imageStorageService;

        public UserService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IImageStorageService imageStorageService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _imageStorageService = imageStorageService;
        }

        public async Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.Email == loginUserDTO.Email
            );

            if (user == null)
            {
                throw new UnauthorizedAccessException("Email or Password invalid");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                loginUserDTO.Password,
                false
            );

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Email or Password invalid");
            }

            return user.ToDTO("");
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
