namespace Squirlish.Domain.Collections.Model;

public record Word
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public ICollection<WordTranslation> Translations { get; set; }
    public LearningProgress LearningProgress { get; set; } = new();
}

public class LearningProgress : List<LearningProgressItem>
{
}   

public class LearningProgressItem
{
    public LearningProgressItem(Language from, Language to)
    {
        From = from;
        To = to;
        LearnedTime = DateTime.Now;
    }

    public Language From { get; set; }
    public Language To { get; set; }
    public DateTime LearnedTime { get; set; }
}