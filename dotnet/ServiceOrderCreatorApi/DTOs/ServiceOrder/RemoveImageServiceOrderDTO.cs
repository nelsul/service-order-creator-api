using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class RemoveImageServiceOrderDTO
    {
        [Required]
        [MinLength(3)]
        public string Guid { get; set; } = string.Empty;

        [Required]
        public IFormFile? Image { get; set; }
    }
}
