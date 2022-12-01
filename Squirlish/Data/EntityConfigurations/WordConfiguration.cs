using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.EntityConfigurations;

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