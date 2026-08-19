namespace EventEase.Models;

public sealed class Event
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public string Location { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string AccentClass { get; init; } = string.Empty;

    public bool IsValid => Id > 0
        && !string.IsNullOrWhiteSpace(Name)
        && Date != default
        && !string.IsNullOrWhiteSpace(Location)
        && !string.IsNullOrWhiteSpace(Description)
        && !string.IsNullOrWhiteSpace(Category);
}
