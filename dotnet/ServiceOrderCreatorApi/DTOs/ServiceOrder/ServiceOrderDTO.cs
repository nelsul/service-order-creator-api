using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class ServiceOrderDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ServiceTypeId { get; set; }
        public ServiceOrderOptionsData? Options { get; set; }
        public List<string> ImageFiles { get; set; } = [];
    }
}
