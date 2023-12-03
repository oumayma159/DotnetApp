using DotnetApp.Models;
using DotnetApp.Repositories.RepositoriesContracts;

namespace DotnetApp.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DotnetAppDbContext _db;
        public GenreRepository(DotnetAppDbContext db)
        {
            _db = db;
        }
        public ICollection<Genre> GetAll()
        {

            return _db.Genres.ToList();
        }

        public Genre Get(Guid id)
        {
            return _db.Genres.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Genre genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
        }

        public void Delete(Genre genre)
        {
            _db.Genres.Remove(genre);
            _db.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _db.Genres.Update(genre);
            _db.SaveChanges();
        }

    }
}
