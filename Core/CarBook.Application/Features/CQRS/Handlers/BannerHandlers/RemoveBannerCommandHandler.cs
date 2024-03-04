using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public  async Task Handle(RemoveAboutCommand command)
        {
            var value = await _bannerRepository.GetByIdAsync(command.Id);
            await _bannerRepository.RemoveAsync(value);
        }

        public Task Handle(RemoveBannerCommand removeBannerCommand)
        {
            throw new NotImplementedException();
        }
    }
}
