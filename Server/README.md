# Smart Living Server

## Requirements

[.NET Core 3.1 SDK]

## Installation

Setup User Secret `secret.json` or your environment as below

```json
{
  "ConnectionString":  "User ID=YourUserName;Password=YourPassword;Host=HostName;Port=PortNumber;Database=DatabaseName;Trust Server Certificate=true"
}
```

Without Visual Studio, setup User Secret as below

```shell
cd SmartLiving/Server/SmartLiving.Api
dotnet user-secrets init
dotnet user-secrets set "ConnectionString"  "User ID=YourUserName;Password=YourPassword;Host=HostName;Port=PortNumber;Database=DatabaseName;Trust Server Certificate=true"
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
