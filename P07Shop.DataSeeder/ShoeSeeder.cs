using Bogus;
using P06Shop.Shared.Shop;

namespace P07Shop.DataSeeder
{
    public class ShoeSeeder
    {
        public static List<Shoe> GenerateShoeData()
        {
            int shoeId = 1;
            var shoeFaker = new Faker<Shoe>()
                .UseSeed(12345)
                .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.ShoeSize, x => x.Commerce.Random.Double())
                .RuleFor(x => x.Id, x => shoeId++);

            return shoeFaker.Generate(10).ToList();

        }
    }
}
