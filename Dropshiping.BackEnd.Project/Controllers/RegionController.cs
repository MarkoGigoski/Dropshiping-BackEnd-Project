using System;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var regions = _regionService.GetAll();
                return Ok(regions);
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
                var region = _regionService.GetById(id);
                return Ok(region);
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

        [HttpPost("AddRegion")]
        public IActionResult AddRegion(RegionDto regionDto)
        {
            try
            {
                _regionService.Add(regionDto);
                return StatusCode(StatusCodes.Status204NoContent, "Region added");
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

        [HttpPut("UpdateRegion")]
        public IActionResult UpdateRegion(RegionDto regionDto)
        {
            try
            {
                _regionService.Update(regionDto);
                return StatusCode(StatusCodes.Status204NoContent, "Region updated");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                _regionService.DeleteById(id);
                return StatusCode(StatusCodes.Status204NoContent, "Region deleted");
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
