using Microsoft.AspNetCore.Http;
using MVCBlog.Entity.DTOs.Images;
using MVCBlog.Entity.Enums;

namespace MVCBlog.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
