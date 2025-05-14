namespace TheSampleApi.Models;

public class MovieModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Director { get; set; }
    public List<string> Actors { get; set; } = new List<string>();
    public string Genre { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

}
