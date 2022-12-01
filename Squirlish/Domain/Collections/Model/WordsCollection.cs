namespace Squirlish.Domain.Collections.Model;

public record WordsCollection
{
    public string WordsCollectionId { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public List<Word> Words { get; set; }
    public int Price { get; set; } = 100;
    public bool IsOpened { get; set; }
    public bool IsActive { get; set; } = true;
}