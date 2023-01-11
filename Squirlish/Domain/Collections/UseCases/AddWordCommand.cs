using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections.UseCases;

public class AddWordCommand : IRequest
{
    public Word Word { get; }

    public AddWordCommand(Word word)
    {
        Word = word;
    }
}