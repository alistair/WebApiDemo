using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplicationPoC.Models;

namespace WebApplicationPoC.DAL
{
	public class Configuration : DbMigrationsConfiguration<ExampleContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(ExampleContext context)
		{
			var data = new List<Organization>
			{
				new Organization()
				{
					Title = "Happy Ltd",
					Address = new Address()
					{
						Street = "123 Hello Street",
						City = "HelloVille",
						Country = "HappyLand"
					}
				},
				new Organization()
				{
					Title = "Sad Ltd",
					Address = new Address()
					{
						Street = "123 Angry Street",
						City = "AngryVille",
						Country = "AngryLand"
					}
				}
			};

			if (context.Organizations.Any())
			{
				return;
			}

			data.ForEach(x => context.Organizations.AddOrUpdate(x));
			context.SaveChanges();

			context.Organizations.FirstOrDefault(x => x.Title == "Happy Ltd").Employees.AddRange(new List<Employee>
			{
				new Employee()
				{
					FirstName = "A",
					LastName = "A",
					Address = new Address()
					{
						Street = "123 Normal Lane",
						City = "",
						Country = ""
					}
				},
				new Employee()
				{
					FirstName = "A",
					LastName = "B",
                    Address = new Address()
					{
						Street = "1 Hello Street",
						City = "HelloVille",
						Country = "HappyLand"
					}
				},
				new Employee()
				{
					FirstName = "A",
					LastName = "C",
					Address = new Address()
					{
						Street = "123 Angry Street",
						City = "AngryVille",
						Country = "AngryLand"
					}
				},
				new Employee()
				{
					FirstName = "A",
					LastName = "D",
					Address = new Address()
					{
						Street = "123 Angry Street",
						City = "AngryVille",
						Country = "AngryLand"
					}
				},
				new Employee()
				{
					FirstName = "A",
					LastName = "E",
					Address = new Address()
					{
						Street = "123 Angry Street",
						City = "AngryVille",
						Country = "AngryLand"
					}
				}
			});
			context.SaveChanges();
		}
	}
}