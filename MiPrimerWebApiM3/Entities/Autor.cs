using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApiM3.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}