using DotnetApp.Models;

namespace DotnetApp.Repositories.RepositoriesContracts
{
    public interface IGenreRepository
    {
        public ICollection<Genre> GetAll();
        public Genre Get(Guid id);
        public void Update(Genre genre);
        public void Delete(Genre genre);
        public void Add(Genre genre);
    }
}
