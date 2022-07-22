using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BusinessLogics.Configs;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserModel> GetAll()
        {
            var client = new RestClient(ConnectConfigs.Url + "/api/Sync/GetAllUsers");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (!response.IsSuccessful) return null;
            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            return content?.ToObject<List<UserModel>>();

        }

        public UserModel GetById(string id)
        {
            var client = new RestClient(ConnectConfigs.Url + $"/api/Sync/GetUserById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (!response.IsSuccessful) return null;
            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            return content?.ToObject<UserModel>();

        }
    }
}