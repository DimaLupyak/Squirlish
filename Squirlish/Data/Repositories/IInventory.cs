using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Data.Repositories;

public interface IInventory
{
    void Withdraw(InventoryItemType type, int amount);
    void Recharge(InventoryItemType type, int amount);

    Task<int> GetAmount(InventoryItemType requestType);
}