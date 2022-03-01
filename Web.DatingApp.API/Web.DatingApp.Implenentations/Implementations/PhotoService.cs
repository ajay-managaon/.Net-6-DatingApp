using Azure.Storage.Blobs;
using Web.DatingApp.API.Web.DatingApp.Interfaces.Repositories;

namespace Web.DatingApp.API.Web.DatingApp.Implenentations.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly IContainerService containerService;
        private readonly BlobServiceClient blobServiceClient;

        public PhotoService(IContainerService containerService, BlobServiceClient blobServiceClient)
        {
            this.containerService = containerService;
            this.blobServiceClient = blobServiceClient;
        }
        public BlobClient AdPhotoAsync(IFormFile file)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerService.GetContainer());
            var clientOptions = containerClient.GetBlobClient(file.Name);
            return clientOptions;
        }

        public bool DeletePhoto(string publicId)
        {
            throw new NotImplementedException();
        }
    }
}
