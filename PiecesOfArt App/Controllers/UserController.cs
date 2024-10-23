using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PiecesOfArt_App.Data;
using PiecesOfArt_App.DTOs;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.Services.UserServices;

namespace PiecesOfArt_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILoyaltyCardsServices _loyaltyCardsService;
        private readonly ICategoryService _categoryService;
        public UserController(IMapper mapper, IUserService context, ILoyaltyCardsServices loyaltyCardsService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _userService = context;
            _categoryService = categoryService;
            _loyaltyCardsService = loyaltyCardsService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(UpdateUserRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var MappedUser = _mapper.Map<User>(request);
        //        await _userService.Add(MappedUser);
        //        return Ok();
        //    }
        //    else
        //        return BadRequest();
        //}

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            var users = await _userService.GetAllUsers();
            var Dto = _mapper.Map<ICollection<UserDTO>>(users);
            return Ok(Dto);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        //{
        //    var user = await _userService.GetById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    user.Name = request.Name;
        //    user.Age = request.Age;

        //    var pieceOfArt = user.PieceOfArts.FirstOrDefault();
        //    if (pieceOfArt != null)
        //    {
        //        pieceOfArt.Title = request.PieceOfArtTitle;
        //        var category = await _categoryService.GetByName(request.CategoryName);
        //        if (category != null)
        //        {
        //            pieceOfArt.categoryID = category.Id;
        //            pieceOfArt.category = category;
        //        }
        //    }

        //    var loyaltyCard = await _loyaltyCardsService.GetByName(request.LoyaltyCardName);
        //    if (loyaltyCard != null)
        //    {
        //        user.loyaltyCardId = loyaltyCard.Id;
        //        user.loyaltyCard = loyaltyCard;
        //    }
        //    await _userService.Update(user);
        //    return Ok(request);

        //}
        // i need to handle a

    }
}
