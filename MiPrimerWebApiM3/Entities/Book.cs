using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApiM3.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AutorId { get; set; }

        public Autor Autor { get; set; }
    }
}