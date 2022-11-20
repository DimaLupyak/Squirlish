namespace Squirlish.Domain.Collections.Model;

public record Word
{
    public ICollection<WordTranslation> Translations { get; set; }
}