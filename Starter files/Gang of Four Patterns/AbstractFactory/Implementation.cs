namespace AbstractFactory;

/// <summary>
/// abstract factory
/// </summary>
public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();
    IShippingCostsService CreateShippingCostsService();
}

/// <summary>
/// abstract product
/// </summary>
public interface IDiscountService
{
    int DiscountPercentage { get; }
}

/// <summary>
/// abstract product
/// </summary>
public interface IShippingCostsService
{
    decimal ShippingCosts { get; }
}

public class BelgiumDiscountService : IDiscountService
{
    public int DiscountPercentage => 20;
}

public class FranceDiscountService : IDiscountService
{
    public int DiscountPercentage => 10;
}

public class BelgiumShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 20;
}

public class FranceShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 25;
}

public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new BelgiumDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new BelgiumShippingCostsService();
    }
}

public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new FranceDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new FranceShippingCostsService();
    }

}

/// <summary>
/// client
/// </summary>
public class ShoppingCart
{
    private readonly IDiscountService _discountService;
    private readonly IShippingCostsService _shippingCostsService;
    private int _orderCosts;

    public ShoppingCart(IShoppingCartPurchaseFactory factory)
    {
        _discountService = factory.CreateDiscountService();
        _shippingCostsService = factory.CreateShippingCostsService();
        //assume that the total cost of all the items we ordered = 200
        _orderCosts = 200;
    }

    public void CalculateCosts()
    {
        Console.WriteLine(
            $"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
    }
}
