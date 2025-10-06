using DataAccessLayer.Models.Shared;

namespace DataAccessLayer.Data.Configurations
{
    public class EmployeeConfiguration : BasentityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Address).HasColumnType("varchar(50)");
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.gender).HasConversion(eg => eg.ToString(), eg => (Gender)Enum.Parse(typeof(Gender), eg));
            //                                          app->database    ,  database->app      
            builder.Property(e => e.employeeType).HasConversion(et => et.ToString(), et => (EmployeeType)Enum.Parse(typeof(EmployeeType), et));
            base.Configure(builder);
        }
    }
}

/*
class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

Animal a = new Dog();
a.Speak();   //Woof!
----------------------------------------------------------
class Animal
{
    public void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}
class Dog : Animal
{
    public new void Speak()
    {
        Console.WriteLine("Woof!");
    }
}
Dog d = new Dog();
d.Speak();   // Woof!

Animal a = new Dog();
a.Speak();   // Animal sound
*/

