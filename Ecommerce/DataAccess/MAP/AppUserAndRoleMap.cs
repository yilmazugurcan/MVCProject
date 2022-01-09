using CORE;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAP
{
    public class AppUserAndRoleMap:CoreMap<AppUserAndRole>
    {
        public AppUserAndRoleMap()
        {
            ToTable("dbo.AppUserAndRoles");
            Ignore(x => x.ID);
            HasKey(x => new { x.AppUserId, x.RoleId });
        }
    }
}
