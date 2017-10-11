using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Terminator" },
                new Movie { Id = 3, Name = "Mad Max: Fury Road" }
            };
        }

        // GET: Movie
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            var movies = GetMovies();

            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Elle" },
                new Customer { Name = "Ashley" },
                new Customer { Name = "Brooke" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id: " + id);
        }

        [Route("Movie/ByReleaseDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }
            if (!month.HasValue)
            {
                month = DateTime.Now.Month;
            }
            return Content(String.Format("Year: {0}, Month: {1}", year, month));
        }
    }
}