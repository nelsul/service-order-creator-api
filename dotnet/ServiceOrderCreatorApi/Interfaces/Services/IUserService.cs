using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.User;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> RegisterAsync(RegisterUserDTO registerUserDTO, IFormFile image);

        Task<UserDTO> LoginAsync(LoginUserDTO loginUserDTO);
    }
}
