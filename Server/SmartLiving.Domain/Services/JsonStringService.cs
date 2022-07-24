using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Services
{
    public interface IJsonStringService
    {
        JObject Serialize(HouseGetDto model);

        JObject Serialize(AreaGetDto model);
    }

    public class JsonStringService : IJsonStringService
    {
        public JObject Serialize(HouseGetDto model)
        {
            var rooms = new JObject();

            foreach (var area in model.Areas)
            {
                var room = new JObject
                {
                    ["name"] = area.Name,
                    ["icon"] = RoomIcon.GetIcon(area.Name),
                    ["devicesCount"] = area.Devices?.Count,
                };

                rooms.Add(Convert.ToString(area.Id), room);
            }

            return new JObject
            {
                ["rooms"] = rooms
            };
        }

        public JObject Serialize(AreaGetDto model)
        {
            var devices = new JObject();

            foreach (var device in model.Devices)
                devices.Add(Convert.ToString(device.Id), JObject.Parse(device.Params));

            return new JObject
            {
                ["devices"] = devices
            };
        }

        #region Utilities

        private static class RoomIcon
        {
            private static readonly Dictionary<string, string> RoomIcons = new Dictionary<string, string>
            {
                { "Living Room", "couch" },
                { "Kitchen", "bread-slice" },
                { "Bedroom", "bed" },
                { "Bathroom", "bath" },
                { "Study Room", "book" },
                { "Dining Room", "utensils" }
            };
            private const string DefaultIcon = "door-open";

            public static string GetIcon(string roomName)
            {
                foreach (var room in RoomIcons)
                {
                    if (roomName.Contains(room.Key))
                    {
                        return room.Value;
                    }
                }

                return DefaultIcon;
            }
        }
        #endregion
    }
}