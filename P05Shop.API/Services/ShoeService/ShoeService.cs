using P05Shop.API.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.ShoeService;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;
using Microsoft.EntityFrameworkCore;

namespace P05Shop.API.Services.ShoeService
{
    public class ShoeService : IShoeService
    {
        private readonly DataContext _dataContext;
        public ShoeService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<ServiceResponse<Shoe>> CreateShoeAsync(Shoe shoe)
        {
            try
            {
                _dataContext.Shoes.Add(shoe);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Shoe>() { Data = shoe, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Shoe>()
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot create shoe"
                };
            }

        }

        public async Task<ServiceResponse<bool>> DeleteShoeAsync(int id)
        {
            // sposób 1 (najpierw znajdujemy potem go usuwamy): 
            var shoeToDelete = _dataContext.Shoes.FirstOrDefault(x => x.Id == id);
            _dataContext.Shoes.Remove(shoeToDelete);
            await _dataContext.SaveChangesAsync();
            // sposób 2: (uzywamy attach : tylko jedno zapytanie do bazy)
            /*
            var product = new Shoe() { Id = id };
            _dataContext.Shoes.Attach(product);
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            */

            return new ServiceResponse<bool>() { Data = true, Success = true };
        }

        public async Task<ServiceResponse<Shoe>> GetShoeAsync(int id) {
            var shoeToGet = _dataContext.Shoes.FirstOrDefault(x => x.Id == id);
            try
            {
                return new ServiceResponse<Shoe>() { Data = shoeToGet, Success = true };
            }
            catch {
                return new ServiceResponse<Shoe>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Shoe>>> GetShoesAsync()
        {
            var shoes = await _dataContext.Shoes.ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Shoe>>()
                {
                    Data = shoes,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Shoe>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }

        }

        public async Task<ServiceResponse<Shoe>> UpdateShoeAsync(Shoe shoe)
        {
            try
            {
                var shoeToEdit = new Shoe() { Id = shoe.Id };
                _dataContext.Shoes.Attach(shoeToEdit);

                shoeToEdit.ShoeSize = shoe.ShoeSize;
                shoeToEdit.Description = shoe.Description;
                shoeToEdit.Name = shoe.Name;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Shoe> { Data = shoeToEdit, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Shoe>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occured while updating product"
                };
            }



        }
        /*
        public async Task<ServiceResponse<List<Shoe>>> GetShoesAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Shoe>>()
                {
                    Data = ShoeSeeder.GenerateShoeData(),
                    //Data = new List<Shoe> { new Shoe { Id = 0, ShoeSize = 45.5, Description = "Nice", Name = "Aliodas"} },
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Shoe>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }

        }
        */
    }
}
