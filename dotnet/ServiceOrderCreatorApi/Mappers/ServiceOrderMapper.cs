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
                PublicId = serviceOrder.PublicId,
                Title = serviceOrder.Title,
                Description = serviceOrder.Description,
                ImageFiles = serviceOrder.ImageFiles,
            };
        }

        public static ShortServiceOrderDTO ToShortDTO(this ServiceOrder serviceOrder)
        {
            return new ShortServiceOrderDTO
            {
                PublicId = serviceOrder.PublicId,
                Title = serviceOrder.Title,
            };
        }

        public static ServiceOrder ToServiceOrder(this CreateServiceOrderDTO createServiceOrderDTO)
        {
            return new ServiceOrder
            {
                Title = createServiceOrderDTO.Title,
                Description = createServiceOrderDTO.Description,
            };
        }
    }
}
