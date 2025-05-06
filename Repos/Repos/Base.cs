using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Repos.Services;

namespace Repos.Repos
{
    public class Base<T>:IBase<T> where T : class
    {
        private readonly Apppdbcontext context;
        private readonly DbSet<T> dbSet;    

        public Base(Apppdbcontext context)
        {
            this.context = context;
            dbSet=context.Set<T>();
        }

        public async Task Add(T entity)
        {
          await  dbSet.AddAsync(entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            var item= await getbyid(id);
             dbSet.Remove(item);
            await Save();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await dbSet.ToListAsync();
        }

        public async Task<T> getbyid(int id)
        {
            var item=await dbSet.FindAsync(id);
            return item;
        }

        public async Task Save()
        {
          await  context.SaveChangesAsync();
        }

        public async Task update(T entity)
        {
            dbSet.Update(entity);
            await Save();
        }
    }
}
