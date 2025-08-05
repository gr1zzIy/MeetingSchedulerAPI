namespace TestDotnet.Models;

/// <summary>
/// Представляє часовий проміжок з початковою та кінцевою датою/часом.
/// </summary>
/// <summary>
/// Represents a time interval with start and end date/time.
/// </summary>
public class TimeSlot
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}