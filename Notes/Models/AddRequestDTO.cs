namespace Notes.Models
{
    public class AddRequestDTO
    {
        public required string Name { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public string UserId { get; set; }
    }
}
