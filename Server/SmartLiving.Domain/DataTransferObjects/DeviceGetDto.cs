﻿using System.Collections.Generic;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class DeviceGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceTypeGetDto DeviceType { get; set; }

        public int? AreaId { get; set; }

        public int HouseId { get; set; }

        public string Params { get; set; }

        public bool IsActive { get; set; } = false;

        public List<DeviceCommandTypeGetDto> DeviceCommandTypes { get; set; }
    }

    public class DeviceCommandTypeGetDto
    {
        public int DeviceId { get; set; }
        public int CommandTypeId { get; set; }
        public CommandTypeGetDto CommandType { get; set; }
    }
}