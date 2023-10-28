using Microsoft.AspNetCore.Mvc;
using P06Shop.Shared;
using P06Shop.Shared.Services.ShoeService;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService; //shoeservice, bêdzie o odpowiedziach dotycz¹cych butów

        public ShoeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Shoe>>>> GetShoes()
        {

            var result = await _shoeService.GetShoesAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost("newShoe")]  //https://localhost:7230/api/WeatherForecast/newCity
        [HttpPost("addShoe")] //https://localhost:7230/api/WeatherForecast/addCity
        public IActionResult AddingShoe([FromBody] Shoe shoe)
        {
            // return Ok("city added");
            //return StatusCode(200, "city added");

            if ((shoe.Name == null) || (shoe.Description==null))
                return BadRequest("shoe added");

            try
            {
                //  int a = 0;
                //  int b = 4 / a;
                // proba dodawnia 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


            int id = 5;
            return Created($"https://localhost:7230/api/WeatherForecast/GetShoe/{id}", shoe);
        }

        [HttpGet("GetShoe/{id}")]
        public IActionResult GetShoe([FromRoute] int id)
        {
            return Ok(new Shoe() { Name = "Adidas" });
        }
    }
}