using Scalar.AspNetCore;
using TheSampleApi.Endpoints;
using TheSampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.AddRootEndpoints();
app.AddCourseEndpoints();

app.Run();