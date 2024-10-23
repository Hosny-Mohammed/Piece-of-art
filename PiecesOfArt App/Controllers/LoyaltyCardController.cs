using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_App.Models;
using PiecesOfArt_App.Services.UserServices;
using AutoMapper;
using PiecesOfArt_App.DTOs;

namespace PiecesOfArt_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardController : ControllerBase
    {
        private readonly ILoyaltyCardsServices _loyaltyCardsService;
        private readonly IMapper _mapper;

        public LoyaltyCardController(ILoyaltyCardsServices loyaltyCardsService, IMapper mapper)
        {
            _loyaltyCardsService = loyaltyCardsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLoyaltyCard(LoyaltyCardDTO request)
        {
            var loyaltyCard = _mapper.Map<LoyaltyCard>(request);
            await _loyaltyCardsService.Add(loyaltyCard);
            return Ok(loyaltyCard);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoyaltyCardById(int id)
        {
            var loyaltyCard = await _loyaltyCardsService.GetById(id);
            if (loyaltyCard == null)
                return NotFound();

            var loyaltyCardDTO = _mapper.Map<LoyaltyCardDTO>(loyaltyCard);
            return Ok(loyaltyCardDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoyaltyCards()
        {
            var loyaltyCards = await _loyaltyCardsService.GetAllUsers();
            var loyaltyCardDTOs = _mapper.Map<List<LoyaltyCardDTO>>(loyaltyCards);
            return Ok(loyaltyCardDTOs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoyaltyCard(int id, LoyaltyCardDTO request)
        {
            var existingLoyaltyCard = await _loyaltyCardsService.GetById(id);
            if (existingLoyaltyCard == null)
                return NotFound();

            _mapper.Map(request, existingLoyaltyCard);
            await _loyaltyCardsService.Update(existingLoyaltyCard);
            return Ok(existingLoyaltyCard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyCard(int id)
        {
            var loyaltyCard = await _loyaltyCardsService.GetById(id);
            if (loyaltyCard == null)
                return NotFound();

            await _loyaltyCardsService.Delete(id);
            return Ok();
        }
    }
}
