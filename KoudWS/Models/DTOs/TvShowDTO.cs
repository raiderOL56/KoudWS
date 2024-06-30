namespace KoudWS.Models.DTOs
{
    public class TvShowDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Favorite { get; set; }
    }
}