using Bogus;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Perfume> Perfumes { get; set; }

        public DataContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfume>(m =>
            {
                m.HasKey(e => e.Id);

            });

            var fakePerfumes = new List<Perfume>();
            for (var i = 0; i < 20; i++)
            {
                var fakePerfume = new Faker<Perfume>()
                    .RuleFor(x => x.Id, i + 1)
                    .RuleFor(x => x.Name, f => f.Name.FirstName())
                    .RuleFor(x => x.Brand, f => f.Company.CompanyName())
                    .RuleFor(x => x.Volume, f => 110f)
                    .RuleFor(x => x.ImageUrl, f => f.Image.LoremFlickrUrl())
                    .RuleFor(x => x.Scent, f => f.Vehicle.Fuel());
                fakePerfumes.Add(fakePerfume);
            }

            modelBuilder.Entity<Perfume>().HasData(fakePerfumes);
        }
    }
}