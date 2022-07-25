namespace SmartLiving.DeviceMVC.BusinessLogics.Configs
{
    public static class ConnectConfigs
    {
        public const string ApiUrl = "https://smartlivingapi.azurewebsites.net";
        private const string LocalApiUrl = "https://localhost";
        public const string LocalApiPort = "5001";
        private const string LocalIisApiPort = "44307";
        public static readonly string Url = $"{LocalApiUrl}:{LocalIisApiPort}";
    }
}