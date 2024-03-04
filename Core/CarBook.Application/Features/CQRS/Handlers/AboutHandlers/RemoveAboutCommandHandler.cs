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
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> repository;
        public RemoveAboutCommandHandler(IRepository<About> repo)
        {
            repository = repo;
        }

        public async Task Handle(RemoveAboutCommand removeCommand)
        {
            var value = await repository.GetByIdAsync(removeCommand.Id);
            await repository.RemoveAsync(value);
        }
    }
}
