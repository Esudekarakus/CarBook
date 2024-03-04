using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler, GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            this.createCarCommandHandler = createCarCommandHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]

        public async Task<IActionResult> CarList()
        {
            var values = await getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await createCarCommandHandler.Handle(command);
            return Ok("Araba bilgisi eklendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok("Araba başarıyla güncellendi");
        }

        [HttpGet("GetCarWithBrand")]
        public  IActionResult GetCarWithBrand()
        {
            var values = getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}

