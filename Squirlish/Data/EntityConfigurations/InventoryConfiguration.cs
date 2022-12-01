using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Data.EntityConfigurations;

public class InventoryConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    private readonly InventoryItem[] _initialInventory =
    {
        new() { ItemType = InventoryItemType.Acorn, Amount = 100 }
    };

    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasKey(i => i.ItemType);

        builder.HasData(_initialInventory);
    }
}