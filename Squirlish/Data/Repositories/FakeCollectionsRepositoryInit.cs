using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.Repositories;

public partial class FakeCollectionsRepository
{
    public static List<WordsCollection> WordsCollections { get; }

    static FakeCollectionsRepository()
    {
        WordsCollections = new List<WordsCollection>
        {
            new()
            {
                Name = "Базові відповіді",
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
                Name = "Сім'я",
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

        foreach (var wordsCollection in WordsCollections)
        {
            foreach (var word in wordsCollection.Words)
            {
                word.WordsCollectionId = wordsCollection.WordsCollectionId;
                foreach (var wordTranslation in word.Translations)
                {
                    wordTranslation.WordId = word.WordId;
                }
            }
        }
    }
}