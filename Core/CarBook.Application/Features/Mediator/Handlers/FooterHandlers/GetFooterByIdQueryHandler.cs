using CarBook.Application.Features.Mediator.Queries.FooterQueries;
using CarBook.Application.Features.Mediator.Results.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FooterQueries;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterHandlers
{
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> repository;

        public GetFooterByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);
            return new GetFooterByIdQueryResult
            {
                Description= values.Description,
                Address= values.Address,
                Email= values.Email,
                FooterAddressId= values.FooterAddressId,
                Phone= values.Phone,
            };
        }
    }
}
