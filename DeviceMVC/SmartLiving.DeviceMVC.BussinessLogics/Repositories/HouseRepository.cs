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
