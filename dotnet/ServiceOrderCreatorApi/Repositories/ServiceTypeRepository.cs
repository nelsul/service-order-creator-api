using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Data;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<ServiceType> CreateAsync(ServiceType serviceType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceType?> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceType> UpdateAsync(ServiceType serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
