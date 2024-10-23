using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PiecesOfArt_App.Models
{
    public class LoyaltyCard
    {
        [Key]public int Id { get; set; }
        [MaxLength(50)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string Description { get; set; } = string.Empty;

        //Relations
        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }
    }
}
//Id, Name,
//Description. (Example: