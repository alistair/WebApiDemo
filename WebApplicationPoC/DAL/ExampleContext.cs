using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplicationPoC.Models;

namespace WebApplicationPoC.DAL
{
	public class ExampleContext : DbContext
	{
		public DbSet<Organization> Organizations { get; set; }

		public ExampleContext() : this("default")
		{
		}

		public ExampleContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Conventions https://msdn.microsoft.com/en-us/library/system.data.entity.modelconfiguration.conventions.aspx
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.ComplexType<Address>();
			modelBuilder.
				Entity<Organization>()
				.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Employee>()
				.Ignore(x => x.FullName)
				.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}