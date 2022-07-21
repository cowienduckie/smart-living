using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.Entities.Models
{
    public class CommandTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultParams { get; set; }
    }
}
