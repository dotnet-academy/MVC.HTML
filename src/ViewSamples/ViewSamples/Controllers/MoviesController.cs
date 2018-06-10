using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewSamples.Models;

namespace ViewSamples.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()
        {
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(MemoryContext.Movies.ToList());
        }

        // GET: Movies/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null) {
                return NotFound();
            }

            var movie = MemoryContext.Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie == null) {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid) {
                MemoryContext.Movies.Add(movie);
                MemoryContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null) {
                return NotFound();
            }

            var movie = MemoryContext.Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie == null) {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            Guid id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            var storedMovie = MemoryContext.Movies
                .FirstOrDefault(m => m.Id == id);

            if (storedMovie == null || storedMovie.Id != movie.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                storedMovie = movie;
                MemoryContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            var movie = MemoryContext.Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie == null) {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = MemoryContext.Movies
                .FirstOrDefault(m => m.Id == id);

            MemoryContext.Movies.Remove(movie);
            MemoryContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
