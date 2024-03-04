using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await repository.GetByIdAsync(command.CarId);

            values.Transmission=command.Transmission;
            values.BrandId=command.BrandId;
            values.BigImageUrl=command.BigImageUrl;
            values.CoverImageUrl=command.CoverImageUrl;
            values.Fuel=command.Fuel;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Km=command.Km;
            values.Luggage=command.Luggage;
            values.Model=command.Model;
            values.Seat=command.Seat;
    


            await repository.UpdateAsync(values);

        }
    }
}
