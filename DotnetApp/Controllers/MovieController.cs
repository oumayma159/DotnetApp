using DotnetApp.Models;
using DotnetApp.Repositories.Repositories;
using DotnetApp.Repositories.RepositoriesContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotnetApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly IGenreRepository _GenreRepository;

        public MovieController(IMovieRepository MovieRepository, IGenreRepository GenreRepository)
        {
            _MovieRepository = MovieRepository;
            _GenreRepository = GenreRepository;
        }

        public ActionResult Index()
        {
            return View(_MovieRepository.GetAll());
        }

        public ActionResult Create()
        {
            var members = _GenreRepository.GetAll();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.GenreName.ToString(),
                Value = members.Id.ToString()
            });
            return View();
        }


        public ActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _MovieRepository.Add(movie);
                return RedirectToAction("Index");
            }
            return View("Create", movie);
        }

        public IActionResult Delete(Guid id)
        {
            _MovieRepository.Delete(_MovieRepository.Get(id));
            return RedirectToAction("Index");

        }


    }
}
