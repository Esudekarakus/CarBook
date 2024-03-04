using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler
            ;
        private readonly GetAboutQueryHandler getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler removeAboutCommandHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            this.createAboutCommandHandler = createAboutCommandHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.getAboutQueryHandler = getAboutQueryHandler;
            this.updateAboutCommandHandler = updateAboutCommandHandler;
            this.removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> AboutList()
        {
            var values = await getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await createAboutCommandHandler.Handle(command);
            return Ok("Hakkında bilgisi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkında bilgisi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateFeaturetCommand command)
        {
            await updateAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi başarıyla güncellendi");
        }
    }
}
