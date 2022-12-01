namespace Squirlish.Domain.Collections.Model;

public record Word
{
    public string WordId { get; set; } = Guid.NewGuid().ToString();
    public string WordsCollectionId { get; set; }
    public WordsCollection WordsCollection { get; set; }

    public List<WordTranslation> Translations { get; set; }
    public List<LearningProgressItem> LearningProgress { get; set; } = new();
}