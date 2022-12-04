using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class UnlockCollectionCommandHandler : IRequestHandler<UnlockCollectionCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;
    private readonly IInventory _inventory;

    public UnlockCollectionCommandHandler(ICollectionsRepository collectionsRepository, IInventory inventory)
    {
        _collectionsRepository = collectionsRepository;
        _inventory = inventory;
    }

    public async Task<Unit> Handle(UnlockCollectionCommand request, CancellationToken cancellationToken)
    {
        _collectionsRepository.UnlockCollection(request.CollectionToUnlock.WordsCollectionId);
        _inventory.Withdraw(InventoryItemType.Acorn, request.CollectionToUnlock.Price);
        return Unit.Value;
    }
}