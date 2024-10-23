using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.Services.ArtServices;
using PiecesOfArt_App.Services.UserServices;
using AutoMapper;
using PiecesOfArt_App.DTOs;

namespace PiecesOfArt_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly IArtServices _artServices;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ArtController(IArtServices artServices, IUserService userService, ICategoryService categoryService, IMapper mapper)
        {
            _artServices = artServices;
            _userService = userService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddArt(ArtDTO request)
        {
            var art = _mapper.Map<Art>(request);

            var user = await _userService.GetById(request.UserId);
            if (user == null)
                return BadRequest("Invalid User ID");

            art.userID = user.Id;
            art.user = user;

            var category = await _categoryService.GetByName(request.CategoryName);
            if (category != null)
            {
                art.categoryID = category.Id;
                art.category = category;
            }

            await _artServices.Add(art);
            return Ok(art);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtById(int id)
        {
            var art = await _artServices.GetById(id);
            if (art == null)
                return NotFound();

            var artDTO = _mapper.Map<ArtDTO>(art);
            return Ok(artDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArts()
        {
            var arts = await _artServices.GetAllUsers();
            var artDTOs = _mapper.Map<List<ArtDTO>>(arts);
            return Ok(artDTOs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArt(int id, ArtDTO request)
        {
            var existingArt = await _artServices.GetById(id);
            if (existingArt == null)
                return NotFound();

            _mapper.Map(request, existingArt);

            var user = await _userService.GetById(request.UserId);
            if (user == null)
                return BadRequest("Invalid User ID");

            existingArt.userID = user.Id;
            existingArt.user = user;

            var category = await _categoryService.GetByName(request.CategoryName);
            if (category != null)
            {
                existingArt.categoryID = category.Id;
                existingArt.category = category;
            }

            await _artServices.Update(existingArt);
            return Ok(existingArt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt(int id)
        {
            var art = await _artServices.GetById(id);
            if (art == null)
                return NotFound();

            await _artServices.Delete(id);
            return Ok();
        }
    }
}
