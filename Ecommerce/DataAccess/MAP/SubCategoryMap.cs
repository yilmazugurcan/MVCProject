using CORE;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAP
{
    public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            Property(x => x.SubCategoryName).IsRequired().HasMaxLength(250);
            Property(x => x.Description).IsOptional().HasMaxLength(250);

        }
    }
}
