using System.Text.Json;
using TheSampleApi.Models;

namespace TheSampleApi.Data;

public class MovieData
{
    public List<MovieModel> Movies { get; private set; }

    public MovieData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "moviedata.json");

        string json = File.ReadAllText(filePath);

        Movies = JsonSerializer.Deserialize<List<MovieModel>>(json, options) ?? new List<MovieModel>();
    }
}
