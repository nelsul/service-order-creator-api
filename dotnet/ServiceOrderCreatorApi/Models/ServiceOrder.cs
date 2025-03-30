using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImageFiles { get; set; } = [];

        public string? UserId { get; set; }

        public User? User { get; set; }

        public int? ServiceTypeId { get; set; }

        public ServiceType? ServiceType { get; set; }

        public string ServiceTypeOptionsData { get; set; } = string.Empty;
    }
}
