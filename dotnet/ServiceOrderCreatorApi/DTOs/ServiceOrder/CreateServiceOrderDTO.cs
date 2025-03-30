using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.DTOs.ServiceOrder
{
    public class CreateServiceOrderDTO
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
