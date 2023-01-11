using Java.Util;
using Microsoft.EntityFrameworkCore;
using Squirlish.Data.EntityConfigurations;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Inventory.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            //SQLitePCL.Batteries_V2.Init();  //for iOS
            //_path.DeleteFile(_path.GetDatabasePath());
            Database.EnsureCreated();

            var collection = WordsCollections.FirstOrDefault();
            if (collection == null)
            {
                WordsCollections.AddRange(Repositories.FakeCollectionsRepository.WordsCollections);
            }
            WordsCollections.AddRange(ReadCollectionsFromAsset().Result
                .Where(x => WordsCollections.All(y => y.Name!= x.Name)));
            SaveChanges();
        }

        private async Task<List<WordsCollection>> ReadCollectionsFromAsset()
        {
            var collections = new List<WordsCollection>();
            var collectionFiles = await LoadMauiAsset("CollectionsList.txt");
            foreach (var file in collectionFiles.Replace("\r\n", "\n").Split("\n"))       
            {
                var fileData = await LoadMauiAsset($"Collections/{file}.yaml");
                var deserializer = new DeserializerBuilder().Build();
                collections.Add(deserializer.Deserialize<WordsCollection>(fileData)); 
            }

            return collections;
        }

        async Task<string> LoadMauiAsset(string path)
        {
            await using var stream = await FileSystem.OpenAppPackageFileAsync(path);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var dbPath = Path.Combine(_path.GetDatabasePath());
            optionsBuilder.UseSqlite($"Filename={dbPath}");
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
