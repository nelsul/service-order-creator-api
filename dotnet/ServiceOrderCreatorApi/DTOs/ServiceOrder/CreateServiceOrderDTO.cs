using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class CreateServiceOrderDTO
    {
        [Required]
        [MinLength(10)]
        public string Description { get; set; } = string.Empty;
    }
}
