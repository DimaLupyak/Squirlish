using MediatR;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Domain.Inventory.UseCases;

public class GetInventoryItemAmountRequest : IRequest<int>
{
    public InventoryItemType Type { get; }

    public GetInventoryItemAmountRequest(InventoryItemType type)
    {
        Type = type;
    }
}