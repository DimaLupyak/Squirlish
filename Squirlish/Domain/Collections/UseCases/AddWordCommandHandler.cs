using MediatR;
using Squirlish.Data.Repositories;

namespace Squirlish.Domain.Collections.UseCases;

public class AddWordCommandHandler : IRequestHandler<AddWordCommand, Unit>
{
    private readonly ICollectionsRepository _collectionsRepository;

    public AddWordCommandHandler(
        ICollectionsRepository collectionsRepository)
    {
        _collectionsRepository = collectionsRepository;
    }

    public async Task<Unit> Handle(
        AddWordCommand request,
        CancellationToken cancellationToken = default)
    {
        _collectionsRepository.AddWord(request.Word);
        return Unit.Value;
    }
}