using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository repository;
        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            this.repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values =  repository.GetCarsListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName=x.Brand.Name,
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Fuel = x.Fuel,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Model = x.Model,
                Transmission = x.Transmission

            }).ToList();
        }
    }
}
