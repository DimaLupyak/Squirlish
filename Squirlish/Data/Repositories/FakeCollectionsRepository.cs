using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.Repositories;

public partial class FakeCollectionsRepository : BaseCollectionsRepository
{
    public override Task<List<WordsCollection>> GetAllCollections()
    {
        return Task.FromResult(WordsCollections);
    }

    public override void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage)
    {
        WordsCollections.SelectMany(x => x.Words)
            .First(w => w.WordId == id).LearningProgress.Add(new LearningProgressItem(requestFromLanguage, requestToLanguage));
    }

    public override void UnlockCollection(string id)
    {
        var collection = WordsCollections.First(x => x.WordsCollectionId == id);
        collection.IsOpened = true;
    }

    public override void Add(WordsCollection wordsCollection)
    {
        WordsCollections.Add(wordsCollection);
    }

    public override void AddWord(Word word)
    {
        WordsCollections.First(c => c.WordsCollectionId == word.WordsCollectionId).Words.Add(word);
    }
}