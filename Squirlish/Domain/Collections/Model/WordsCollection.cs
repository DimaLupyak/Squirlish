namespace Squirlish.Domain.Collections.Model;

public class WordsCollection
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public ICollection<Word> Words { get; set; }
    public bool IsOpened { get; set; }
    public bool IsActive { get; set; } = true;
}