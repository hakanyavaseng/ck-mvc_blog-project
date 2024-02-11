using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MVCBlog.Entity.DTOs.Images;
using MVCBlog.Entity.Enums;

namespace MVCBlog.Service.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string wwwroot;

        //Constant folder directories
        private const string imageFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            this.wwwroot = _webHostEnvironment.WebRootPath; //Gets the wwwroot folder path and assigns it to the wwwroot variable
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                     .Replace("ı", "i")
                     .Replace("Ğ", "G")
                     .Replace("ğ", "g")
                     .Replace("Ü", "U")
                     .Replace("ü", "u")
                     .Replace("ş", "s")
                     .Replace("Ş", "S")
                     .Replace("Ö", "O")
                     .Replace("ö", "o")
                     .Replace("Ç", "C")
                     .Replace("ç", "c")
                     .Replace("é", "")
                     .Replace("!", "")
                     .Replace("'", "")
                     .Replace("^", "")
                     .Replace("+", "")
                     .Replace("%", "")
                     .Replace("/", "")
                     .Replace("(", "")
                     .Replace(")", "")
                     .Replace("=", "")
                     .Replace("?", "")
                     .Replace("_", "")
                     .Replace("*", "")
                     .Replace("æ", "")
                     .Replace("ß", "")
                     .Replace("@", "")
                     .Replace("€", "")
                     .Replace("<", "")
                     .Replace(">", "")
                     .Replace("#", "")
                     .Replace("$", "")
                     .Replace("½", "")
                     .Replace("{", "")
                     .Replace("[", "")
                     .Replace("]", "")
                     .Replace("}", "")
                     .Replace(@"\", "")
                     .Replace("|", "")
                     .Replace("~", "")
                     .Replace("¨", "")
                     .Replace(",", "")
                     .Replace(";", "")
                     .Replace("`", "")
                     .Replace(".", "")
                     .Replace(":", "")
                     .Replace(" ", "");

        }

        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine(wwwroot, imageFolder, imageName);
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);

        }

        public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;

            if (!Directory.Exists(Path.Combine(wwwroot, imageFolder, folderName)))
            {
                Directory.CreateDirectory(Path.Combine(wwwroot, imageFolder, folderName));
            }

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);

            name = ReplaceInvalidChars(name);

            string newFileName = $"{name}_{DateTime.Now.Millisecond}{fileExtension}";

            var path = Path.Combine(wwwroot, imageFolder, folderName, newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
            await imageFile.CopyToAsync(stream);

            string message = imageType == ImageType.User ? $"{folderName}/{newFileName} isimli kullanıcı fotoğrafı başarıyla eklenmiştir." : $"{folderName}/{newFileName} isimli makale fotoğrafı başarıyla eklenmiştir.";

            return new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }
    }
}
