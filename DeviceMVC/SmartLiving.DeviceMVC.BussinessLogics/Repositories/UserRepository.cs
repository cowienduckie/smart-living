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
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserModel> GetAll()
        {
            var client = new RestClient(ConnectConfigs.URL + "/api/Sync/GetAllUsers");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<List<UserModel>>();
            }

            return null;
        }

        public UserModel GetById(string id)
        {
            var client = new RestClient(ConnectConfigs.URL + $"/api/Sync/GetUserById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                return content.ToObject<UserModel>();
            }

            return null;
        }
    }
}
