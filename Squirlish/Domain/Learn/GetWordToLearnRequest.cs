using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Learn;

public class GetWordToLearnRequest : IRequest<Word>
{
}