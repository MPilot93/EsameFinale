using Cinema.Api.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSingleton(_ => new CinemaSQL(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddSingleton(_ => new FilmSQL(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddSingleton(_ => new RoomSQL(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddSingleton(_ => new TicketSQL(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddSingleton(_ => new SpectatorSQL(builder.Configuration.GetConnectionString("Db")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
