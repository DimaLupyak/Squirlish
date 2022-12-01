using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.EntityConfigurations;

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