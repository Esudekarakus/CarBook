using CarBook.Application.Features.Mediator.Commands.FooterCommands;
using CarBook.Application.Features.Mediator.Queries.FooterQueries;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IMediator mediator;

        public FooterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> FooterList()
        {
            var values = await mediator.Send(new GetFooterQuery());
            return Ok(values);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFooter(int id)
        {
            var value = await mediator.Send(new GetFooterByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand command)
        {
            await mediator.Send(command);
            return Ok("Footer başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooter(int id)
        {
            await mediator.Send(new RemoveFooterCommand(id));
            return Ok("Footer silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand command)
        {
            await mediator.Send(command);
            return Ok("Başarıyla güncellendi");
        }
    }
}
