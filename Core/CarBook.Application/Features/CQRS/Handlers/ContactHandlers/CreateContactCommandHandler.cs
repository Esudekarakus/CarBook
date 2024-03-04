using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await repository.CreateAsync(new Contact
            {
                Name = command.Name,
                Subject = command.Subject,
                SentDate = command.SentDate,
                Email = command.Email,
                Message = command.Message,

            });
        }
    }
}
