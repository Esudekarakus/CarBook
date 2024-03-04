using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext carBookContext;
        public Repository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
            
        }

        public async Task CreateAsync(T entity)
        {
            carBookContext.Set<T>().Add(entity);
            await carBookContext.SaveChangesAsync();    
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await carBookContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await carBookContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            carBookContext.Set<T>().Remove(entity);
            await carBookContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           carBookContext.Set<T>().Update(entity);
            await carBookContext.SaveChangesAsync();
        }
    }
}
