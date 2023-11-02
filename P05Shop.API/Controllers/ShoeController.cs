using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public ShoeController(IShoeService shoeService, IConfiguration configuration)
        {
            _shoeService = shoeService;
            _configuration = configuration;
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

        [HttpPost("newShoe")]
        [HttpPost("addShoe")]
        public IActionResult AddingShoe([FromBody] Shoe shoe)
        {
            if (shoe.Name == null || shoe.Description == null)
                return BadRequest("shoe added");

            var addShoeEndpoint = _configuration["ApiEndpoints:AddShoeEndpoint"];

            return Created(addShoeEndpoint + "/5", shoe);
        }


        [HttpGet("GetShoe/{id}")]
        public IActionResult GetShoe([FromRoute] int id)
        {
            return Ok(new Shoe(id, 44.5, "Airmax", "Adidas") { Name = "Adidas" });
        }

        [HttpDelete("DeleteShoe/{id}")]
        public string DeleteShoe(int id)
        {
            return "Shoe with ID " + id + " has been deleted.";
        }

        [HttpPut("UpdateShoe/{id}")]
        public string UpdateShoe(int id, [FromBody] Shoe updatedShoe)
        {
            return "City with ID " + id + " has been updated with new data: " +
                $"Name: {updatedShoe.Name}, Size: {updatedShoe.ShoeSize}";
        }

    }
}