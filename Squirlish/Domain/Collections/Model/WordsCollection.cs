namespace Squirlish.Domain.Collections.Model;

public class WordsCollection
{
    public string Name { get; set; }
    public ICollection<Word> Words { get; set; }
}