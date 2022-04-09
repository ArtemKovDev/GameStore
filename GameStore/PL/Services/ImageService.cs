using BLL.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace PL.Services
{
    public static class ImageService
    {
        public static string UploadGameImage(IFormFile file, string path)
        {
            var folderName = Path.Combine("wwwroot", path);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string ext = Path.GetExtension(fileName);

                if (ext == ".jpg" || ext == ".jpeg")
                {
                    fileName = Guid.NewGuid().ToString() + ext;

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var imageUrl = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return imageUrl;
                }
                else
                {
                    throw new ServiceException(string.Join(';', "Extension is not valid"));
                }
            }
            else
            {
                throw new ServiceException(string.Join(';', "File is not valid"));
            }
        }

        public static void Delete(string imageUrl)
        {
            var folderName = Path.Combine("wwwroot", imageUrl);
            var pathToDelete = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (File.Exists(pathToDelete))
            {
                File.Delete(pathToDelete);
            }
            else
            {
                throw new ServiceException(string.Join(';', "Path is not valid"));
            }
        }
    }
}
