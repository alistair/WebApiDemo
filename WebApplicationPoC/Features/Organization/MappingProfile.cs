using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApplicationPoC.Features.Organization
{
	public class MappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Models.Organization, Index.Model>()
				.ForMember(x => x.NumberOfEmployees, ctx => ctx.MapFrom(o => o.Employees.Count));
		}
	}
}