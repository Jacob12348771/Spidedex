using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
*/

var databasePath = Path.Join("spidedex.db");
var connectionString = new SqliteConnection($"Data Source={databasePath}");
builder.Services.AddDbContext<SpidedexDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var dbContext = scope.ServiceProvider.GetService<SpidedexDbContext>())
{
    dbContext?.Database.Migrate();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
//app.UseCors("AllowAll");  

// Get all spiders
app.MapGet("/spiders", async (SpidedexDbContext dbContext) =>
{
    try
    {
        var spiders = await dbContext.Spiders.ToListAsync();
        return Results.Ok(spiders);
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

// Get spider by id
app.MapGet("/spiders/{id}", async (SpidedexDbContext dbContext, int id) =>
{
    try
    {
        var spider = await dbContext.Spiders.FindAsync(id);
        return spider is null ? Results.NotFound() : Results.Ok(spider);
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

// Get spiders by user
app.MapGet("/spiders/foruser/{userdata}", async (SpidedexDbContext dbContext, string userdata) =>
{
    try
    {
        var spider = await dbContext.Spiders.Where(s => s.UserInfo == userdata).ToListAsync();
        return spider is null ? Results.NotFound() : Results.Ok(spider);
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

// Update spider
app.MapPut("/spiders/{id}", async (SpidedexDbContext dbContext, int id, Spider spider) =>
{
    try
    {
        if (id != spider.Id)
        {
            return Results.BadRequest();
        }

        dbContext.Entry(spider).State = EntityState.Modified;

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!dbContext.Spiders.Any(s => s.Id == id))
            {
                return Results.NotFound();
            }
            else
            {
                throw;
            }
        }

        return Results.NoContent();
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

// Create spider
app.MapPost("/spiders", async (SpidedexDbContext dbContext, Spider spider) =>
{
    try
    {
        dbContext.Spiders.Add(spider);
        await dbContext.SaveChangesAsync();

        return Results.Created($"/spiders/{spider.Id}", spider);
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

// Delete spider
app.MapDelete("/spiders/{id}", async (SpidedexDbContext dbContext, int id) =>
{
    try
    {
        var spider = await dbContext.Spiders.FindAsync(id);
        if (spider is null)
        {
            return Results.NotFound();
        }

        dbContext.Spiders.Remove(spider);
        await dbContext.SaveChangesAsync();

        return Results.NoContent();
    }
    catch (Exception)
    {
        return Results.BadRequest();
    }
});

app.Run();