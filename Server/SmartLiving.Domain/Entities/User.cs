using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SmartLiving.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [AllowNull] public DateTime? DateOfBirth { get; set; }

        public virtual IList<House> Houses { get; set; }
    }
}
