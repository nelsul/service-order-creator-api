using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImageFiles { get; set; } = [];

        public Guid? UserId { get; set; }

        public User? User { get; set; }
    }
}
