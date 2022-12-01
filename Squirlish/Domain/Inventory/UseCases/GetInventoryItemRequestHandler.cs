using MediatR;
using Squirlish.Data.Repositories;

namespace Squirlish.Domain.Inventory.UseCases;

public class GetInventoryItemAmountRequestHandler : IRequestHandler<GetInventoryItemAmountRequest, int>
{
    private readonly IInventory _inventory;

    public GetInventoryItemAmountRequestHandler(
        IInventory inventory)
    {
        _inventory = inventory;
    }

    public async Task<int> Handle(
        GetInventoryItemAmountRequest request,
        CancellationToken cancellationToken = default)
    {
        return await _inventory.GetAmount(request.Type);
    }
}