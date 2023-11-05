using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.ShoeService
{
    public interface IShoeService
    {
        Task<ServiceResponse<Shoe>> GetShoeAsync(int id);
        Task<ServiceResponse<List<Shoe>>> GetShoesAsync();
        Task<ServiceResponse<Shoe>> CreateProductAsync(Shoe shoe);
        Task<ServiceResponse<bool>> DeleteShoeAsync(int id);
        Task<ServiceResponse<Shoe>> UpdateProductAsync(Shoe shoe);
    }
}
