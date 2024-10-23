using PiecesOfArt_App.Models;

namespace PiecesOfArt_App.Services.UserServices
{
    public interface ILoyaltyCardsServices
    {
        Task<List<LoyaltyCard>> GetAllUsers();
        Task<LoyaltyCard> GetById(int id);
        Task Add(LoyaltyCard loyaltyCard);
        Task Update(LoyaltyCard loyaltyCard);
        Task Delete(LoyaltyCard loyaltyCard);

    }
}
