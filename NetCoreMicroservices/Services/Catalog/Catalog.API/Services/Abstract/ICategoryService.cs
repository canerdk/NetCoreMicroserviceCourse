using Catalog.API.Dtos;
using Catalog.API.Entities;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
