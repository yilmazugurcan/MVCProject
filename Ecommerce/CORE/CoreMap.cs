using System.Data.Entity.ModelConfiguration;

namespace CORE
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.CreatedAdUsername).HasMaxLength(250);
            Property(x => x.CreatedBy).HasMaxLength(250);
            Property(x => x.CreatedComputerName).HasMaxLength(250);
            Property(x => x.CreatedIP).HasMaxLength(250);
        }
    }
}
