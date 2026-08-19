namespace EventEase.Models;

public static class EventCatalog
{
    public static ICollection<Event> All { get; } =
    [
        new Event
        {
            Id = 1,
            Name = "Future of Work Summit",
            Date = new DateTime(2026, 9, 18),
            Location = "Austin Convention Center",
            Category = "Conference",
            AccentClass = "blue",
            Description = "A sharp, practical day for leaders shaping thoughtful workplaces, stronger teams, and what comes next."
        },
        new Event
        {
            Id = 2,
            Name = "After Hours: The Makers Table",
            Date = new DateTime(2026, 10, 2),
            Location = "The Foundry, Brooklyn",
            Category = "Social",
            AccentClass = "lime",
            Description = "An intimate evening of good food, curious conversations, and hands-on creative sessions with local makers."
        },
        new Event
        {
            Id = 3,
            Name = "Designing For Momentum",
            Date = new DateTime(2026, 10, 24),
            Location = "The Assembly, Chicago",
            Category = "Workshop",
            AccentClass = "sky",
            Description = "A focused workshop for product teams ready to turn useful ideas into work people can feel."
        }
    ];

    public static Event? Find(int id)
    {
        if (id <= 0)
        {
            return null;
        }

        foreach (var eventItem in All)
        {
            if (eventItem.Id == id && eventItem.IsValid)
            {
                return eventItem;
            }
        }

        return null;
    }
}
