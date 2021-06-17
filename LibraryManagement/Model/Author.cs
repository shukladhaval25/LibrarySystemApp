using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Column("FirstName", TypeName = "ntext")]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Column("LastName", TypeName = "ntext")]
        [MaxLength(30)]
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
