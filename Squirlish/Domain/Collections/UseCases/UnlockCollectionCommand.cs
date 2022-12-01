using MediatR;
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