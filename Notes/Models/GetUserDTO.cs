namespace Notes.Models
{
    public class GetUserDTO
    {
        public GetUserDTO(Guid Id, string login) {
            this.Id = Id;
            this.login = login;
        }

        public Guid Id { get; set; }

        public string login { get; set; } = string.Empty;
    }
}
