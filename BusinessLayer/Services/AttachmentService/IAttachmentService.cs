using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.AttachmentService
{
    public interface IAttachmentService
    {
        public string? Upload(IFormFile file, string folderName);
        public bool Delete(string filePath);
    }
}
