using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositry
{
   public interface IGenericRepository<T> where T :class
    {
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T category);
    }
}
