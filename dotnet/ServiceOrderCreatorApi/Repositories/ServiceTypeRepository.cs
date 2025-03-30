using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceType> CreateAsync(ServiceType serviceType)
        {
            await _context.ServiceTypes.AddAsync(serviceType);

            await _context.SaveChangesAsync();

            return serviceType;
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceType>> GetAllAsync()
        {
            var serviceTypes = await _context.ServiceTypes.ToListAsync();

            return serviceTypes;
        }

        public async Task<ServiceType?> GetByIdAsync(int Id)
        {
            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(st => st.Id == Id);

            return serviceType;
        }

        public async Task<ServiceType> UpdateAsync(ServiceType serviceType)
        {
            _context.ServiceTypes.Update(serviceType);

            await _context.SaveChangesAsync();

            return serviceType;
        }
    }
}
