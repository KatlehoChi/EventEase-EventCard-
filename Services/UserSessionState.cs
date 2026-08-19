namespace EventEase.Services;

public sealed class UserSessionState
{
    private readonly HashSet<int> registeredEventIds = [];
    private readonly HashSet<int> attendingEventIds = [];

    public string? UserName { get; private set; }
    public string? Email { get; private set; }
    public IReadOnlySet<int> RegisteredEventIds => registeredEventIds;
    public IReadOnlySet<int> AttendingEventIds => attendingEventIds;
    public bool HasUser => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Email);

    public void SetUser(string name, string email)
    {
        UserName = name.Trim();
        Email = email.Trim();
    }

    public bool IsRegistered(int eventId) => registeredEventIds.Contains(eventId);

    public bool IsAttending(int eventId) => attendingEventIds.Contains(eventId);

    public void RegisterFor(int eventId)
    {
        if (eventId > 0)
        {
            registeredEventIds.Add(eventId);
            attendingEventIds.Add(eventId);
        }
    }

    public bool ToggleAttendance(int eventId)
    {
        if (!IsRegistered(eventId))
        {
            return false;
        }

        if (!attendingEventIds.Add(eventId))
        {
            attendingEventIds.Remove(eventId);
        }

        return IsAttending(eventId);
    }
}
