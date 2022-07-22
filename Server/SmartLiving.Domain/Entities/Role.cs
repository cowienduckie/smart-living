using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SmartLiving.Domain.Entities
{
    public class Role : IdentityRole
    {
        public virtual IList<UserRole> UserRoles { get; set; }
    }
}