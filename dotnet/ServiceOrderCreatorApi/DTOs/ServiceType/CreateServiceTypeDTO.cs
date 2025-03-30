using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceType
{
    public class CreateServiceTypeDTO
    {
        [Required]
        [Length(3, 150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Version { get; set; }

        [Required]
        [MinLength(0)]
        public List<string> Options { get; set; } = [];
    }
}
