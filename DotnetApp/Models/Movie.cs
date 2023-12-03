using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApp.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }

        public DateTime Released { get; set; } = DateTime.Now;
        public DateTime Added { get; set; } = DateTime.Now;
        public string? Poster { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual Genre? genre { get; set; }
        public virtual ICollection<Customer>? customers { get; set; }
    }
}
