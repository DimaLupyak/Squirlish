using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.Repositories;

public abstract class BaseCollectionsRepository : ICollectionsRepository
{
    public abstract Task<List<WordsCollection>> GetAllCollections();

    public Task<Word> GetWordToLearn()
    {
        var rnd = new Random();
        return Task.FromResult(GetAllCollections().Result
            .Where(wordsCollection => wordsCollection.IsOpened && wordsCollection.IsActive)
            .SelectMany(wordsCollection => wordsCollection.Words)
            .OrderBy(_ => rnd.Next())
            .FirstOrDefault(word => word.Translations
                .Any(wordTranslation => word.LearningProgress
                    .All(progressItem => progressItem.From != wordTranslation.Language))));
    }

    public abstract void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage);

    public abstract void UnlockCollection(string id);
    public abstract void Add(WordsCollection wordsCollection);
    public abstract void AddWord(Word requestWord);
}