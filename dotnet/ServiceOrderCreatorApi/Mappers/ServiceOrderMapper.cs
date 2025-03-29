using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Mappers
{
    public static class ServiceOrderMapper
    {
        public static ServiceOrderDTO ToDTO(this ServiceOrder serviceOrder)
        {
            return new ServiceOrderDTO
            {
                Guid = serviceOrder.Guid,
                Description = serviceOrder.Description,
                ImageFiles = serviceOrder.ImageFiles,
            };
        }

        public static ShortServiceOrderDTO ToShortDTO(this ServiceOrder serviceOrder)
        {
            return new ShortServiceOrderDTO { Guid = serviceOrder.Guid };
        }
    }
}
