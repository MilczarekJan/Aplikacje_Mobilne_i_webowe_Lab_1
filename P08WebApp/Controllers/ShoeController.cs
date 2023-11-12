// ShoesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using P08WebApp.Models;


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
    }
}