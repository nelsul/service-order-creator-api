using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IImageStorageService
    {
        public Task<string> StoreAsync(string folderPath, IFormFile imageFile);

        public Task<byte[]> GetAsync(string filePath, uint? width, uint? height);

        public Task<bool> DeleteAsync(string filePath);
    }
}
