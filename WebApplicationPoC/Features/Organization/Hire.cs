using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using WebApplicationPoC.DAL;
using WebApplicationPoC.Models;

namespace WebApplicationPoC.Features.Organization
{
	public class Hire
	{
		public class Employee : IAsyncRequest<Response>
		{
			public Guid OrganizationId { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public Address Address { get; set; }
		}

		public class Response
		{
		}

		public class Validator : AbstractValidator<Employee>
		{
			public Validator()
			{
				RuleFor(_ => _.FirstName).NotNull().Length(1, 20);
				RuleFor(_ => _.LastName).NotNull().Length(1, 20);
			}
		}

		public class Handler : IAsyncRequestHandler<Employee, Response>
		{
			public readonly ExampleContext _exampleContext;

			public Handler(ExampleContext exampleContext)
			{
				_exampleContext = exampleContext;
			}

			public async Task<Response> Handle(Employee message)
			{
				var organization = await _exampleContext.Organizations.FirstOrDefaultAsync(x => x.Id == message.OrganizationId);
				organization.Hire(message.FirstName, message.LastName, message.Address);
				await _exampleContext.SaveChangesAsync();
				return new Response();
			}
		}
	}
}