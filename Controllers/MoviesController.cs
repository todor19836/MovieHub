using Microsoft.AspNetCore.Mvc;
using MovieHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieHub.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Year = 2010, Rating = 8.8 },
            new Movie { Id = 2, Title = "Titanic", Genre = "Romance", Year = 1997, Rating = 7.8 },
            new Movie { Id = 3, Title = "Interstellar", Genre = "Sci-Fi", Year = 2014, Rating = 8.6 },
            new Movie { Id = 4, Title = "The Dark Knight", Genre = "Action", Year = 2008, Rating = 9.0 }
        };

        public IActionResult Index()
        {
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        public IActionResult Recommend(string genre)
        {
            var recommended = movies.Where(m => m.Genre == genre).ToList();
            return View(recommended);
        }
    }
}