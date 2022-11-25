using Squirlish.Domain.Collections.Model;

namespace Squirlish.ViewModels;

public class WordToLearnViewModel
{
    public Word Word { get; }

    public WordToLearnViewModel(Word word)
    {
        if (word == null)
        {
            return;
        }

        Word = word;
        WordExists = true;
        var from = word.Translations.
            First(x => word.LearningProgress
                .All(learned => x.Language != learned.From));
        var to = word.Translations.
            Where(x => x.Language != from.Language && 
                       word.LearningProgress.All(learned => x.Language != learned.To));
        to = to.GroupBy(x => x.Language).First();
        Original = from.Meaning;
        Translations = to.Select(x => x.Meaning).ToList();
        FromLanguage = from.Language;
        ToLanguage = to.First().Language;
    }

    public bool WordExists { get; }
    public string Original { get;}
    public ICollection<string> Translations { get; }
    public Language FromLanguage { get; }
    public Language ToLanguage { get; }
}