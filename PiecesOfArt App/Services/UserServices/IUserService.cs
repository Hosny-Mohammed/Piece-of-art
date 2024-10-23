using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);

    }
}
