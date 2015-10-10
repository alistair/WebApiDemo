using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace WebApplicationPoC.Migrations
{
	public class Create_Organization : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"public.Organization", 
				c => new
					{
						Id = c.Guid(nullable: false),
						Title = c.String(),
						Address_Street = c.String(),
						Address_City = c.String(),
						Address_Country = c.String()
					}
				).PrimaryKey(t => t.Id);

			CreateTable(
				"public.Employee",
				c => new
					{
						Id = c.Guid(nullable: false),
						OrganizationId = c.Guid(nullable: false),
                        Address_Street = c.String(),
						Address_City = c.String(),
						Address_Country = c.String(),
						FirstName = c.String(),
						LastName = c.String()
				}
				).PrimaryKey(t => t.Id)
				.ForeignKey("public.Organization", t => t.OrganizationId);
		}
	}
}