using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Data;
using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.UserServices
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllUsers()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id==id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
           await _context.SaveChangesAsync();
        }
    }
}
