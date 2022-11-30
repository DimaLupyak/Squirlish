using MediatR;
using Squirlish.Data;

namespace Squirlish.Domain.Learn;

public class MarkWordAsLearnedCommandHandler : IRequestHandler<MarkWordAsLearnedCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public MarkWordAsLearnedCommandHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<Unit> Handle(MarkWordAsLearnedCommand request, CancellationToken cancellationToken)
    {
        _collectionsRepository.MarkWordAsLearned(request.Word.WordId, request.FromLanguage, request.ToLanguage);
        return Unit.Value;
    }
}