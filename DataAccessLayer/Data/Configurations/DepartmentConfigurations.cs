namespace DataAccessLayer.Data.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varcchar(20)");
            builder.Property(d => d.Code).HasColumnType("varcchar(20)");
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.ModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}

/*
 * HasDefaultValueSql: give value when you insert "later you change it"
 * HasComputedColumnSql: give value when you insert and change it by default
 * 
 * 
 * 
 * 
 */