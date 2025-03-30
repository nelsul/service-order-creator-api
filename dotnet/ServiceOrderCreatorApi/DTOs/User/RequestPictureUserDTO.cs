using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.User
{
    public class RequestPictureUserDTO
    {
        [Required]
        [Length(3, 120)]
        public string FileName { get; set; } = string.Empty;

        [Range(50, 3840)]
        public uint? Width { get; set; }

        [Range(50, 2160)]
        public uint? Height { get; set; }
    }
}
