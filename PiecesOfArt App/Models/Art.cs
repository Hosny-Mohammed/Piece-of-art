using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PiecesOfArt_App.Models
{
    public class Art
    {
        [Key] public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "You exceeded Max length")]
        public string Title { get; set; } = string.Empty;
        public DateOnly PublicationDate { get; set; }
        [MaxLength(100, ErrorMessage = "You exceeded Max length")]
        public string Description { get; set; } = string.Empty;

        //Relations
        public int userID { get; set; }
        [ForeignKey(nameof(userID))]
        [JsonIgnore]
        public User? user { get; set; }

        public int categoryID { get; set; }
        [ForeignKey(nameof(categoryID))]
        [JsonIgnore]
        public Category? category { get; set; }
    }
}