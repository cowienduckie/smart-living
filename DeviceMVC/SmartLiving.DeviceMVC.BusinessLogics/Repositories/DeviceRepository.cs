using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BusinessLogics.Configs;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data;
using SmartLiving.DeviceMVC.Data.Models;
using System.Collections.Generic;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public IEnumerable<DeviceModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DeviceModel GetById(int id)
        {
            var client = new RestClient(ConnectConfigs.URL + $"/api/Sync/GetDeviceById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<DeviceModel>();
            }

            return null;
        }
    }
}