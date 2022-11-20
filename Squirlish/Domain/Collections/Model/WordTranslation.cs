namespace Squirlish.Domain.Collections.Model;

public record WordTranslation
{
    public Language Language { get; set; }
    public string Meaning { get; set; }
}