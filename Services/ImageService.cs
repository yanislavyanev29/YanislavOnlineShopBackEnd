using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace YanislavOnlineShopBackEnd.Services
{
    public class ImageService
    {

        private readonly Cloudinary _cloudinary;

        public ImageService()
        {

            var account = new Account
            (
                "dmmgwsgv7",
                "164242617539459",
                "GesN5I8VaDCe7RBwBKGmHxwvY7s"

            );

             _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
        {

            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {

            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
