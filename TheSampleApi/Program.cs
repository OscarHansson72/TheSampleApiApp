using Scalar.AspNetCore;
using TheSampleApi.Endpoints;
using TheSampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();

app.MapAllHealthChecks();

app.AddRootEndpoints();
app.AddErrorEndpoints();
app.AddCourseEndpoints();
app.AddMovieEndpoints();

app.Run();