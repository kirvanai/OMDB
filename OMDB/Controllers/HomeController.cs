using Microsoft.AspNetCore.Mvc;
using OMDB.Models;
using System.Diagnostics;

namespace OMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]    
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }

        [HttpPost]
        public IActionResult MovieSearchResults(string title)
        {
            Movie m = MovieDAL.GetMovie(title);
            return View("MovieSearch", m);
        }
        [HttpGet]
        public IActionResult MovieNightForm() 
        {
            return View("MovieNight");
        }
        [HttpPost]
        public IActionResult MovieNightResults(string title1, string title2, string title3)
        {
            Movie m1 = MovieDAL.GetMovie(title1);
            Movie m2 = MovieDAL.GetMovie(title2);
            Movie m3 = MovieDAL.GetMovie(title3);
            List<Movie> movies = new List<Movie>();
            movies.Add(m1);
            movies.Add(m2);
            movies.Add(m3);
            return View("MovieNight", movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}