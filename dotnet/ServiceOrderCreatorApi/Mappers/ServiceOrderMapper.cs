using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Mappers
{
    public static class ServiceOrderMapper
    {
        public static ServiceOrderDTO ToDTO(this ServiceOrder serviceOrder)
        {
            ServiceOrderOptionsData? optionsData = null;

            if (!string.IsNullOrEmpty(serviceOrder.ServiceTypeOptionsData))
            {
                optionsData = JsonSerializer.Deserialize<ServiceOrderOptionsData>(
                    serviceOrder.ServiceTypeOptionsData
                );
            }

            return new ServiceOrderDTO
            {
                Id = serviceOrder.Id,
                Title = serviceOrder.Title,
                Description = serviceOrder.Description,
                ImageFiles = serviceOrder.ImageFiles,
                Options = optionsData,
            };
        }

        public static ShortServiceOrderDTO ToShortDTO(this ServiceOrder serviceOrder)
        {
            return new ShortServiceOrderDTO { Id = serviceOrder.Id, Title = serviceOrder.Title };
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
