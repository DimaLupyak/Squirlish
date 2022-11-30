namespace Squirlish.Domain.Collections.Model;

public record WordTranslation
{
    public string WordTranslationId { get; init; } = Guid.NewGuid().ToString();
    public string WordId { get; set; }
    public Word Word { get; set; }
    public Language Language { get; set; }
    public string Meaning { get; set; }
}