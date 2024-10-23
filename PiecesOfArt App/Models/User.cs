using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PiecesOfArt_App.Models
{
    public class User
    {
        [Key] public int Id { get; set; }  
        public string Name { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        //relations
        public virtual ICollection<Art>? PieceOfArts { get; set; }

        public int loyaltyCardId { get; set; }
        [ForeignKey(nameof(loyaltyCardId))]
        [JsonIgnore]
        public LoyaltyCard? loyaltyCard { get; set; }
    }
}
