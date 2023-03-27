using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieForm.Data;
using MovieForm.Models;
using System.Numerics;

namespace MovieForm.Controllers;

public class MoviesController : Controller
{
    private readonly MovieFormContext _db;
    public MoviesController(MovieFormContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Movie> movies = _db.Movies.ToList();
        return View(movies);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(_db.Categories, "Id", "Name");
        return View(movie);
    }

    public IActionResult Detail(int id)
    {
        Movie? movie = _db.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }
    public IActionResult Delete(int id)
    {
        Movie? movie = _db.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }
    [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        Movie? movie = _db.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        _db.Movies.Remove(movie);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
