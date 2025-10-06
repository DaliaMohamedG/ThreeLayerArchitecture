namespace DataAccessLayer.Data.Configurations
{
    public class DepartmentConfigurations : BasentityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");

            base.Configure(builder);

        }
    }
}

/*
 * HasDefaultValueSql: give value when you insert "later you change it"
 * HasComputedColumnSql: give value when you insert and change it by default
 * 
 */