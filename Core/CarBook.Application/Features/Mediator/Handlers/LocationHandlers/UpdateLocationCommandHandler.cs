
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;

namespace CarBook.Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler:IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.LocationId);

            values.Name = request.Name;


            await repository.UpdateAsync(values);
        }
    }
}
