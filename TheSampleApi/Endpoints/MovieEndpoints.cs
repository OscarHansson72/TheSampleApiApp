using TheSampleApi.Data;
using TheSampleApi.Models;

namespace TheSampleApi.Endpoints;

public static class MovieEndpoints
{
    public static void AddMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", LoadAllMoviesAsync);
        app.MapGet("/movies/{id}", LoadMovieByIdAsync);
    }

    private static async Task<IResult> LoadAllMoviesAsync(MovieData data, string? genre, string? search, int? delay)
    {
        var output = data.Movies;

        if (!string.IsNullOrWhiteSpace(genre))
        {
            output.RemoveAll(m => !m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            output.RemoveAll(m =>
                !m.Name.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                !m.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (delay is not null)
        {
            // Max delay is 5 minutes
            if (delay > 300000)
            {
                delay = 300000;
            }

            await Task.Delay((int)delay);
        }

        return Results.Ok(output);
    }

    private static async Task<IResult> LoadMovieByIdAsync(MovieData data, Guid id, int? delay)
    {
        var output = data.Movies.SingleOrDefault(m => m.Id == id);

        if (delay is not null)
        {
            // Max delay is 5 minutes
            if (delay > 300000)
            {
                delay = 300000;
            }

            await Task.Delay((int)delay);
        }

        if (output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
