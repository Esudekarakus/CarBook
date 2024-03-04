using CarBook.Application.Features.Mediator.Commands.FooterCommands;
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
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<FooterAddress> repository;

        public UpdateFooterCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.FooterAddressId);
            values.Phone = request.Phone;
            values.Description = request.Description;   
            values.Email = request.Email;
            values.Address = request.Address;  
            await repository.UpdateAsync(values);
        }
    }
}
