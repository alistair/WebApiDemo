using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApplicationPoC.DAL;

namespace WebApplicationPoC.Features.Organization
{
	public class Index
	{
		public class Query : IAsyncRequest<List<Model>>{ }

		public class Model
		{
			public Guid Id { get; set; }
			public string Title { get; set; }
			public int NumberOfEmployees { get; set; }
		}

		public class Handler : IAsyncRequestHandler<Query, List<Model>>
		{
			private readonly ExampleContext _context;

			public Handler(ExampleContext context)
			{
				_context = context;
			}

			public Task<List<Model>> Handle(Query message)
			{
				return _context.Organizations.ProjectToListAsync<Model>();
			}
		}
	}
}