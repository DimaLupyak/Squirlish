using MediatR;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Learn.UseCases;

public class MarkWordAsLearnedCommand : IRequest
{
    public Word Word { get; }
    public Language FromLanguage { get; }
    public Language ToLanguage { get; }

    public MarkWordAsLearnedCommand(Word word, Language fromLanguage, Language toLanguage)
    {
        Word = word;
        FromLanguage = fromLanguage;
        ToLanguage = toLanguage;
    }
}