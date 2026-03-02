using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.DTO.Request;
using KASHOP.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Localization;
using Mapster;
using Microsoft.EntityFrameworkCore;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Repositry;
using KASHOP.BBL.Service;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public CategoriesController(ICategoryService categoryService, IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer; // for translation / get data from shared resources 
            _categoryService = categoryService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryRequest request)  
        {
            var response = await _categoryService.CreateCategoryAsync(request);
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response
            });
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(
                new
                {
                    data = categories,
                    _localizer["Success"].Value
                });
        }

    }
}
