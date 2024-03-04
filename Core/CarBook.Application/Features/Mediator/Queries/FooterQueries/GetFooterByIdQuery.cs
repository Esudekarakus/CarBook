using CarBook.Application.Features.Mediator.Results.FooterQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterQueries
{
    public class GetFooterByIdQuery: IRequest<GetFooterByIdQueryResult>
    {
        public GetFooterByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
