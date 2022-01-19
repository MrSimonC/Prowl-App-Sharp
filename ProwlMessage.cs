using Prowl.Enums;
using Prowl.Models;

namespace Prowl;

public class ProwlMessage : IProwlMessage
{
    private readonly HttpClient HttpClient;
    private readonly string ApiKey;

    public ProwlMessage(string apiKey)
    {
        HttpClient = new HttpClient();
        ApiKey = apiKey;
    }

    public async Task<HttpResponseMessage> SendAsync(
        string description,
        Priority priority = Priority.Normal,
        string url = "",
        string application = "Prowl Message",
        string evnt = "Prowl Event")
    {
        var prowlAddUrl = "https://api.prowlapp.com/publicapi/add";

        Dictionary<string, string>? values = new()
        {
                    { "apikey", ApiKey },
                    { "priority", priority.ToString() },
                    { "url", url },
                    { "application", application },
                    { "event", evnt },
                    { "description", description },
                };

        FormUrlEncodedContent? content = new(values);
        var response = await HttpClient.PostAsync(prowlAddUrl, content);
        return response;
    }

    public async Task<HttpResponseMessage> SendAsync(ProwlMessageContents prowlMessageContents) => await SendAsync(
            prowlMessageContents.Description,
            prowlMessageContents.Priority,
            prowlMessageContents.Url,
            prowlMessageContents.Application,
            prowlMessageContents.Event);
}
