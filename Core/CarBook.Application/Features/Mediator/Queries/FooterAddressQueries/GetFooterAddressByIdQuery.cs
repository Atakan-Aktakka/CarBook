using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery:IRequest<GetFooterAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}