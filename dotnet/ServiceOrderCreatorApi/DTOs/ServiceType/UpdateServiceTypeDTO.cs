using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceType
{
    public class UpdateServiceTypeDTO
    {
        public string? Title { get; set; }

        public int? Version { get; set; }
        public List<string>? Options { get; set; }
    }
}
