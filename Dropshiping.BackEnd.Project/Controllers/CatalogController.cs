using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost("AddCatalog")]
        public IActionResult AddCatalog(CatalogDto catalogDto)
        {
            try
            {
                _catalogService.Add(catalogDto);
                return Ok();
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }
    }
}
