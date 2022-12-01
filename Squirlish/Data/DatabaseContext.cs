using Microsoft.EntityFrameworkCore;
using Squirlish.Data.EntityConfigurations;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<WordsCollection> WordsCollections { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordTranslation> WordTranslations { get; set; }
        public DbSet<LearningProgressItem> LearningProgress { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }

        private readonly IPath _path;

        public DatabaseContext(IPath path, DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            _path = path;
            //_path.DeleteFile(_path.GetDatabasePath());
            Database.EnsureCreated();

            var collection = WordsCollections.FirstOrDefault();
            if (collection == null)
            {
                WordsCollections.AddRange(Repositories.FakeCollectionsRepository.WordsCollections);
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={_path.GetDatabasePath()}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new WordsCollectionConfiguration());
            builder.ApplyConfiguration(new WordConfiguration());
            builder.ApplyConfiguration(new TranslationConfiguration());
            builder.ApplyConfiguration(new LearningProgressConfiguration());
            builder.ApplyConfiguration(new InventoryConfiguration());
        }
    }
}
