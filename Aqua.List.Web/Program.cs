var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();


app.UseStaticFiles();
app.UseDefaultFiles();

app.MapFallbackToController("Index", "Fallback");

app.Run();
