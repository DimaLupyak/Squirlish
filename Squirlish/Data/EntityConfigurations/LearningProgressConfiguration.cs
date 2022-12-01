using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.EntityConfigurations;

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