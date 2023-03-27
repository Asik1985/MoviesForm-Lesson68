using Microsoft.EntityFrameworkCore;
using MovieForm.Models;

namespace MovieForm.Data;

public class MovieFormContext : DbContext
{
    public MovieFormContext(DbContextOptions<MovieFormContext> options)
            : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}
