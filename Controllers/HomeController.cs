using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mission06_LamoreauxAbe.Models;
using System.Diagnostics;

namespace Mission06_LamoreauxAbe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MoviesHiltonContext _movieHiltonContext;

        public HomeController(MoviesHiltonContext snapshot)
        {
            _movieHiltonContext = snapshot;
        }

        public IActionResult Index()
        {
            return View();
        }
        //This is the form for adding movies
        //public IActionResult MoviesAdd()
        //{
        //    return View();
        //}

        public IActionResult AboutMe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoviesAdd()
        {
            ViewBag.category = _movieHiltonContext.Categories.OrderBy(x => x.CategoryId).ToList();

            return View("MoviesAdd", new Movies());
        }

        [HttpPost]
        //This runs the database
        public IActionResult MoviesAdd(Movies response) {

            if (ModelState.IsValid) { 
            _movieHiltonContext.Add(response); // add the record to the database.
            _movieHiltonContext.SaveChanges();
                return View("Index");
            }
            else 
            {
                ViewBag.category = _movieHiltonContext.Categories.OrderBy(x => x.CategoryId).ToList();
                return View("MoviesAdd", response);
            }//invlaid info

        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public IActionResult ViewMovies()
        {
            //this is my Linq query.
           var applications = _movieHiltonContext.Movies
               .OrderBy(x => x.MovieId).ToList();



            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int id) {

           Movies recordToEdit = _movieHiltonContext.Movies.Single(x => x.MovieId == id);

            ViewBag.category = _movieHiltonContext.Categories.OrderBy(x => x.CategoryId).ToList();

            return View("MoviesAdd", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            _movieHiltonContext.Update(updatedInfo);
            _movieHiltonContext.SaveChanges();


            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Movies recordToDelete = _movieHiltonContext.Movies.Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies application)
        {
            _movieHiltonContext.Movies.Remove(application);
            _movieHiltonContext.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
    }

}

