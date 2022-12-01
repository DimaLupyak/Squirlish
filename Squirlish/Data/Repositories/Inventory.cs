using Squirlish.Domain.Collections.UseCases.Exceptions;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Data.Repositories;

public class Inventory : IInventory
{
    private readonly DatabaseContext _dbContext;

    public Inventory(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Withdraw(InventoryItemType type, int amount)
    {
        var item = _dbContext.Inventory.First(i => i.ItemType == type);
        if (item.Amount - amount < 0)
        {
            throw new AmountNotEnoughException(type, amount);
        }
        item.Amount -= amount;
        _dbContext.SaveChanges();
    }

    public void Recharge(InventoryItemType type, int amount)
    {
        var item = _dbContext.Inventory.First(i => i.ItemType == type);
        item.Amount += amount;
        _dbContext.SaveChanges();
    }

    public Task<int> GetAmount(InventoryItemType type)
    {
        return Task.FromResult(_dbContext.Inventory.First(i => i.ItemType == type).Amount);
    }
}