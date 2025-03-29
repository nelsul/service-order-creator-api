using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderCreatorApi.DTOs.User;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterUserDTO registerUserDTO);

        Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO);

        Task<byte[]> GetPicture(RequestPictureUserDTO requestPictureUserDTO);
    }
}
