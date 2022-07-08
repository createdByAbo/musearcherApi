using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using musearcherApi;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return $"/";
});

app.MapGet("/song", ([FromQuery] string lirycs) =>
{
    Console.WriteLine(lirycs);
    Welcome json = convert.getValueFromJson((musearcherApi.httpClient.Get($"https://api.genius.com/search?q={lirycs}").Result).ToString());

    return Model.Response.createJsonResponse(json);
});

app.Run();