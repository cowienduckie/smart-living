namespace SmartLiving.DeviceMVC.BussinessLogics.Configs
{
    public static class ConnectConfigs
    {
        public const string API_URL = "https://smartlivingapi.azurewebsites.net";
        public const string LOCAL_API_URL = "https://localhost";
        public const string LOCAL_API_PORT = "5001";
        public const string LOCAL_IIS_API_PORT = "44307";
        public static string URL = $"{LOCAL_API_URL}:{LOCAL_IIS_API_PORT}";
    }
}