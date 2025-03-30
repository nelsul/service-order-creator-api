using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class AddImageServiceOrderDTO
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public IFormFile? Image { get; set; }
    }
}
