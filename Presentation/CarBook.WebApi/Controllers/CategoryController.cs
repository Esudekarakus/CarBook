using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CategoryBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values = await getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok("Kategori bilgisi eklendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok("Kategori başarıyla güncellendi");
        }
    }
}

