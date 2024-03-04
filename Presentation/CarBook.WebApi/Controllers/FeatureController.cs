using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator mediator;

        public FeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> FeatureList()
        {
            var values = await mediator.Send(new GetFeatureQuery());
            return Ok(values);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFeature(int id)
        {
            var value= await mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Özellik başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Başarıyla güncellendi");
        }
    }
}
