using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.ShoeService;
using P06Shop.Shared.Services.ShoeServices;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService; //shoeservice, bêdzie o odpowiedziach dotycz¹cych butów
        private readonly IConfiguration _configuration;
        private readonly ILogger<ShoeController> _logger;
        private readonly IValidateShoeService _validateShoeService;

        public ShoeController(IShoeService shoeService, IConfiguration configuration, ILogger<ShoeController> logger, IValidateShoeService validateShoeService)
        {
            _shoeService = shoeService;
            _configuration = configuration;
            _logger = logger;
            _validateShoeService = validateShoeService;
        }

        [HttpGet, Authorize]//, Authorize
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
        [ProducesDefaultResponseType(typeof(ServiceResponse<Shoe>))]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<Shoe>>> AddingShoe([FromBody] Shoe shoe)
        {
            if (shoe.Name == null || shoe.Description == null || shoe.ShoeSize == null || shoe.Id.GetType() != typeof(int))
                return BadRequest("Wrong shoe data");

            if (!_validateShoeService.validateShoe(shoe.ShoeSize, shoe.Name, shoe.Description)) {
                return BadRequest("Wrong shoe data");            
            }
            //var addShoeEndpoint = _configuration["ApiEndpoints:AddShoeEndpoint"];
            var result = await _shoeService.CreateShoeAsync(shoe);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
            //return Created(addShoeEndpoint + "/", shoe);
        }


        [HttpGet("GetShoe/{id}")]
        public async Task<ActionResult<ServiceResponse<Shoe>>> GetShoe([FromRoute] int id)
        {

            _logger.Log(LogLevel.Information, "Invoked GetShoe Method in controller");

            var result = await _shoeService.GetShoeAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
            //return Ok(new Shoe(id, 44.5, "Airmax", "Adidas") { Name = "Adidas" });
        }

        [HttpDelete("DeleteShoe/{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<Shoe>>> DeleteShoe(int id)
        {
            if (id == null)
                return BadRequest("Wrong shoe data");
            var result = await _shoeService.DeleteShoeAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPut("UpdateShoe/{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<Shoe>>> UpdateShoe(int id, [FromBody] Shoe updatedShoe)
        {
            if (id == null)
                return BadRequest("Wrong shoe data");
			if (!_validateShoeService.validateShoe(updatedShoe.ShoeSize, updatedShoe.Name, updatedShoe.Description))
			{
				return BadRequest("Wrong shoe data");
			}
			updatedShoe.setId(id);
            var result = await _shoeService.UpdateShoeAsync(updatedShoe);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

    }
}