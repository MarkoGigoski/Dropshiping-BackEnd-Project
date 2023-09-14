using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productService.GetAll();

                return Ok(products);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = _productService.GetById(id);

                return Ok(product);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductDto productDto)
        {
            try
            {
                _productService.Add(productDto);
                return Ok();
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]ProductDto productDto)
        {
            try
            {
                _productService.Update(productDto);

                return StatusCode(StatusCodes.Status204NoContent, "Product updated");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                
                _productService.DeleteById(id);

                return StatusCode(StatusCodes.Status204NoContent, "Product deleted");

            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }
    }
}
