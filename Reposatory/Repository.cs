using Application.Contracts;
using Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce_API.Reposatories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        protected readonly DContext _context;//= new DContext();
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            var data = (await _dbSet.AddAsync(item)).Entity;
                      await _context.SaveChangesAsync();
                       return data;
        }


        public async Task<bool> DeleteAsync(TId id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbSet.Update(item);

            if (entity != null)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public async Task<int> SaveOnDbAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
    //   public class Reposatory<TE, Tid> where TE : class
    //   {
    //       protected readonly DContext con;
    //       private readonly DbSet<TE> dbset;
    //       public Reposatory(DContext _con)
    //       {
    //           dbset = _con.Set<TE>();
    //           con = _con;
    //       }

    //       public async Task<TE?> GetByIDAsync(Tid id)
    //       {
    //           return await dbset.FindAsync(id);
    //       }
    //       public async Task<TE> CreateAsync(TE entity)
    //       {

    //           var data = (await dbset.AddAsync(entity)).Entity;
    //           await con.SaveChangesAsync();
    //           return data;
    //       }



    //       //public async Task<TE?> GetAll()
    //       //{
    //       //    return await dbset.ToList();
    //       //}

    //       public async Task<bool> UpdateAsync(TE entity)
    //       {
    //           var en = dbset.Update(entity);
    //           if (en != null)
    //           {
    //               await con.SaveChangesAsync();
    //               return true;
    //           }
    //           else
    //           {
    //               return false;
    //           }
    //       }

    //	public async Task<bool> DeleteAsync(Tid id)
    //	{
    //		var i = await dbset.FindAsync(id);
    //		if (i != null)
    //		{
    //			dbset.Remove(i);
    //			await con.SaveChangesAsync();
    //			return true;
    //		}
    //		return false;
    //	}


    //}
}
