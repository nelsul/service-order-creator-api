using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceType;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Mappers
{
    public static class ServiceTypeMapper
    {
        public static ServiceTypeDTO ToDTO(this ServiceType serviceType)
        {
            int version = 0;
            List<string> options = [];

            if (!string.IsNullOrEmpty(serviceType.OptionsData))
            {
                var data = JsonSerializer.Deserialize<ServiceTypeData>(serviceType.OptionsData);

                Console.Write(data);

                version = data.Version;
                options = data.Options;
            }

            return new ServiceTypeDTO
            {
                Id = serviceType.Id,
                Title = serviceType.Title,
                Options = options,
                Version = version,
            };
        }

        public static ServiceType ToServiceType(this CreateServiceTypeDTO createServiceTypeDTO)
        {
            var optionsData = new ServiceTypeData
            {
                Version = createServiceTypeDTO.Version,
                Options = createServiceTypeDTO.Options,
            };

            string jsonData = JsonSerializer.Serialize(optionsData);

            return new ServiceType { Title = createServiceTypeDTO.Title, OptionsData = jsonData };
        }
    }
}
