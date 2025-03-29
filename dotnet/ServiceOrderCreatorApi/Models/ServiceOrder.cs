using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public string Guid { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImageFiles { get; set; } = [];

        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
