using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly GetBannerQueryHandler  getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;

        public BannerController(GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.createBannerCommandHandler = createBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner (int id)
        {
            var value = await getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery (id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await createBannerCommandHandler.Handle(command);
            return Ok("Bilgi eklendi");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveBanner(int id)
        {
            await removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Bilgi silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await updateBannerCommandHandler.Handler(command);
            return Ok("Bilgi güncellendi");
        }
    }
}
