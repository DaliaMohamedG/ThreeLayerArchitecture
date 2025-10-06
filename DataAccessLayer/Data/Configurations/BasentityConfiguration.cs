using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Configurations
{
    public class BasentityConfiguration<t> : IEntityTypeConfiguration<t> where t : BaseEntity
    {
        public void Configure(EntityTypeBuilder<t> builder)
        {

            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.ModifiedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
//you can't make a configuration of an interface or a class not implemented as a table
//<t> can be interface or any class