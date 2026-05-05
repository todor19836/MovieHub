using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHub.Models;

namespace MovieHub.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string genre, double? minRating)
        {
            var movies = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                movies = movies.Where(m => m.Genre == genre);
            }

            if (minRating.HasValue)
            {
                movies = movies.Where(m => m.Rating >= minRating.Value);
            }

            ViewBag.Genres = await _context.Movies
                .Select(m => m.Genre)
                .Distinct()
                .ToListAsync();

            return View(await movies.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Recommend(string genre, double? minRating)
        {
            var movies = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(genre))
            {
                movies = movies.Where(m => m.Genre == genre);
            }

            if (minRating.HasValue)
            {
                movies = movies.Where(m => m.Rating >= minRating.Value);
            }

            var recommendedMovies = await movies
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Year)
                .Take(10)
                .ToListAsync();

            ViewBag.Genres = await _context.Movies
                .Select(m => m.Genre)
                .Distinct()
                .ToListAsync();

            return View(recommendedMovies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}