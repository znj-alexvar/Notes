using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class UserEntity
    {
        public UserEntity(string login, string password) { 
            Id = Guid.NewGuid();
            this.login = login;
            this.password = password;
        }

        public Guid Id { get; set; }

        public string login { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public List<NoteEntity> Notes { get; set; } = [];
    }
}
