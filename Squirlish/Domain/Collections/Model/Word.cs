namespace Squirlish.Domain.Collections.Model;

public record Word
{
    public string WordId { get; set; } = Guid.NewGuid().ToString();
    public string WordsCollectionId { get; set; }
    public WordsCollection WordsCollection { get; set; }

    public List<WordTranslation> Translations { get; set; }
    public List<LearningProgressItem> LearningProgress { get; set; } = new();
}


public class LearningProgressItem
{
    public LearningProgressItem(Language from, Language to)
    {
        From = from;
        To = to;
        LearnedTime = DateTime.Now;
    }
    public string LearningProgressItemId { get; set; } = Guid.NewGuid().ToString();
    public string WordId { get; set; }
    public Word Word { get; set; }
    public Language From { get; set; }
    public Language To { get; set; }
    public DateTime LearnedTime { get; set; }
}