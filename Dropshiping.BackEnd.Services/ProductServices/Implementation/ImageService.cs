using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class ImageService : IImageService
    {
        private IRepository<Image> _imageRepository;
        public ImageService(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public void AddImage(ImageDto imageDto)
        {
            var image = new Image
            {
                Id = imageDto.Id,
                Name = imageDto.Name,
            };

            _imageRepository.Add(image);
        }
    }
}
