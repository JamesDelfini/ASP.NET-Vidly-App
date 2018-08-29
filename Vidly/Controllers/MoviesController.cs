using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = new Movies() { Name = "Khalid <3 Issays!"};

            var customer = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomViewModel()
            {
                Movie = movies,
                Customers = customer
            };

            //return View(movies);
            return View(viewModel);

            // Action Results
            // return Content("Hello World");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new{ page = 1, sortBy="name" });

            // Do not use ViewData or ViewBag to pass a data to the view.
            // ViewData["RandomMovie"] = movie;
            // Access in view @( ((Movie) ViewData["Movie"]).RandomMovie )
            // ViewBag.Movie = movie;
            // Access in view @( ViewBag.RandomMovie )
        }

        /* 
        * Sample Action Links
        * http://localhost:50113/movies/edit/?movieId=3
        * 
        */
        public ActionResult Edit(int movieId)
        {
            // The default Edit ID passed variable name is id stated in the router.
            return Content("You have passed ID: " + movieId);
        }

        /* 
         *  Sample Action Links
         *  http://localhost:50113/movies
         *  http://localhost:50113/movies?pageIndex=3
         *  http://localhost:50113/movies?pageIndex=3&sortBy=ReleaseDate
         * 
         */
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = GetMovies();
            return View(movies);

            /**
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            */
        }

        public ActionResult Show(int? id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult oldByReleaseDate(int year, int month)
        {
            return Content("Year: " + year + "<br>Month: " + month);
        }

        // Attribute Routes Constraints
        // It is supported by the framework is called ASP.NET MVC Attribute Route Constraints
        [Route("movies/new/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult newByReleaseDate(int year, int month)
        {
            return Content("Year: " + year + "<br>Month: " + month);
        }


        [Route("movies/test/{test=WUT}")]
        public ActionResult test(string test)
        {
            return Content("TEST: " + test);
        }

        public IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies { Id = 1, Name = "Rise of the Guardians" },
                new Movies { Id = 2, Name = "American Pie" }
            };
        }
    }
}