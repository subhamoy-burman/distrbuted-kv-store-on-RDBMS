using Bogus;
using KeyValuePair.API.Model;
using Microsoft.EntityFrameworkCore;

namespace KeyValuePair.API
{
    public class KeyValuePairsContext : DbContext
    {
        public KeyValuePairsContext(DbContextOptions<KeyValuePairsContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var faker = new Faker<KeyValuePairs>()
                .RuleFor(o => o.Key, f => f.Random.AlphaNumeric(10))
                .RuleFor(o => o.Value, f => f.Random.Bytes(20))
                .RuleFor(o => o.isDeleted, f => f.Random.Bool())
                .RuleFor(o => o.TTL, f => f.Date.Recent());

            var data = faker.Generate(10000);

            modelBuilder.Entity<KeyValuePairs>().HasData(data);
        }
        public DbSet<KeyValuePairs> MyTables { get; set; }

    }
}
