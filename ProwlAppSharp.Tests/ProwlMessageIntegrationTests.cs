using Prowl;
using Prowl.Enums;
using Prowl.Models;

namespace ProwlAppSharp.Tests;

public class ProwlMessageIntegrationTests
{
    private static string GetApiKey()
    {
        var apiKey = Environment.GetEnvironmentVariable("PROWL_API_KEY");
        Assert.False(string.IsNullOrWhiteSpace(apiKey), "PROWL_API_KEY must be set for integration tests.");
        return apiKey!;
    }

    [Fact]
    public async Task SendAsync_WithParameters_ReturnsSuccessStatusCode()
    {
        var client = new ProwlMessage(GetApiKey());
        var response = await client.SendAsync(
            description: $"Prowl-App-Sharp CI parameter test {Guid.NewGuid():N}",
            priority: Priority.VeryLow,
            application: "ProwlAppSharp CI",
            evnt: "dotnet test");

        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.True(response.IsSuccessStatusCode, $"Expected success but received {(int)response.StatusCode}: {responseBody}");
    }

    [Fact]
    public async Task SendAsync_WithMessageContents_ReturnsSuccessStatusCode()
    {
        var client = new ProwlMessage(GetApiKey());
        var contents = new ProwlMessageContents
        {
            Description = $"Prowl-App-Sharp CI contents test {Guid.NewGuid():N}",
            Priority = Priority.VeryLow,
            Application = "ProwlAppSharp CI",
            Event = "dotnet test"
        };

        var response = await client.SendAsync(contents);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.True(response.IsSuccessStatusCode, $"Expected success but received {(int)response.StatusCode}: {responseBody}");
    }
}
