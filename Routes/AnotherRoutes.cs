using System.Text.Json;

namespace MinimalProject.Routes
{
    public static class AnotherRoutes
    {
        public static void Another(WebApplication app)
        {
            app.MapGet("/Ping", () => "pong");

            app.MapPost("/CustomJSON", (dynamic json) =>
            {
                Dictionary<string, string> dict
                = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                string value1 = dict["value1"];
                //string value2 = dict["value2"];

                return Results.Ok($"Value1: {value1}");
            });
        }
    }
}
