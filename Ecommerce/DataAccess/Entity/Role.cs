using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Role:CoreEntity
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
