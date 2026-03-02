using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositry
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
       Task<List<Category>> GetAllAsync();
       Task< Category >CreateAsync(Category category);

    }
}
