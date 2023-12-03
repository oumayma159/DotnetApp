using DotnetApp.Models;
using DotnetApp.Repositories.RepositoriesContracts;

namespace DotnetApp.Repositories.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DotnetAppDbContext _db;
        public MovieRepository(DotnetAppDbContext db)
        {
            _db = db;
        }
        public ICollection<Movie> GetAll()
        {

            return _db.Movies.ToList();
        }

        public Movie Get(Guid id)
        {
            return _db.Movies.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.Poster = $"/images/{movie.ImageFile.FileName}";
            }
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
        }

    }
}
