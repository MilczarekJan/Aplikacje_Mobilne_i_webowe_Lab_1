using P06Shop.Shared.Shop;
using P09BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09BlazorApp.Services
{
	public interface IMyApiService
	{
		Task<Shoe[]> GetShoesAsync();
		Task<Shoe> AddShoeAsync(AddShoeDto shoe);
		Task<Shoe> GetShoeAsync(string id);
		Task<DeleteViewModel> DeleteShoeAsync(int id);
		Task<Shoe> UpdateShoeAsync(int id, AddShoeDto updatedShoe);
	}
}
