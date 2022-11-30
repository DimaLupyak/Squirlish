using MediatR;
using Squirlish.Data;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

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