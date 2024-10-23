namespace PiecesOfArt_App.DTOs
{
    public class ArtDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly PublicationDate { get; set; }
        public string CategoryName { get; set; } = string.Empty; 
        public int UserId { get; set; } 
    }
            
}
