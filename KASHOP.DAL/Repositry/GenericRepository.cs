using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.DAL.Repositry
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context; // injection
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        } 

        public async Task<T> CreateAsync(T Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<List<T>> GetAllAsync(string[]? includes =null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null) // معناها عندي ريليشن 
            { foreach (var include in includes )
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
    }
}
