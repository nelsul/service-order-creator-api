using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;
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

        public Task<bool> CheckOrderOptions(ServiceOrder serviceOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderOptionsData> GenerateOrderOptions(int serviceTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
