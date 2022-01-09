using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class AppUserAndRole:CoreEntity
    {
        public Guid AppUserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Role Role { get; set; }

    }
}
