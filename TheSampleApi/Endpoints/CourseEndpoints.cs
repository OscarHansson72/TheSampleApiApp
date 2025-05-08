using TheSampleApi.Data;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoints
{
    public static void AddCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCoursesAsync);
        app.MapGet("/courses/{id}", LoadCourseByIdAsync);
    }

    private static async Task<IResult> LoadAllCoursesAsync(CourseData data, string? courseType, string? search, int? delay)
    {
        var output = data.Courses;

        if (!string.IsNullOrWhiteSpace(courseType))
        {
            output.RemoveAll(c => string.Compare(
                c.CourseType, 
                courseType, 
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        if(!string.IsNullOrWhiteSpace(search))
        {
            output.RemoveAll(c => !c.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase) && 
                !c.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (delay is not null)
        {
            //Max delay is 5 minutes
            if(delay > 300000)
            {
                delay = 300000;
            }

            await Task.Delay((int)delay);
        }

        return Results.Ok(output);  
    }

    private static async Task<IResult> LoadCourseByIdAsync(CourseData data, int id, int? delay)
    {
        var output = data.Courses.SingleOrDefault(c => c.Id == id);

        if (delay is not null)
        {
            //Max delay is 5 minutes
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
