using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class AddCollectionCommandHandler : IRequestHandler<AddCollectionCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public AddCollectionCommandHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<Unit> Handle(
        AddCollectionCommand request,
        CancellationToken cancellationToken = default)
    {
        _collectionsRepository.Add(request.Collection);
        return Unit.Value;
    }
}