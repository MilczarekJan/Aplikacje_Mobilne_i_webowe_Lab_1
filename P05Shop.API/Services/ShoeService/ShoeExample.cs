using P06Shop.Shared.Shop;
using Swashbuckle.Examples;

public class ShoeExample : IExamplesProvider
{
    public object GetExamples()
    {
        return new Shoe
        {
            ShoeSize = 42.5,
            Description = "A comfortable shoe",
            Name = "Awesome Shoe"
        };
    }
}