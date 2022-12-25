namespace Todoer.Api.Domain;

/// <summary>
/// TODO is a representation of a "To-Do" note within the system.
/// </summary>
/// <param name="Title">the non-empty or null title of this note</param>
public record Todo(string Title)
{
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.Now;
    public string Content { get; init; } = string.Empty;
}