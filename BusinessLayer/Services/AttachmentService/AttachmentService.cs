using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = [".png", ".jpg", ".jpeg"];
        const int maxSize = 2_097_152;
        public bool Delete(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            File.Delete(filePath);
            return true;
        }
        public string? Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            //1-check extension
            if (!allowedExtensions.Contains(extension)) return null;
            //2-check size
            if (file.Length == 0 || file.Length > maxSize) return null;
            //3-get located folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            //4-make attached name unique
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            //5-get file path
            var filePath = Path.Combine(folderPath, fileName);
            //6-create file stream to copy file [unmanaged]
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            //7-use stream to copy file
            file.CopyTo(fs);
            //8-return file name to store in database
            return fileName;
        }
    }
}
