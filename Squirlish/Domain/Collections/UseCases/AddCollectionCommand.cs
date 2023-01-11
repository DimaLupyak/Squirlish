using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class  AddCollectionCommand : IRequest
{
    public WordsCollection Collection { get; }

    public AddCollectionCommand(WordsCollection collection)
    {
        Collection = collection;
    }
}