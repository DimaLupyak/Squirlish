using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

public interface ICollectionsRepository
{
    Task<ICollection<WordsCollection>> GetAllCollections();
    Task<Word> GetWordToLearn();
    void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage);
    void UnlockCollection(string id);
}