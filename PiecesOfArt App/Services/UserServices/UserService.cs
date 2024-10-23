using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Data;
using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(x => x.PieceOfArts).ThenInclude(c => c.category).Include(y => y.loyaltyCard).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Include(x => x.PieceOfArts).
                ThenInclude(c => c.category).Include(y => y.loyaltyCard).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));

        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(User user)
        {
            _context.Users.Update(user);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
           _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
