using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> repo;

        public GetBannerQueryHandler(IRepository<Banner> repo)
        {
            this.repo = repo;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values= await repo.GetAllAsync();
            return values.Select(x=> new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Description=x.Description,
                VideoDescription=x.VideoDescription,
                Title = x.Title,
                VideoUrl = x.VideoUrl
                
            }).ToList();
        }
    }
}
