using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderCreatorApi.Interfaces.Services;

namespace ServiceOrderCreatorApi.Services
{
    public class ImageStorageService : IImageStorageService
    {
        public async Task<byte[]> GetAsync(string filePath, uint? width, uint? height)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Image not found");
            }

            var magickImage = new MagickImage(filePath);

            if (height.HasValue)
            {
                var size = new MagickGeometry(width ?? 200, height ?? 200);
                size.IgnoreAspectRatio = true;
                magickImage.Resize(size);
            }
            else
            {
                magickImage.Resize(width ?? 200, 0);
            }

            using var ms = new MemoryStream();

            await magickImage.WriteAsync(ms, MagickFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);

            return ms.ToArray();
        }

        public async Task<string> StoreAsync(string folderPath, IFormFile imageFile)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!IsImage(imageFile.FileName))
            {
                throw new ArgumentException("File is not a valid image");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }

        private static bool IsImage(string filePath)
        {
            string[] validExtensions =
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".gif",
                ".bmp",
                ".tiff",
                ".webp",
            };
            string extension = Path.GetExtension(filePath).ToLower();
            return Array.Exists(validExtensions, ext => ext == extension);
        }

        public async Task<bool> DeleteAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Image not found");
            }

            await Task.Run(() => File.Delete(filePath));

            return true;
        }
    }
}
