using IcSMP_ApiApp.DTOs;
using IcSMP_ApiApp.DTOs.CreateUpdateObjects;
using IcSMP_ApiApp.Helpers;
using IcSMP_ApiApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IcSMP_ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger)
        {
            _categoriesService = categoriesService;
            _logger = logger;
        }


        //Get all method
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetCategories started");

                var category = await _categoriesService.GetCategoriesAsync();
                if (category == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllCategories error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

        //Get by id method
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("GetCategories By Id started");
                var category = await _categoriesService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetCategoriesById error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

        //Create

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] Category category)
        {
            try
            {
                _logger.LogInformation("CreateCategoryAsync started");
                if (category == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _categoriesService.CreateCategoryAsync(category);
                return Ok(SuccessMessagesEnum.ElementSuccesfullyAdded);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateCategoryAsync error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

        //Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("DeleteCategoryAsync started");
                bool result = await _categoriesService.DeleteCategoryAsync(id);
                if(result)
                {
                    return Ok(SuccessMessagesEnum.ElementSuccesfullyDeleted);
                }
                return BadRequest(ErrorMessagesEnum.NoElementFound);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"DeleteCategoryAsync error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        //Update

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute]int id, [FromBody]CreateUpdateCategory category)
        {
            try
            {
                _logger.LogInformation("UpdateCategoryAsync started");
                if (category == null) 
                { 
                    return BadRequest(ErrorMessagesEnum.BadRequest); 
                }
                CreateUpdateCategory updatedCategory = await _categoriesService.UpdateCategoryAsync(id, category);
                if(updatedCategory == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent,ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccesfullyUpdated);
            }            

            catch (Exception ex)
            {
                _logger.LogError($"UpdateCategoryAsync error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartiallyCategoryAsync([FromRoute] int id, [FromBody] CreateUpdateCategory category)
        {
            try
            {
                _logger.LogInformation("UpdatePartiallyCategoryAsync started");
                if (category == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateCategory updatedCategory = await _categoriesService.UpdatePartiallyCategoryAsync(id, category);
                if (updatedCategory == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccesfullyUpdated);
            }

            catch (Exception ex)
            {
                _logger.LogError($"UpdatePartiallyCategoryAsync error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
