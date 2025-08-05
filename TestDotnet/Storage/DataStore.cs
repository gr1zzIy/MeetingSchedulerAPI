using TestDotnet.Models;
using TestDotnet.Services;

namespace TestDotnet.Storage;

/// <summary>
/// Клас DataStore представляє сховище даних для додатка.
/// Містить списки користувачів та зустрічей, а також лічильники для генерації унікальних ідентифікаторів.
/// </summary>
/// <summary>
/// The DataStore class represents a data storage for the application.
/// Contains lists of users and meetings, as well as counters for generating unique identifiers.
/// </summary>
public class DataStore
{
    public int NextUserId { get; set; } = 1;
    public int NextMeetingId { get; set; } = 1;
    public List<User> Users { get; set; } = new();
    public List<Meeting> Meetings { get; set; } = new();
}