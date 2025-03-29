using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class ServiceOrderDTO
    {
        public string Guid { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImageFiles { get; set; } = [];
    }
}
