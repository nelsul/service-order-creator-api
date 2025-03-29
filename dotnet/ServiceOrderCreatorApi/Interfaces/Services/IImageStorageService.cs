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

        public Task<byte[]> GetAsync(string filePath, int? width, int? height);
    }
}
