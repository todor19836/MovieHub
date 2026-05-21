using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieHub.Models;

namespace MovieHub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            AppDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // ── Dashboard ────────────────────────────────────────────────────────
        public async Task<IActionResult> Index()
        {
            ViewBag.MovieCount = await _context.Movies.CountAsync();
            ViewBag.UserCount = _userManager.Users.Count();
            ViewBag.GenreCount = await _context.Movies
                .Select(m => m.Genre).Distinct().CountAsync();
            ViewBag.TopMovie = await _context.Movies
                .OrderByDescending(m => m.Rating).FirstOrDefaultAsync();
            return View();
        }

        // ── Movies ───────────────────────────────────────────────────────────
        public async Task<IActionResult> Movies()
        {
            var movies = await _context.Movies
                .OrderByDescending(m => m.Id).ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> EditMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMovie(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            _context.Update(movie);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"'{movie.Title}' updated successfully.";
            return RedirectToAction(nameof(Movies));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"'{movie.Title}' deleted.";
            }
            return RedirectToAction(nameof(Movies));
        }

        // ── Users ─────────────────────────────────────────────────────────
        public async Task<IActionResult> Users()
        {
            var users = _userManager.Users.ToList();
            var model = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email ?? "",
                    Roles = roles.ToList()
                });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            if (user.Email == User.Identity!.Name)
            {
                TempData["Error"] = "You cannot change your own admin status.";
                return RedirectToAction(nameof(Users));
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                TempData["Success"] = $"{user.Email} removed from Admin.";
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                TempData["Success"] = $"{user.Email} promoted to Admin.";
            }
            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            if (user.Email == User.Identity!.Name)
            {
                TempData["Error"] = "You cannot delete your own account here.";
                return RedirectToAction(nameof(Users));
            }

            await _userManager.DeleteAsync(user);
            TempData["Success"] = $"User {user.Email} deleted.";
            return RedirectToAction(nameof(Users));
        }
    }

    public class UserRoleViewModel
    {
        public string UserId { get; set; } = "";
        public string Email { get; set; } = "";
        public List<string> Roles { get; set; } = new();
    }
}