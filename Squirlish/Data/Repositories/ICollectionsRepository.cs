using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.Repositories;

public interface ICollectionsRepository
{
    Task<List<WordsCollection>> GetAllCollections();
    Task<Word> GetWordToLearn();
    void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage);
    void UnlockCollection(string id);
    void Add(WordsCollection wordsCollection);
    void AddWord(Word requestWord);
}