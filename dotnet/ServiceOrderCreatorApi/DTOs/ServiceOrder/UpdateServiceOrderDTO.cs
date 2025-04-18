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
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? ServiceTypeId { get; set; }

        public ServiceOrderOptionsData? Options { get; set; }
    }
}
