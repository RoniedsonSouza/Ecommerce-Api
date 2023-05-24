using Application.Interfaces.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<T> Insert(T obj)
        {
            var result = await entities.AddAsync(obj);
            await context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task InsertRangeAsync(List<T> obj)
        {
            await entities.AddRangeAsync(obj);
            await context.SaveChangesAsync();
        }
        public async Task Update(T obj)
        {
            //entities.Attach(obj);
            //context.Entry(obj).State = EntityState.Modified;
            //var objeto = await entities.FindAsync(obj);
            //return objeto;
            context.Update(obj);
        }
        public async Task Delete(object id)
        {
            T existing = await entities.FindAsync(id);
            if (existing != null)
            {
                entities.Remove(existing);
            }
        }
    }
}
