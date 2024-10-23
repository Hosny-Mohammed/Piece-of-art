using PiecesOfArt_App.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using PiecesOfArt_App.Data;

namespace PiecesOfArt_App.Services.ArtServices
{
    public interface IArtServices
    {
        Task<List<Art>> GetAllUsers();
        Task<Art> GetById(int id);
        Task<Art> GetByName(string name);
        Task Add(Art art);
        Task Delete(int id);
        Task Update(Art art);
    }
}