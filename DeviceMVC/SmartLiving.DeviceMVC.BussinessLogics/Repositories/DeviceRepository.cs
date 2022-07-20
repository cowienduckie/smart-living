using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BussinessLogics.Configs;
using SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Entities.Models;
using System.Collections.Generic;

namespace SmartLiving.DeviceMVC.BussinessLogics.Repositories
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