namespace DotnetApp.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Movie>? movies { get; set; }
    }
}
