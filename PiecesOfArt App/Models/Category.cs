using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiecesOfArt_App.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        [MaxLength(50)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string Description { get; set; } = string.Empty;

        //Relations
        public virtual ICollection<Art>? Arts { get; set; }
    }
}