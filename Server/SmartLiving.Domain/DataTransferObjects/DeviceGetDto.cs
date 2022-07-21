using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class DeviceGetDto
    {
        [Required] [Key] public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        [Required] public int DeviceTypeId { get; set; }

        public int? AreaId { get; set; }

        [Required] public string Params { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}
