using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class UpdateServiceOrderDTO
    {
        [MinLength(3)]
        public string? Title { get; set; }

        [MinLength(10)]
        public string? Description { get; set; }

        public int? ServiceTypeId { get; set; }

        public ServiceOrderOptionsData? Options { get; set; }
    }
}
