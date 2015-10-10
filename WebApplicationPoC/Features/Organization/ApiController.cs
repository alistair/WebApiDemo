using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace WebApplicationPoC.Features.Organization
{
    public class ApiController : System.Web.Http.ApiController
    {
	    private readonly IMediator _mediator;
	    public ApiController(IMediator mediator)
	    {
		    _mediator = mediator;
	    }

		[Route("organization")]
	    public Task<List<Index.Model>> GetOrganizations()
	    {
		    return _mediator.SendAsync(new Index.Query());
	    }

	    [Route("organization/{id}/hire")]
	    public Task<Hire.Response> PostEmployeeHire(Guid id, Hire.Employee employee)
	    {
			//TODO: Work on this,  doesn't seem a nice solution.
		    employee.OrganizationId = id;
		    return _mediator.SendAsync(employee);
	    }
    }
}
