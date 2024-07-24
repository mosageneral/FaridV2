using Abp.Dependency;
using Abp.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace FaridV2.Features
{
    public interface IFileHelper
    {
        Task<string> UploadFile(IFormFile file);
    }
    internal class FileHelperService : IFileHelper, ITransientDependency
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<FileHelperService> _logger;

        public FileHelperService(IHostingEnvironment hostingEnvironment, ILogger<FileHelperService> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string uniqueFileName = null;

            try
            {
                if (file != null)
                {
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");

                    // Ensure the directory exists
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(path, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Create and save thumbnail
                    await CreateThumbnail252x200(file, path, uniqueFileName);
                    await CreateThumbnail65x65(file, path, uniqueFileName);
                    await CreateThumbnail816x357(file, path, uniqueFileName);

                    _logger.LogInformation($"File uploaded successfully: {uniqueFileName}");
                    return uniqueFileName;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading the file: {ex.Message}", ex);
                throw;
            }

            return uniqueFileName;
        }

        private async Task CreateThumbnail816x357(IFormFile file, string path, string uniqueFileName)
        {
            try
            {
                string thumbnailFileName = "Thumb816x357-" + uniqueFileName;
                string thumbnailFilePath = Path.Combine(path, thumbnailFileName);

                using (var image = await Image.LoadAsync(file.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(816, 357),
                        Mode = ResizeMode.Crop
                    }));

                    await image.SaveAsync(thumbnailFilePath);
                }

                _logger.LogInformation($"Thumbnail created successfully: {thumbnailFileName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the thumbnail: {ex.Message}", ex);
                throw;
            }
        }
        private async Task CreateThumbnail65x65(IFormFile file, string path, string uniqueFileName)
        {
            try
            {
                string thumbnailFileName = "Thumb65x65-" + uniqueFileName;
                string thumbnailFilePath = Path.Combine(path, thumbnailFileName);

                using (var image = await Image.LoadAsync(file.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(65, 65),
                        Mode = ResizeMode.Crop
                    }));

                    await image.SaveAsync(thumbnailFilePath);
                }

                _logger.LogInformation($"Thumbnail created successfully: {thumbnailFileName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the thumbnail: {ex.Message}", ex);
                throw;
            }
        }
        private async Task CreateThumbnail252x200(IFormFile file, string path, string uniqueFileName)
        {
            try
            {
                string thumbnailFileName = "Thumb252x200-" + uniqueFileName;
                string thumbnailFilePath = Path.Combine(path, thumbnailFileName);

                using (var image = await Image.LoadAsync(file.OpenReadStream()))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(150, 150),
                        Mode = ResizeMode.Crop
                    }));

                    await image.SaveAsync(thumbnailFilePath);
                }

                _logger.LogInformation($"Thumbnail created successfully: {thumbnailFileName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the thumbnail: {ex.Message}", ex);
                throw;
            }
        }
    }
}

