namespace Todoer.Api.Domain;

/// <summary>
/// TODO is a representation of a "To-Do" note within the system.
/// </summary>
public record Todo
{
    /// <summary>
    /// TODO is a representation of a "To-Do" note within the system.
    /// </summary>
    /// <param name="title">the non-empty or null title of this note</param>
    public Todo(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException(nameof(title), "the title cannot be null or blank");
        }
        Title = title;
    }

    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.Now;
    public string Content { get; init; } = string.Empty;

    /// <summary>the non-empty or null title of this note</summary>
    public string Title { get; init; }

    public void Deconstruct(out string Title)
    {
        Title = this.Title;
    }
}