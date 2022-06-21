using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLiving.Domain.Entities
{
    public class BaseEntity
    {
        [Required] public bool IsDelete { get; set; } = false;

        [Column(Order = 999)]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Create Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Column(Order = 999)]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}