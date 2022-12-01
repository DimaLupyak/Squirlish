using Microsoft.EntityFrameworkCore;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.Data.Repositories;

public class CollectionsRepository : BaseCollectionsRepository
{

    private readonly DatabaseContext _dbContext;

    public CollectionsRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override Task<List<WordsCollection>> GetAllCollections()
    {
        var a = _dbContext.Words.ToList();
        var b = _dbContext.WordTranslations.ToList();
        var c = _dbContext.LearningProgress.ToList();
        return _dbContext.WordsCollections.ToListAsync();
    }

    public override void MarkWordAsLearned(string id, Language requestFromLanguage, Language requestToLanguage)
    {
        _dbContext.WordsCollections.SelectMany(x => x.Words)
            .First(w => w.WordId == id).LearningProgress.Add(new LearningProgressItem(requestFromLanguage, requestToLanguage));
        _dbContext.SaveChanges();
    }

    public override void UnlockCollection(string id)
    {
        var collection = _dbContext.WordsCollections.First(x => x.WordsCollectionId == id);
        collection.IsOpened = true;
        _dbContext.SaveChanges();
    }
}