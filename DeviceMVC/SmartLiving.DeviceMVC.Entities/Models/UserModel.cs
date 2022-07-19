using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.DeviceMVC.Entities.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<HouseModel> Houses { get; set; }
    }
}