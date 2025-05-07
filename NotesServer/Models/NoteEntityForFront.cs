using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class NoteEntityForFront
    {
         public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
