using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator mediator;

        public PricingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> PricingList()
        {
            var values = await mediator.Send(new GetPricingQuery());
            return Ok(values);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok("Pricing başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok("Başarıyla güncellendi");
        }
    }
}
