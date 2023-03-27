using System.ComponentModel.DataAnnotations;

namespace MovieForm.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(100, 2000)]
    public int Price { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

}
