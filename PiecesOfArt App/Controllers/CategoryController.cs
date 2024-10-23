using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_App.Models;
using AutoMapper;
using PiecesOfArt_App.DTOs;
using PiecesOfArt_App.Services.UserServices;

namespace PiecesOfArt_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryService.Add(category);
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return Ok(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllUsers(); // Make sure this method is implemented
            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO request)
        {
            var existingCategory = await _categoryService.GetById(id);
            if (existingCategory == null)
                return NotFound();

            _mapper.Map(request, existingCategory);
            await _categoryService.Update(existingCategory);
            return Ok(existingCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            await _categoryService.Delete(id);
            return Ok();
        }
    }
}
