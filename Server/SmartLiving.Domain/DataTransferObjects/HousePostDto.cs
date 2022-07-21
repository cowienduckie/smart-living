using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class HousePostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int HouseTypeId { get; set; }
    }
}
