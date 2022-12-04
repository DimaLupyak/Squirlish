using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Collections.Model;
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

        return new List<StatisticItem>
        {
            new() { Name = "Слів відкрито", Value = $"{GetCountOfOpenedWords(collections)}" },
            new() { Name = "Слів вивчено", Value = $"{GetCountOfLearnedWords(collections)}" },
            new() { Name = "Слів частково вивчено", Value = $"{GetCountOfPartiallyLearnedWords(collections)}" }
        };
    }

    private static int GetCountOfOpenedWords(ICollection<WordsCollection> collections)
    {
        return collections.SelectMany(x => x.Words).Count();
    }

    private static int GetCountOfLearnedWords(ICollection<WordsCollection> collections)
    {
        return collections.SelectMany(x => x.Words)
            .Count(w => w.Translations.Select(x => x.Language).Distinct().Count() == w.LearningProgress.Count);
    }
    private static int GetCountOfPartiallyLearnedWords(ICollection<WordsCollection> collections)
    {
        return collections.SelectMany(x => x.Words)
            .Count(w => w.LearningProgress.Any());
    }
}