# Prowl-App-Sharp
A .net 6 implementation of sending messages with the Prowl App (for push notifications).

## Installation

Install `ProwlAppSharp` via nuget ([see nuget page](https://www.nuget.org/packages/ProwlAppSharp) - if you're not already here 😉).

### Example Usage

```c#
string prowlApiKey = Environment.GetEnvironmentVariable("PROWL_API_KEY") ?? throw new ArgumentNullException(nameof(prowlApiKey));
ProwlMessage = new ProwlMessage(prowlApiKey);
string websiteName = "My App/Sender name";
string description = "My message";
var prowlResponse = await prowl.SendAsync(description, application: websiteName);
var success = prowlResponse?.IsSuccessStatusCode ?? false;
```

or just create your own `ProwlMessageContents` object and pass that in:

```c#
var myContents = new ProwlMessageContents
{
    Description = "My main message",
    Priority = Priority.Normal,
    Url = "http://mysite.com",
    Application = "MyApp",
    Event = "My Event"
};
var prowlResponse = await prowl.SendAsync(myContents);
```