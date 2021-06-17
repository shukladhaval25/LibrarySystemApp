using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Column("Title", TypeName = "ntext")]
        [MaxLength(50)]
        public string Title { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }
    }
}
