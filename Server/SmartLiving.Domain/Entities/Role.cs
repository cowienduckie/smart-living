using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SmartLiving.Domain.Entities
{
    public class Role : IdentityRole
    {
        public virtual IList<UserRole> UserRoles { get; set; }
    }
}