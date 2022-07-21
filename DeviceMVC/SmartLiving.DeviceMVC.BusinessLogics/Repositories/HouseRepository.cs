using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BusinessLogics.Configs;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data;
using SmartLiving.DeviceMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        public IEnumerable<HouseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public HouseModel GetById(int id)
        {
            var client = new RestClient(ConnectConfigs.URL + $"/api/Sync/GetHouseById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<HouseModel>();
            }

            return null;
        }

        public IEnumerable<HouseModel> GetByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
