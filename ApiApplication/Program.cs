using StackExchange.Redis;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddRedisClient("cache");

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", async (IConnectionMultiplexer connection) =>
{
    var database = connection.GetDatabase();

    var entry = new Entry();

    // Add an entry to the list on each request.
    await database.ListRightPushAsync("entries", JsonSerializer.SerializeToUtf8Bytes(entry));

    var entries = new List<Entry>();
    var list = await database.ListRangeAsync("entries");

    foreach (var item in list)
    {
        entries.Add(JsonSerializer.Deserialize<Entry>((string)item!)!);
    }

    return entries;
});

app.Run();

public class Entry
{
    public Guid Id { get; set; } = Guid.NewGuid();
}