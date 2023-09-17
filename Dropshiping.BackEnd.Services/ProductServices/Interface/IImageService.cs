using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Services.ProductServices.Interface
{
    public interface IImageService
    {
        public void AddImage(ImageDto imageDto);
    }
}
