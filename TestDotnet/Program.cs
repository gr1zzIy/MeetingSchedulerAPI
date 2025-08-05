using TestDotnet.Models;
using TestDotnet.Storage;
using TestDotnet.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DataStore>();
builder.Services.AddScoped<MeetingScheduler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/users", (string name, DataStore store) =>
{
    var user = new User { Id = store.NextUserId++, Name = name };
    store.Users.Add(user);
    return Results.Ok(user);
});

app.MapGet("/users/{userId}/meetings", (int userId, DataStore store) =>
{
    var meetings = store.Meetings.Where(m => m.ParticipantIds.Contains(userId)).ToList();
    return Results.Ok(meetings);
});

app.MapPost("/meetings", (MeetingRequest request, DataStore store, MeetingScheduler scheduler) =>
{
    var result = scheduler.ScheduleMeeting(request);
    return result.Match(
        meeting => {
            store.Meetings.Add(meeting);
            return Results.Ok(meeting);
        },
        error => Results.BadRequest(error)
    );
});

app.Run();