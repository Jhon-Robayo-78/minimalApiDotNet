/* //forma tradicional para minimal api
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();*/

using MinimalProject.Models;
using MinimalProject.Routes;

WebApplication app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.MapGet("/GetName", () => app.Configuration["Data:Name"]);

app.MapGet("/SayHi/{name}", (string name) => $"Hello, {name}!");

app.MapPost("AddProgrammer",
    (Programmer programdor) =>
    {
        programdor.Id = Guid.NewGuid().ToString();
        
        app.Logger.LogInformation($"{programdor.Id}:{programdor.Name}");

        return Results.StatusCode(200);
    });

AnotherRoutes.Another(app);

app.Run(app.Configuration["Data:Url"]);
