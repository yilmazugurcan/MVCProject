using CORE;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class Category:CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
