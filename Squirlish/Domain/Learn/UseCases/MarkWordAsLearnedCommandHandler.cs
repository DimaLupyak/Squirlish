using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Inventory.Model;

namespace Squirlish.Domain.Learn.UseCases;

public class MarkWordAsLearnedCommandHandler : IRequestHandler<MarkWordAsLearnedCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;
    private readonly IInventory _inventory;

    public MarkWordAsLearnedCommandHandler(
        ICollectionsRepository collectionsRepository,
        IInventory inventory)
    {
        _collectionsRepository = collectionsRepository;
        _inventory = inventory;
    }

    public async Task<Unit> Handle(MarkWordAsLearnedCommand request, CancellationToken cancellationToken)
    {
        _collectionsRepository.MarkWordAsLearned(request.Word.WordId, request.FromLanguage, request.ToLanguage);
        _inventory.Recharge(InventoryItemType.Acorn, 10);
        return Unit.Value;
    }
}