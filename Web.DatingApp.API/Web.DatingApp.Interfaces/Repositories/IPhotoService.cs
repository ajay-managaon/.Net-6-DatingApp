using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace Web.DatingApp.API.Web.DatingApp.Interfaces.Repositories
{
    public interface IPhotoService
    {
        BlobClient AdPhotoAsync(IFormFile file);
        bool DeletePhoto(string publicId);
    }
}
