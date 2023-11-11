using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08WebApp
{
    public interface IMyApiService
    {
        Task<Shoe[]> GetShoesAsync();
        Task<Shoe> AddShoeAsync(Shoe shoe);
        Task<Shoe> GetShoeAsync(int id);
        Task<Shoe> DeleteShoeAsync(int id);
        Task<Shoe> UpdateShoeAsync(int id, Shoe updatedShoe);
    }
}
