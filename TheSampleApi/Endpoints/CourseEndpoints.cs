using TheSampleApi.Data;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoints
{
    public static void AddCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCourses);
        app.MapGet("/courses/{id}", LoadCourseById);
    }

    private static IResult LoadAllCourses(CourseData data, string? courseType, string? search)
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

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData data, int id)
    {
        var output = data.Courses.SingleOrDefault(c => c.Id == id);

        if(output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
