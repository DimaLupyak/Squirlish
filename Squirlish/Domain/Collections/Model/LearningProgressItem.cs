namespace Squirlish.Domain.Collections.Model;

public record LearningProgressItem(Language From, Language To)
{
    public string LearningProgressItemId { get; set; } = Guid.NewGuid().ToString();
    public string WordId { get; set; }
    public Word Word { get; set; }
    public Language From { get; set; } = From;
    public Language To { get; set; } = To;
    public DateTime LearnedTime { get; set; } = DateTime.Now;
}