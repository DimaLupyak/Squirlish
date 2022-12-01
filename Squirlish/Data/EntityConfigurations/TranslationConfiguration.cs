using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.EntityConfigurations;

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