using MediatR;
using Squirlish.Data;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class UnlockCollectionCommand : IRequest

{
    public WordsCollection CollectionToUnlock { get; }

    public UnlockCollectionCommand(WordsCollection collectionToUnlock)
    {
        CollectionToUnlock = collectionToUnlock;
    }
}

public class UnlockCollectionCommandHandler : IRequestHandler<UnlockCollectionCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public UnlockCollectionCommandHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<Unit> Handle(UnlockCollectionCommand request, CancellationToken cancellationToken)
    {
        _collectionsRepository.UnlockCollection(request.CollectionToUnlock.WordsCollectionId);
        return Unit.Value;
    }
}