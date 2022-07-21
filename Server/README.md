# Smart Living Server

## Requirements

[.NET Core 3.1 SDK]

## Installation

Setup User Secret `secret.json` or your environment as below

```json
{
  "ConnectionStrings": {
    "PostgreSql": "User ID=YourUserName;Password=YourPassword;Host=HostName;Port=PortNumber;Database=DatabaseName;"
  }
}
```
Without Visual Studio, setup User Secret as below

```shell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:PostgreSql" "User ID=YourUserName;Password=YourPassword;Host=HostName;Port=PortNumber;Database=DatabaseName;"
```

## Build and Run

```shell
cd SmartLiving/Server
dotnet build
dotnet run --project SmartLiving.Api
```

## Demo

A live server demo is running in [here](https://smartlivingapi.azurewebsites.net/swagger)

[//]: #
[.NET Core 3.1 SDK]: <https://dotnet.microsoft.com/en-us/download/dotnet/3.1>
