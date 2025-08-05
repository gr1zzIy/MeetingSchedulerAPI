namespace TestDotnet.Models;

/// <summary>
/// Запит на створення зустрічі. Містить параметри для пошуку доступного часу.
/// </summary>
/// <summary>
/// Meeting creation request. Contains parameters for finding available time.
/// </summary>
public class MeetingRequest
{
    public List<int> ParticipantIds { get; set; } = new();
    public int DurationMinutes { get; set; }
    public DateTime EarliestStart { get; set; }
    public DateTime LatestEnd { get; set; }
}