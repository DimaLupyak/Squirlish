namespace Squirlish.Domain.Collections.Model;

public record Word
{
    public string WordId { get; set; } = Guid.NewGuid().ToString();
    public string WordsCollectionId { get; set; }
    public WordsCollection WordsCollection { get; set; }

    public List<WordTranslation> Translations { get; set; }
    public List<LearningProgressItem> LearningProgress { get; set; } = new();

    public string String => ToString();
    public override string ToString()
    {
        return string.Join("-", Translations.GroupBy(t => t.Language)
            .Select(g => string.Join(',', g.Select(x=> x.Meaning))));
    }
}