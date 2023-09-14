using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private ISubcategoryService _subcategoryService;
        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var subcategories = _subcategoryService.GetAll();
                return Ok(subcategories);
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
                var subcategory = _subcategoryService.GetById(id);
                return Ok(subcategory); 
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

        [HttpPost("AddSubcategory")]
        public IActionResult AddSubcategory(SubcategoryDto subcategoryDto)
        {
            try
            {
                _subcategoryService.Add(subcategoryDto);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpPut("UpdateSubcategory")]
        public IActionResult UpdateSubcategory([FromBody]SubcategoryDto subcategoryDto)
        {
            try
            {
                _subcategoryService.Update(subcategoryDto);
                return StatusCode(StatusCodes.Status204NoContent, "Subcategory updated");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategory(string id)
        {
            try
            {
                _subcategoryService.DeleteById(id);
                return StatusCode(StatusCodes.Status204NoContent, "Subcategory deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
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
