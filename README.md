# Prowl-App-Sharp
A .net 6 implementation of sending messages with the push notification ["Prowl" App](https://www.prowlapp.com).

## Installation

Install `ProwlAppSharp` via nuget ([see nuget page](https://www.nuget.org/packages/ProwlAppSharp) - if you're not already here 😉).

### Example Usage

```c#
using Prowl;

string prowlApiKey = Environment.GetEnvironmentVariable("PROWL_API_KEY");
ProwlMessage prowlMessage = new(prowlApiKey);
string appName = "My app name";
string description = "My message";
HttpResponseMessage prowlResponse = await prowlMessage.SendAsync(description, application: appName);
```

or just create your own `ProwlMessageContents` object and pass that in:

```c#
using Prowl;
using Prowl.Enums;
using Prowl.Models;

ProwlMessage prowlMessage = new(prowlApiKey);
var myContents = new ProwlMessageContents
{
    Description = "My main message",
    Priority = Priority.Normal,
    Url = "http://mysite.com",
    Application = "MyApp",
    Event = "My Event"
};
var prowlResponse = await prowlMessage.SendAsync(myContents);
```