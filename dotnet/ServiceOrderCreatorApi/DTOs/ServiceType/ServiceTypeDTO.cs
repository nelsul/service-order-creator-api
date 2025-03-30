using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceType
{
    public class ServiceTypeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int Version { get; set; }
        public List<string> Options { get; set; } = [];
    }
}
