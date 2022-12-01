using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class GetCollectionsRequestHandler : IRequestHandler<GetCollectionsRequest, ICollection<WordsCollection>>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public GetCollectionsRequestHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<ICollection<WordsCollection>> Handle(
        GetCollectionsRequest request,
        CancellationToken cancellationToken = default)
    {

        return await _collectionsRepository.GetAllCollections();
    }
}