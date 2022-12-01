using MediatR;
using Squirlish.Data.Repositories;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Learn.UseCases;

public class GetWordToLearnRequestHandler : IRequestHandler<GetWordToLearnRequest, Word>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public GetWordToLearnRequestHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<Word> Handle(
        GetWordToLearnRequest request,
        CancellationToken cancellationToken = default)
    {

        return await _collectionsRepository.GetWordToLearn();
    }
}