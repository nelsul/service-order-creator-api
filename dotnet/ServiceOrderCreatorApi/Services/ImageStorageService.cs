using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderCreatorApi.Interfaces.Services;

namespace ServiceOrderCreatorApi.Services
{
    public class ImageStorageService : IImageStorageService
    {
        public async Task<byte[]> GetAsync(string filePath, int? width, int? height)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Image not found");
            }

            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using MemoryStream memoryStream = new MemoryStream();

            await fileStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return memoryStream.ToArray();
        }

        public async Task<string> StoreAsync(string folderPath, IFormFile imageFile)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }
    }
}
