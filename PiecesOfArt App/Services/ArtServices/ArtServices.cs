using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Data;
using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.ArtServices
{
    public class ArtServices : IArtServices
    {
        private readonly AppDbContext _context;
        public ArtServices(AppDbContext context) 
        { _context = context; }
        public async Task Add(Art art)
        {
            await _context.Arts.AddAsync(art);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var art = await _context.Arts.FindAsync(id);
            _context.Arts.Remove(art);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Art>> GetAllUsers()
        {
          return await _context.Arts.Include(x => x.category).ToListAsync();
        }

        public async Task<Art> GetById(int id)
        {
            return await _context.Arts.Include(x => x.category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Art> GetByName(string name)
        {
            return await _context.Arts.Include(x => x.category).FirstOrDefaultAsync(x => x.Title.ToLower().Equals(name.ToLower()));
        }

        public async Task Update(Art art)
        {
             _context.Arts.Update(art);
            await _context.SaveChangesAsync();
        }
    }
}
