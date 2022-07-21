using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class DeviceGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceTypeGetDto DeviceType { get; set; }

        public int? AreaId { get; set; }

        public AreaGetDto Area { get; set; }

        public int HouseId { get; set; }

        public HouseGetDto House { get; set; }

        public string Params { get; set; }

        public bool IsActive { get; set; }
    }
}
