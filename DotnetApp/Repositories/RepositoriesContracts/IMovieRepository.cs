using DotnetApp.Models;

namespace DotnetApp.Repositories.RepositoriesContracts
{
    public interface IMovieRepository
    {
        public ICollection<Movie> GetAll();
        public Movie Get(Guid id);
        public void Update(Movie movie);
        public void Delete(Movie movie);
        public void Add(Movie movie);
    }
}
