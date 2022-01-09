using CORE;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAP
{
    public class RoleMap:CoreMap<Role>
    {
        public RoleMap()
        {
            ToTable("dbo.Roles");
            Ignore(x => x.ID);
            HasKey(x => x.RoleId);
        }
    }
}
