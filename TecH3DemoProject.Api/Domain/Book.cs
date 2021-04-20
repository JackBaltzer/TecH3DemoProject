using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3DemoProject.Api.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Title length can't be more than 32 chars")]
        public string Title { get; set; }

        [Required]
        public int Pages { get; set; }

        public DateTime Publised { get; set; } = DateTime.Now;

        [ForeignKey("Author.Id")]
        public int AuthorId { get; set; }
    }
}
