using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFeaturetCommand command)
        {
            var values = await repository.GetByIdAsync(command.AboutId);
            values.Description = command.Description;
            
            values.ImageUrl = command.ImageUrl;
            values.Title = command.Title;   
            await repository.UpdateAsync(values);
        }
    }
}
