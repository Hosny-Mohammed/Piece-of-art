using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.UserServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllUsers();
        Task<Category> GetById(int id);
        Task<Category> GetByName(string name);
        Task Add(Category category);
        Task Delete(int id);
        Task Update(Category category);

    }
}
