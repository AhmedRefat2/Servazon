using Microsoft.AspNetCore.Mvc;
using Servazon.Application.Services.Contracts;

namespace Servazon.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //public async Task<IActionResult> IndexAsync()
        //{
        //    var categories = await _categoryService.GetAllAsync();

        //}
    }
}
