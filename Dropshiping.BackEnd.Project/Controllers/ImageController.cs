using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("AddImage")]
        public IActionResult AddImage([FromBody] ImageDto imageDto)
        {
            try
            {
                _imageService.AddImage(imageDto);
                return StatusCode(StatusCodes.Status204NoContent, "Image created");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

    }
}
