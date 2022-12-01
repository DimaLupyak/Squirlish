using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Domain.Collections.UseCases.Exceptions;

public class AmountNotEnoughException : Exception
{
    private readonly InventoryItemType _type;
    private readonly int _amount;

    public AmountNotEnoughException(InventoryItemType type, int amount)
    {
        _type = type;
        _amount = amount;
    }

    public override string ToString()
    {
        return $"{_type} amount is not enough to withdraw {_amount}";
    }
}