using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

public class GetCollectionsRequest : IRequest<ICollection<WordsCollection>>
{
}