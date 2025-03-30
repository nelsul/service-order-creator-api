using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Services
{
    public class ServiceOrderTypeService : IServiceOrderTypeService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceOrderTypeService(
            IServiceOrderRepository serviceOrderRepository,
            IServiceTypeRepository serviceTypeRepository
        )
        {
            _serviceOrderRepository = serviceOrderRepository;
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<bool> CheckOrderOptions(ServiceOrder serviceOrder)
        {
            if (serviceOrder.ServiceTypeId == null)
            {
                throw new Exception("Service Order has no service type");
            }

            var serviceTypeOptions = await GenerateOrderOptions((int)serviceOrder.ServiceTypeId);

            var serviceOrderDTO = serviceOrder.ToDTO();

            var orderOptions = (ServiceOrderOptionsData)serviceOrderDTO.Options!;

            if (
                serviceTypeOptions.Options.Count != orderOptions.Options.Count
                || serviceTypeOptions.Version != orderOptions.Version
            )
            {
                throw new Exception("Options from order do not match with type");
            }

            var match = true;

            serviceTypeOptions.Options.ForEach(o =>
            {
                if (!orderOptions.Options.Select(op => op.Title).Contains(o.Title))
                {
                    match = false;
                    throw new Exception("Options from order do not match with type");
                }
            });

            return match;
        }

        public async Task<ServiceOrderOptionsData> GenerateOrderOptions(int serviceTypeId)
        {
            var serviceType = await _serviceTypeRepository.GetByIdAsync(serviceTypeId);

            if (serviceType == null)
            {
                throw new Exception("Service type not found");
            }

            var serviceTypeDTO = serviceType.ToDTO();

            if (serviceTypeDTO.Options.Count == 0)
            {
                throw new Exception("Service type has no items");
            }

            return new ServiceOrderOptionsData
            {
                Version = serviceTypeDTO.Version,
                Options = serviceTypeDTO
                    .Options.Select(o => new ServiceOrderOptionsDataItem
                    {
                        Title = o,
                        Selected = false,
                    })
                    .ToList(),
            };
        }
    }
}
