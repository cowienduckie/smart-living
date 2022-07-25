# Smart Living Device Gateways

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
cd SmartLiving/DeviceMVC/SmartLiving.DeviceMVC
dotnet user-secrets init
dotnet user-secrets set "ConnectionString"  "User ID=YourUserName;Password=YourPassword;Host=HostName;Port=PortNumber;Database=DatabaseName;Trust Server Certificate=true"
```

## Build and Run

```shell
cd SmartLiving/DeviceMVC
dotnet build
dotnet run --project SmartLiving.DeviceMVC
```

## Demo

The web application will be hosted at `https://localhost:6001` and `http://localhost:6000`

[//]: #
[.NET Core 3.1 SDK]: <https://dotnet.microsoft.com/en-us/download/dotnet/3.1>
