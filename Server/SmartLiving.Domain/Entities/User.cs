using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace SmartLiving.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required] public bool IsDelete { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Create Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Last Modified")]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastModified { get; set; } = DateTime.Now;

        public virtual IList<House> Houses { get; set; }

        public virtual IList<Profile> Profiles { get; set; }

        public virtual IList<SharedWith> SharedWith { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }

        public virtual IList<Command> Commands { get; set; }
    }
}