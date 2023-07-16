using Microsoft.EntityFrameworkCore;
public class SpidedexDbContext : DbContext
{
    public SpidedexDbContext(DbContextOptions<SpidedexDbContext> options) : base(options)
    {

    }

    public DbSet<Spider> Spiders { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Spider>().HasData(
            new Spider
            {
                Id = 1,
                DateObtained = new DateTime(2021, 10, 1),
                Name = "Charlotte",
                Species = "Argiope aurantia",
                Description = "A cool spooder",
                Size = "3 inches",
                Diet = "Crickets",
                UserInfo = "test123@gmail.com",
                Temperament = Spider.Tempereament.Calm
            },
            new Spider
            {
                Id = 2,
                DateObtained = new DateTime(2023, 09, 13),
                Name = "Luna",
                Species = "Tliltocatl vagans",
                Description = "My spooder",
                Size = "4 inches",
                Diet = "Locusts",
                UserInfo = "test123@gmail.com",
                Temperament = Spider.Tempereament.Docile
            },
            new Spider
            {
                Id = 3,
                DateObtained = new DateTime(2022, 05, 23),
                Name = "Pokey",
                Species = "Poecilotheria regalis",
                Description = "Ouch it hurts",
                Size = "5 inches",
                Diet = "Crickets",
                UserInfo = "test123@gmail.com",
                Temperament = Spider.Tempereament.Aggressive
            }
        );
    }
}