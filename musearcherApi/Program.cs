var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

app.MapGet("/song", () =>
{
    return musearcherApi.convert.getValueFromJson((musearcherApi.httpClient.Get("https://api.genius.com/search?q=pliki%20pliki").Result).ToString());
});

app.Run();