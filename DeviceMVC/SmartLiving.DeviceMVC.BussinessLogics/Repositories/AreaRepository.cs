
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BussinessLogics.Configs;
using SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BussinessLogics.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public IEnumerable<AreaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AreaModel GetById(int id)
        {
            var client = new RestClient(ConnectConfigs.URL + $"/api/Sync/GetAreaById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<AreaModel>();
            }

            return null;
        }
    }
}
