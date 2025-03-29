using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.User
{
    public class RequestPictureByIdUserDTO
    {
        [Required]
        [MinLength(3)]
        public string Id { get; set; } = string.Empty;

        [Range(50, 1080)]
        public uint? Width { get; set; }

        [Range(50, 1080)]
        public uint? Height { get; set; }
    }
}
