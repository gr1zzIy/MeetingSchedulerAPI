using System;
using System.Collections.Generic;
using TestDotnet.Models;
using TestDotnet.Services;
using TestDotnet.Storage;
using Xunit;

namespace TestDotnet.TestDotnet.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var store = new DataStore();
        var scheduler = new MeetingScheduler(store);

        store.Users.AddRange(new[]
        {
            new User { Id = 1, Name = "Oleksii" },
            new User { Id = 2, Name = "Ruslan" }
        });

        // Meeting already at 9:00–10:00 for user 1
        store.Meetings.Add(new Meeting
        {
            Id = 1,
            ParticipantIds = new List<int> { 1 },
            StartTime = DateTime.Parse("2025-06-20T09:00:00Z"),
            EndTime = DateTime.Parse("2025-06-20T10:00:00Z")
        });

        var request = new MeetingRequest
        {
            ParticipantIds = new List<int> { 1, 2 },
            DurationMinutes = 60,
            EarliestStart = DateTime.Parse("2025-06-20T09:00:00Z"),
            LatestEnd = DateTime.Parse("2025-06-20T17:00:00Z")
        };

        var result = scheduler.ScheduleMeeting(request);

        Assert.True(result.IsSuccess);
        Assert.Equal(DateTime.Parse("2025-06-20T10:00:00Z"), result.Value!.StartTime);
    }
}