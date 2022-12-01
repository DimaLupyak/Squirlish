using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Learn.UseCases;

public class GetWordToLearnRequest : IRequest<Word>
{
}