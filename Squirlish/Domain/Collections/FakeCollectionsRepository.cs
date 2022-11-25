using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

public partial class FakeCollectionsRepository : ICollectionsRepository
{
    public Task<ICollection<WordsCollection>> GetAllCollections()
    {
        return Task.FromResult(WordsCollections);
    }

    public Task<Word> GetWordToLearn()
    {
        var rnd = new Random();
        return Task.FromResult(WordsCollections
                .Where(wordsCollection => wordsCollection.IsOpened && wordsCollection.IsActive)
                .SelectMany(wordsCollection => wordsCollection.Words)
                .OrderBy(_ => rnd.Next())
                .FirstOrDefault(word => word.Translations
                    .Any(wordTranslation => word.LearningProgress
                        .All(progressItem => progressItem.From != wordTranslation.Language))));
    }

    public void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage)
    {
        WordsCollections.SelectMany(x => x.Words)
            .First(w => w.Id == id).LearningProgress.Add(new LearningProgressItem(requestFromLanguage, requestToLanguage));
    }

    public void UnlockCollection(string id)
    {
        var collection = WordsCollections.First(x => x.Id == id);
        collection.IsOpened = true;
    }
}