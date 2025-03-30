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
        public string Id { get; set; } = string.Empty;

        [Required]
        public string ImageFileName { get; set; } = string.Empty;
    }
}
