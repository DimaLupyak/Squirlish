using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data;

public interface ICollectionsRepository
{
    Task<List<WordsCollection>> GetAllCollections();
    Task<Word> GetWordToLearn();
    void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage);
    void UnlockCollection(string id);
}