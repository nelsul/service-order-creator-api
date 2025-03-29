using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.User;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterUserDTO registerUserDTO)
        {
            return new User { UserName = registerUserDTO.Name, Email = registerUserDTO.Email };
        }

        public static UserDTO ToDTO(this User user, string token)
        {
            return new UserDTO
            {
                Name = user.UserName!,
                Email = user.Email!,
                Token = token,
                ProfilePictureFile = user.ProfilePictureFile,
            };
        }
    }
}
