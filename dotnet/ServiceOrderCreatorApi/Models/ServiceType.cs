using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OptionsData { get; set; } = string.Empty;
        public List<ServiceOrder> ServiceOrders { get; set; } = [];
    }
}
