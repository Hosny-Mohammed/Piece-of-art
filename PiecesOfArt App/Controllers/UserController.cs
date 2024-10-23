using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.Services.UserServices;
using PiecesOfArt_App.Services.ArtServices;
using AutoMapper;
using PiecesOfArt_App.DTOs;

namespace PiecesOfArt_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IArtServices _artServices;
        private readonly ILoyaltyCardsServices _loyaltyCardsService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IArtServices artServices, ILoyaltyCardsServices loyaltyCardsService, IMapper mapper)
        {
            _userService = userService;
            _artServices = artServices;
            _loyaltyCardsService = loyaltyCardsService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO request)
        {
            var user = _mapper.Map<User>(request);

            var loyaltyCard = await _loyaltyCardsService.GetByName(request.LoyaltyCardName);
            if (loyaltyCard != null)
            {
                user.loyaltyCardId = loyaltyCard.Id;
                user.loyaltyCard = loyaltyCard;
            }

            foreach (var artName in request.PieceOfArtsNames)
            {
                var art = await _artServices.GetByName(artName);
                if (art != null)
                {
                    user.PieceOfArts.Add(art);
                }
            }

            await _userService.Add(user);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userDTOs = _mapper.Map<List<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO request)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
                return NotFound();

            _mapper.Map(request, existingUser);

            var loyaltyCard = await _loyaltyCardsService.GetByName(request.LoyaltyCardName);
            if (loyaltyCard != null)
            {
                existingUser.loyaltyCardId = loyaltyCard.Id;
                existingUser.loyaltyCard = loyaltyCard;
            }

            existingUser.PieceOfArts.Clear();
            foreach (var artName in request.PieceOfArtsNames)
            {
                var art = await _artServices.GetByName(artName);
                if (art != null)
                {
                    existingUser.PieceOfArts.Add(art);
                }
            }

            await _userService.Update(existingUser);
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            await _userService.Delete(id);
            return Ok();
        }
    }
}
