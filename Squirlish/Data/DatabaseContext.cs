using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Collections;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<WordsCollection> WordsCollections { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordTranslation> WordTranslations { get; set; }
        public DbSet<LearningProgressItem> LearningProgress { get; set; }

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
                WordsCollections.AddRange(FakeCollectionsRepository.WordsCollections);
                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var a = _path.GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={_path.GetDatabasePath()}");
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new WordsCollectionConfiguration());
            builder.ApplyConfiguration(new WordConfiguration());
            builder.ApplyConfiguration(new TranslationConfiguration());
            builder.ApplyConfiguration(new LearningProgressConfiguration());
        }
    }

    public class WordsCollectionConfiguration : IEntityTypeConfiguration<WordsCollection>
    {
        public void Configure(EntityTypeBuilder<WordsCollection> builder)
        {
            builder.HasKey(e => e.WordsCollectionId);

            builder.HasMany(c => c.Words)
                .WithOne(w => w.WordsCollection)
                .HasForeignKey(s => s.WordsCollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(e => e.WordId);

            builder.HasMany(c => c.Translations)
                .WithOne(w => w.Word)
                .HasForeignKey(s => s.WordId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.LearningProgress)
                .WithOne(w => w.Word)
                .HasForeignKey(s => s.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TranslationConfiguration : IEntityTypeConfiguration<WordTranslation>
    {
        public void Configure(EntityTypeBuilder<WordTranslation> builder)
        {
            builder.HasKey(e => e.WordTranslationId);

            builder.HasOne(c => c.Word)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.WordId);
        }
    }

    public class LearningProgressConfiguration : IEntityTypeConfiguration<LearningProgressItem>
    {
        public void Configure(EntityTypeBuilder<LearningProgressItem> builder)
        {
            builder.HasKey(e => e.LearningProgressItemId);

            builder.HasOne(c => c.Word)
                .WithMany(x => x.LearningProgress)
                .HasForeignKey(x => x.WordId);
        }
    }

}
