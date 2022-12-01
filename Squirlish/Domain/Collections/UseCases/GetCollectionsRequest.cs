using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class GetCollectionsRequest : IRequest<ICollection<WordsCollection>>
{
}