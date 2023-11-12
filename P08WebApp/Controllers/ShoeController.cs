// ShoesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using P08WebApp.Models;
using P06Shop.Shared.Shop;


namespace P08WebApp
{
    public class ShoesController : Controller
    {
        private readonly IMyApiService _shoeApiClient; // Assume IShoeApiClient is an interface for your API client

        public ShoesController(IMyApiService shoeApiClient)
        {
            _shoeApiClient = shoeApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DisplayShoeInfo(int shoeId)
        {
            var shoe = await _shoeApiClient.GetShoeAsync(shoeId);
            if (shoe == null)
            {
                return NotFound("No shoe found from this Id");
            }
            var shoeViewModel = new ShoeViewModel
            {
                Id = shoe.Id,
                ShoeSize = shoe.ShoeSize,
                Description = shoe.Description,
                Name = shoe.Name
            };

            return View(shoeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DisplayDeleteMessage(int shoeId) { 
            var isDeleted = await _shoeApiClient.DeleteShoeAsync(shoeId);
            if (isDeleted == null)
            {
                return NotFound("No shoe found by this Id");
            }

            if (isDeleted.success == true) {

            }
            return View(isDeleted);
        }

        [HttpPost]
        public async Task<IActionResult> DisplayAddedShoe(string shoeName, double shoeSize, string shoeDescription)//ShoeViewModel model
        {
            /*
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            */

            var shoe = new AddShoeDto
            {
                Name = shoeName,
                ShoeSize = shoeSize,
                Description = shoeDescription
            };
            var isAdded = await _shoeApiClient.AddShoeAsync(shoe);
            if (isAdded == null)
            {
                return NotFound("Couldn't add the shoe");
            }
            var shoeViewModel = new ShoeViewModel
            {
                Id = isAdded.Id,
                ShoeSize = isAdded.ShoeSize,
                Description = isAdded.Description,
                Name = isAdded.Name
            };

            return View(shoeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DisplayUpdatedShoe(int shoeId, string shoeName, double shoeSize, string shoeDescription)//ShoeViewModel model
        {
            /*
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            */

            var shoe = new AddShoeDto
            {
                Name = shoeName,
                ShoeSize = shoeSize,
                Description = shoeDescription
            };
            var isAdded = await _shoeApiClient.UpdateShoeAsync(shoeId, shoe);
            if (isAdded == null)
            {
                return NotFound("Couldn't add the shoe");
            }
            var shoeViewModel = new ShoeViewModel
            {
                Id = isAdded.Id,
                ShoeSize = isAdded.ShoeSize,
                Description = isAdded.Description,
                Name = isAdded.Name
            };

            return View(shoeViewModel);
        }
    }
}