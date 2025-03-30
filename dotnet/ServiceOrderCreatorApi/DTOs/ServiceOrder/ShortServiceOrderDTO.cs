using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class ShortServiceOrderDTO
    {
        public Guid PublicId { get; set; }

        public string Title { get; set; } = string.Empty;
    }
}
