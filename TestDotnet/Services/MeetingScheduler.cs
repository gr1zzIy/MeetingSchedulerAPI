using TestDotnet.Models;
using TestDotnet.Storage;

namespace TestDotnet.Services;

/// <summary>
/// Сервіс для планування зустрічей між користувачами.
/// Надає функціонал пошуку доступного часового проміжку для зустрічі з урахуванням зайнятості учасників.
/// </summary>
/// <summary>
/// Service for scheduling meetings between users.
/// Provides functionality to find an available time slot for a meeting considering participants' availability.
/// </summary>
public class MeetingScheduler
{
    private readonly DataStore _store;
    public MeetingScheduler(DataStore store) => _store = store;

    public Result<Meeting, string> ScheduleMeeting(MeetingRequest request)
    {
        var duration = TimeSpan.FromMinutes(request.DurationMinutes);

        var userMeetings = request.ParticipantIds
            .Select(id => _store.Meetings
                .Where(m => m.ParticipantIds.Contains(id))
                .OrderBy(m => m.StartTime)
                .ToList())
            .ToList();

        var start = request.EarliestStart;
        var end = request.LatestEnd - duration;

        for (var time = start; time <= end; time = time.AddMinutes(15))
        {
            var slot = new TimeSlot { Start = time, End = time + duration };
            if (IsSlotAvailable(slot, userMeetings))
            {
                var meeting = new Meeting
                {
                    Id = _store.NextMeetingId++,
                    ParticipantIds = request.ParticipantIds,
                    StartTime = slot.Start,
                    EndTime = slot.End
                };
                return Result<Meeting, string>.Success(meeting);
            }
        }

        return Result<Meeting, string>.Failure("No available time slot found.");
    }

    /// <summary>
    /// Перевіряє, чи є заданий часовий проміжок доступним для всіх учасників зустрічі.
    /// </summary>
    /// <param name="slot">
    ///     Перевіряємий часовий проміжок
    ///     Time slot to check
    /// </param>
    /// <param name="userMeetings">
    ///     Список зустрічей для кожного учасника
    ///     List of meetings for each participant
    /// </param>
    /// <returns>true, якщо проміжок доступний для всіх учасників</returns>
    /// <summary>
    /// Checks whether the specified time slot is available for all meeting participants.
    /// </summary>
    /// <returns>true if the slot is available for all participants</returns>
    private bool IsSlotAvailable(TimeSlot slot, List<List<Meeting>> userMeetings)
    {
        foreach (var meetings in userMeetings)
        {
            if (meetings.Any(m => m.StartTime < slot.End && m.EndTime > slot.Start))
                return false;
        }
        return true;
    }
}