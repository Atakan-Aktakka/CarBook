using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServiceResults
{
    public class GetServiceQuery:IRequest<List<GetServiceQueryResult>>
    {
        
    }
}