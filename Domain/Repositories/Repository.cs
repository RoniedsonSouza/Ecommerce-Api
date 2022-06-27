using Application.Interfaces;
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

        public async Task<IEnumerable<T>> GetAll()
        {
            return entities.ToList();
        }
        public async Task<T> GetById(object id)
        {
            return entities.Find(id);
        }
        public async Task<T> Insert(T obj)
        {
            entities.Add(obj);
            context.SaveChangesAsync();
            var objeto = await entities.FindAsync(obj);
            return objeto;
        }
        public async Task<T> Update(T obj)
        {
            entities.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            var objeto = await entities.FindAsync(obj);
            return objeto;
        }
        public async Task<bool> Delete(object id)
        {
            T existing = await entities.FindAsync(id);
            if (existing != null)
            {
                entities.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
