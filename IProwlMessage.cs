using Prowl.Enums;
using Prowl.Models;

namespace Prowl;

public interface IProwlMessage
{
    Task<HttpResponseMessage> SendAsync(string description, Priority priority = Priority.Normal, string url = "", string application = "Prowl Message", string @event = "Prowl Event");
    Task<HttpResponseMessage> SendAsync(ProwlMessageContents prowlMessageContents);
}