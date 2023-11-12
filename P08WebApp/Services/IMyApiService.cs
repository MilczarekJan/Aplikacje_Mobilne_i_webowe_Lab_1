using P06Shop.Shared.Shop;
using P08WebApp.Models;
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
        Task<Shoe> AddShoeAsync(AddShoeDto shoe);
        Task<Shoe> GetShoeAsync(int id);
        Task<DeleteViewModel> DeleteShoeAsync(int id);
        Task<Shoe> UpdateShoeAsync(int id, AddShoeDto updatedShoe);
    }
}
