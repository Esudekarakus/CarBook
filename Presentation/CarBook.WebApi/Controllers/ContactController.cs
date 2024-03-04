using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;

using Microsoft.AspNetCore.Mvc;

namespace ContactBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler createContactCommandHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;
      

        public ContactController(CreateContactCommandHandler createContactCommandHandler, GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            this.createContactCommandHandler = createContactCommandHandler;
            this.getContactQueryHandler = getContactQueryHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
           
        }

        [HttpGet]

        public async Task<IActionResult> ContactList()
        {
            var values = await getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok("İletişim bilgisi eklendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("İletişim başarıyla güncellendi");
        }

       
    }
}
