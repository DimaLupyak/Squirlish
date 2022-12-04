using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Statistic.Model;

namespace Squirlish.Domain.Statistic.UseCases;

public class GetCollectionsRequestHandler : IRequestHandler<GetStatisticRequest, ICollection<StatisticItem>>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public GetCollectionsRequestHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<ICollection<StatisticItem>> Handle(
        GetStatisticRequest request,
        CancellationToken cancellationToken = default)
    {

        var collections = await _collectionsRepository.GetAllCollections();

        return new List<StatisticItem>() { new StatisticItem { Name = "Слів вивчено", Value = "2" } };
    }
}