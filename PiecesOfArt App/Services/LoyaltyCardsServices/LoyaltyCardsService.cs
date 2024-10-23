using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Data;
using PiecesOfArt_App.Models;
using System.Threading.Tasks;

namespace PiecesOfArt_App.Services.UserServices
{
    public class LoyaltyCardsService : ILoyaltyCardsServices
    {
        private readonly AppDbContext _context;
        public LoyaltyCardsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoyaltyCard>> GetAllUsers()
        {
            return await _context.LoyaltyCards.ToListAsync();
        }
        public async Task<LoyaltyCard> GetById(int id)
        {
            return await _context.LoyaltyCards.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LoyaltyCard> GetByName(string name)
        {
            return await _context.LoyaltyCards.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task Update(LoyaltyCard loyaltyCard)
        {
            _context.LoyaltyCards.Update(loyaltyCard);
           await _context.SaveChangesAsync();
        }
        public async Task Add(LoyaltyCard loyaltyCard)
        {
            _context.LoyaltyCards.Add(loyaltyCard);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var loyaltyCard = await _context.LoyaltyCards.FindAsync(id);
            _context.LoyaltyCards.Remove(loyaltyCard);
             await _context.SaveChangesAsync();
        }
    }
}
