namespace TestDotnet.Models;

/// <summary>
/// Модель зустрічі, що містить інформацію про учасників та часові рамки.
/// </summary>
/// <summary>
/// Meeting model containing information about participants and time frame.
/// </summary>
public class Meeting
{
    public int Id { get; set; }
    public List<int> ParticipantIds { get; set; } = new();
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}