using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace NotesServer.Models
{
    public class NoteEntity
    {
        public NoteEntity(string Name, string Text, Guid UserId) {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Text = Text;
            this.UserId = UserId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public UserEntity? User { get; set; }
    }

}
