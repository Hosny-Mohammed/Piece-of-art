using PiecesOfArt_App.Models;
using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_App.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string LoyaltyCardName { get; set; } = string.Empty ;
        public List<String>? PieceOfArtsNames { get; set; }

    }
}
