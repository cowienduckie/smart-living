using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class HouseGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int HouseTypeId { get; set; }
        public HouseTypeGetDto HouseType { get; set; }
        public List<AreaGetDto> Areas { get; set; }
    }
}
