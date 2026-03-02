using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;

namespace KASHOP.BBL.Service
{
   public interface ICategoryService 
    {
       Task< List<CategoryResponse>>GetAllCategoriesAsync();
       Task< CategoryResponse> CreateCategoryAsync(CategoryRequest request);
    }
}
