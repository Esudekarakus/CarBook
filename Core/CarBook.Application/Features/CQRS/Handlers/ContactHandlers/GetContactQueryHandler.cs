using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> contactRepository;

        public GetContactQueryHandler(IRepository<Contact> ContactRepository)
        {
            contactRepository = ContactRepository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await contactRepository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
              Subject = x.Subject,
              SentDate = x.SentDate,
              ContactId = x.ContactId,
              Email = x.Email,
              Message = x.Message,
              Name = x.Name,
            }).ToList();
        }
    }
}
