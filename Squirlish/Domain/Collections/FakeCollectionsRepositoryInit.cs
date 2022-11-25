using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

public partial class FakeCollectionsRepository
{
    private ICollection<WordsCollection> WordsCollections { get; set; } = new List<WordsCollection>
    {
        new()
        {
            Name = "Basic",
            IsOpened = true,
            Words = new List<Word>
            {
                new()
                {
                    Translations = new List<WordTranslation>
                    {
                        new() { Language = Language.Ukrainian, Meaning = "так" },
                        new() { Language = Language.English, Meaning = "yes" }
                    }
                },
                new()
                {
                    Translations = new List<WordTranslation>
                    {
                        new() { Language = Language.Ukrainian, Meaning = "ні" },
                        new() { Language = Language.English, Meaning = "no" }
                    }
                },
                new()
                {
                    Translations = new List<WordTranslation>
                    {
                        new() { Language = Language.Ukrainian, Meaning = "можливо" },
                        new() { Language = Language.English, Meaning = "maybe" }
                    }
                }
            }
        },
        new()
        {
            Name = "Family",
            IsOpened = false,
            Words = new List<Word>
            {
                new()
                {
                    Translations = new List<WordTranslation>
                    {
                        new() { Language = Language.Ukrainian, Meaning = "мати" },
                        new() { Language = Language.Ukrainian, Meaning = "матір" },
                        new() { Language = Language.Ukrainian, Meaning = "мама" },
                        new() { Language = Language.English, Meaning = "mather" },
                        new() { Language = Language.English, Meaning = "mom" }
                    }
                },
                new()
                {
                    Translations = new List<WordTranslation>
                    {
                        new() { Language = Language.Ukrainian, Meaning = "тато" },
                        new() { Language = Language.Ukrainian, Meaning = "татусь" },
                        new() { Language = Language.English, Meaning = "father" },
                        new() { Language = Language.English, Meaning = "dad" }
                    }
                }
            }
        }
    };
}