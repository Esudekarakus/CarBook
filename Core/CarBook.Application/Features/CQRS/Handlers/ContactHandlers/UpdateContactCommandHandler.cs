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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await repository.GetByIdAsync(command.ContactId);
            values.Name = command.Name;
            values.Email = command.Email;
            values.Subject = command.Subject;
            values.Message = command.Message;
            values.SentDate = command.SentDate;
           
            await repository.UpdateAsync(values);

        }
    }
}
