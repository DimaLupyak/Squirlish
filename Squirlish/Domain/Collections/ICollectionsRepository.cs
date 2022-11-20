using Squirlish.Domain.Collections.Model;

namespace Squirlish.Domain.Collections;

public interface ICollectionsRepository
{
    Task<ICollection<WordsCollection>> GetAllCollections();
}