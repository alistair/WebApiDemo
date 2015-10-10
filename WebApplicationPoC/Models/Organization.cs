using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationPoC.Models
{
	public class Organization
	{
		public Organization()
		{
			Employees = new List<Employee>();	
		}

		public Guid Id { get; set; }

		public string Title { get; set; }

		public Address Address { get; set; }
		public Byte[] Timestamp { get; set; }

		public virtual List<Employee> Employees { get; set; }

		public void Hire(string firstName, string lastName, Address address)
		{
			Employees.Add(new Employee
			{
				FirstName = firstName,
				LastName = lastName,
				Address = address
			});
		}
	}

	//Yes Yes I know that you can't define an address like this and expect to not be made a fool of.
	public class Address
	{
		public string Street { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}

	public class Employee
	{
		public Guid Id { get; set; }

		public virtual Organization Organization { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName {  get { return FirstName + " " + LastName; } }

		public Address Address { get; set; }

		public Byte[] Timestamp { get; set; }
	}
}