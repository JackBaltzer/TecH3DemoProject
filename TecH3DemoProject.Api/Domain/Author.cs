using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TecH3DemoProject.Api.Domain
{
    public class Author
    {

        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Firstname length can't be more than 32 chars")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Lastname length can't be more than 32 chars")]
        public string LastName { get; set; }


        public List<Book> Books { get; set; }
    }
}
